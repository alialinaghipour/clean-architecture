namespace WebMvc.Controllers.Accounts;

public class AccountController : Controller
{
    private readonly IMessageSenderService _messageSenderService;
    private readonly ISignInManagementService _signInManagementService;
    private readonly IUnitOfWork _unitOfWork;
    private readonly IUserManagementService _userManagementService;
    private readonly IUserService _userService;

    public AccountController(
        IUnitOfWork unitOfWork,
        IUserManagementService userManagementService,
        IMessageSenderService messageSenderService,
        IUserService userService,
        ISignInManagementService signInManagementService)
    {
        _unitOfWork = unitOfWork;
        _userManagementService = userManagementService;
        _messageSenderService = messageSenderService;
        _userService = userService;
        _signInManagementService = signInManagementService;
    }

    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }
    
    [Route("Register")]
    [HttpPost]
    public async Task<IActionResult> Register(RegisterUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(
                string.Empty,
                "اطلاعات را کامل وارد کنید");
            return View(model);
        }

        await _unitOfWork.Begin();
        try
        {
            var user = await _userService.Register(new UserRegisterDto
            {
                Email = model.Email.FixedText(),
                UserName = model.UserName
            });
            var applicationUser = new ApplicationUser
            {
                Id = user.Id,
                Email = model.Email,
                UserName = model.UserName
            };
            await _userManagementService
                .Create(applicationUser, model.Password);
            await SendRegisterEmail(applicationUser);
            await _unitOfWork.Commit();

            return View("RegisterSucceeded", new RegisterSucceededViewModel
            {
                Email = user.Email,
                UserName = user.UserName
            });
        }
        catch
        {
            await _unitOfWork.Rollback();
            throw;
        }
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmEmail(
        string userName,
        string token)
    {
        if (string.IsNullOrEmpty(userName) &&
            string.IsNullOrEmpty(token))
            return NotFound();

        try
        {
            var user = await _userManagementService.FindByUsername(userName);
            await _userManagementService.ConfirmEmail(user, token);
            return View(new GetEmailViewModel(user.Email));
        }
        catch (UserNotFoundException)
        {
            return NotFound();
        }
    }

    [Route("Login")]
    public IActionResult Login()
    {
        if (_signInManagementService.IsSignIn(User))
            return RedirectToAction("Index", "Home");

        return View();
    }

    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(
        LoginUserViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty,
                "اطلاعات را کامل وارد کنید");
            return View(model);
        }

        try
        {
            var user = await _userManagementService
                .ConfirmLogin(model.UserName, model.Password);

            await _signInManagementService.PasswordSignIn(new PasswordSignInDto
            {
                UserName = user.UserName,
                Password = model.Password,
                RememberMe = model.RememberMe,
                LockoutOnFailure = false
            });

            ViewBag.IsSuccess = true;
            return View();
        }
        catch (YourAccountHasNotBeenActivatedException)
        {
            ModelState.AddModelError(
                "UserName",
                "کاربری با مشخصات وارد شده یافت نشد");
            return View(model);
        }
        catch (WrongUsernameOrPasswordException)
        {
            ModelState.AddModelError(
                "UserName",
                "نام کاربری یا کلمه ی عبور اشتباه است");
            return View(model);
        }
    }

    [Route("ForgotPassword")]
    public IActionResult ForgotPassword()
    {
        return View();
    }

    [HttpPost]
    [Route("ForgotPassword")]
    public async Task<IActionResult> ForgotPassword(
        ForgotPasswordViewModel model)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(string.Empty,
                "اطلاعات را کامل وارد کنید");
            return View(model);
        }

        try
        {
            var user = await _userManagementService.FindByEmail(model.Email);

            var emailMessage = GenerateEmailMessageForPasswordRest(user);
            await _messageSenderService.SendEmail(new SendEmailDto
            {
                Body = emailMessage,
                Subject = "reset password",
                ToEmail = user.Email,
                IsBodyHtml = true
            });

            ViewBag.IsSuccess = true;

            return View();
        }
        catch (UserNotFoundException)
        {
            ModelState.AddModelError("Email", "کاربری یافت نشد");
            return View(model);
        }
    }

    [HttpGet]
    public IActionResult ResetPassword(
        string userName,
        string securityStamp)
    {
        if (string.IsNullOrEmpty(userName) &&
            string.IsNullOrEmpty(securityStamp))
            return NotFound();

        return View(new ResetPasswordViewModel
        {
            UserName = userName,
            SecurityStamp = securityStamp
        });
    }


    [HttpPost]
    public async Task<IActionResult> ResetPassword(
        ResetPasswordViewModel model)
    {
        if (!ModelState.IsValid)
            return NotFound();

        await _unitOfWork.Begin();
        try
        {
            var user = await _userManagementService
                .FindByUsername(model.UserName);
            var security = await _userManagementService
                .GetSecurityStamp(user);
            if (security != model.SecurityStamp)
                return NotFound();

            await _userManagementService.UpdateSecurityStamp(user);
            await _userManagementService
                .ResetPassword(user, model.Password);

            await _unitOfWork.Commit();

            return RedirectToAction("Login", "Account");
        }
        catch (UserNotFoundException)
        {
            await _unitOfWork.Rollback();
            ModelState.AddModelError(
                string.Empty,
                "کاربری یافت نشد");
            return View(model);
        }
        catch (UpdateSecurityStampFailedException)
        {
            await _unitOfWork.Rollback();
            ModelState.AddModelError(string.Empty,
                "مشکل امنیتی رخ داده است");
            return View(model);
        }
        catch (ResetPasswordFailedException)
        {
            await _unitOfWork.Rollback();
            ModelState.AddModelError(string.Empty,
                "عملیات تغییر رمز با خطا مواجه شده است");
            return View(model);
        }
        catch (Exception)
        {
            await _unitOfWork.Rollback();
            return View(model);
        }
    }

    [HttpGet]
    public async Task<IActionResult> ConfirmPassword(string userName,
        string token)
    {
        if (string.IsNullOrEmpty(userName) &&
            string.IsNullOrEmpty(token))
            return NotFound();

        try
        {
            var user = await _userManagementService.FindByUsername(userName);
            await _userManagementService.ConfirmEmail(user, token);
            return View("ConfirmPassword", new GetEmailViewModel(user.Email));
        }
        catch (UserNotFoundException)
        {
            return NotFound();
        }
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOut()
    {
        await _signInManagementService.SignOut();
        // await HttpContext.SignOutAsync();
        return RedirectToAction("Index", "Home");
    }

    private string? GenerateEmailMessageForPasswordRest(
        ApplicationUser user)
    {
        var emailMessage = Url.Action(
            "ResetPassword", "Account", new
            {
                userName = user.UserName,
                securityStamp = user.SecurityStamp
            },
            Request.Scheme);
        return emailMessage;
    }

    private async Task SendRegisterEmail(
        ApplicationUser applicationUser)
    {
        var emailMessage = await
            GenerateEmailMessageByConfirmToken(applicationUser);
        await _messageSenderService.SendEmail(new SendEmailDto
        {
            Body = emailMessage,
            Subject = "Activation email",
            ToEmail = applicationUser.Email,
            IsBodyHtml = true
        });
    }

    private async Task<string?> GenerateEmailMessageByConfirmToken(
        ApplicationUser applicationUser)
    {
        var emailConfirmationToken = await _userManagementService
            .GenerateEmailConfirmationToken(applicationUser);
        var emailMessage = Url.Action(
            "ConfirmEmail", "Account", new
            {
                userName = applicationUser.UserName,
                token = emailConfirmationToken
            },
            Request.Scheme);
        return emailMessage;
    }
}

using Identity.Dto;

namespace WebMvc.Controllers;

public class AccountController : Controller
{
    private readonly ICreateMemberAndUserHandler _createHandler;
    private readonly ISignInManagementService _signInService;
    private readonly IUserLoginAndCreateTokenServiceHandler _loginHandler;

    public AccountController(
        ICreateMemberAndUserHandler createHandler,
        ISignInManagementService signInService,
        IUserLoginAndCreateTokenServiceHandler loginHandler)
    {
        _createHandler = createHandler;
        _signInService = signInService;
        _loginHandler = loginHandler;
    }
    
    public IActionResult Index()
    {
        return View();
    }
    
    [HttpGet]
    [Route("Register")]
    public IActionResult Register()
    {
        return View();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    [Route("Register")]
    public async Task<IActionResult> Register(RegisterViewModel model) 
    {
        try
        {
            await _createHandler.Create(new CreateMemberAndUserDto
            {
                Email = model.Email,
                Password = model.Password,
                ConfirmPassword = model.ConfirmPassword,
                FirstName = model.FirstName,
                LastName = model.LastName
            });

            return View(nameof(Index));
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "خظایی رخ داد");
            return View(model);
        }
    }
    
    [HttpGet]
    [Route("Login")]
    public IActionResult Login(string returnUrl)
    {
        if (_signInService.IsSignIn(User))
            return RedirectToAction("Index", "Home");

        ViewData["ReturnUrl"] = returnUrl;
        
        var model = new LoginViewModel
        {
            ReturnUrl = returnUrl,
        };

        return View(model);
    }
    
    [HttpPost]
    [Route("Login")]
    public async Task<IActionResult> Login(
        LoginViewModel model,
        string? returnUrl = null)
    {
        if (!ModelState.IsValid)
        {
            ModelState.AddModelError(
                string.Empty,
                "اطلاعات را کامل وارد کنید");
            return View(model);
        }

        try
        {
            await _loginHandler.LoginWeb(new UserLoginDto
            {
                Password = model.Password,
                RepeatPassword = model.Password,
                UserName = model.Email
            });

            await _signInService.PasswordSignIn(new PasswordSignInDto
            {
                Password = model.Password,
                RememberMe = false,
                UserName = model.Email,
            });

            return RedirectToAction("Index", "Home");
        }
        catch
        {
            ModelState.AddModelError(string.Empty, "خظایی رخ داد");
            return View(model);
        }
    }
    
    [HttpPost]
    [ValidateAntiForgeryToken]
    public async Task<IActionResult> LogOut()
    {
        await _signInService.SignOut();
        return RedirectToAction("Index", "Home");
    }
}
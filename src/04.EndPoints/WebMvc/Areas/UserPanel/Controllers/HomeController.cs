using Microsoft.AspNetCore.Authorization;
using WebMvc.Areas.UserPanel.Models;

namespace WebMvc.Areas.UserPanel.Controllers;

[Area("UserPanel")]
[Authorize]
public class HomeController : Controller
{
    private readonly IUserInfoIdentity _userInfoIdentity;
    private readonly IUserService _userService;

    public HomeController(
        IUserService userService,
        IUserInfoIdentity userInfoIdentity)
    {
        _userService = userService;
        _userInfoIdentity = userInfoIdentity;
    }

    public async Task<IActionResult> Index()
    {
        var userName = _userInfoIdentity.GetUserName();
        var userInfo = await _userService
            .GetInformationByUserName(userName);

        if (userInfo == null)
            return BadRequest();

        var model = new InformationViewModel
        {
            Email = userInfo.Email,
            Wallet = userInfo.Wallet,
            UserName = userInfo.UserName,
            RegisterDate = userInfo.RegisterDate.ToShamsi()
        };

        return View(model);
    }
}
using System.Security.Claims;
using Infrastructure.Token;
using Microsoft.AspNetCore.Mvc;

namespace RestApi.Controllers;

[ApiController]
[Route("api/accounts")]
public class AccountController : ControllerBase
{
    private readonly ITokenService _tokenService;

    public AccountController(ITokenService tokenService)
    {
        _tokenService = tokenService;
    }

    [HttpGet("token")]
    public IActionResult CreateToken()
    {
        // for tests
        var token = _tokenService
            .Create(new List<Claim>(),
                new List<string>(),
                "1");
        return Content(token);
    }
}
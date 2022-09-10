using ApplicationHandlerContracts.UserLogin;
using Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using Persistence.Ef;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace WebApi.Controllers
{
    [ApiController]
    [Route("[controller]")]
    public class WeatherForecastController : ControllerBase
    {
        private static readonly string[] Summaries = new[]
        {
            "Freezing", "Bracing", "Chilly", "Cool", "Mild", "Warm", "Balmy", "Hot", "Sweltering", "Scorching"
        };
        private readonly IUserManagementService userManagementService;

        // private readonly ILogger<WeatherForecastController> _logger;
        private readonly IALi aLi;
        private readonly ApplicationDbContext context;

        //public WeatherForecastController(ILogger<WeatherForecastController> logger)
        //{
        //    _logger = logger;
        //}

        //[HttpGet]
        //public IEnumerable<WeatherForecast> Get()
        //{
        //    var rng = new Random();
        //    return Enumerable.Range(1, 5).Select(index => new WeatherForecast
        //    {
        //        Date = DateTime.Now.AddDays(index),
        //        TemperatureC = rng.Next(-20, 55),
        //        Summary = Summaries[rng.Next(Summaries.Length)]
        //    })
        //    .ToArray();
        //}
        private readonly IUserLoginAndCreateTokenServiceHandler _loginAndCreateTokenServiceHandler;

        public WeatherForecastController(
             IUserLoginAndCreateTokenServiceHandler 
            loginAndCreateTokenServiceHandler,
            IUserManagementService userManagementService,
            IALi aLi,
            ApplicationDbContext context)
        {
            this.userManagementService = userManagementService;
            this.aLi = aLi;
            this.context = context;
            _loginAndCreateTokenServiceHandler = loginAndCreateTokenServiceHandler;
        }

        [HttpPost("login")]
        public async Task<string> Login(UserLoginDto dto)
        {
            return await _loginAndCreateTokenServiceHandler.Login(dto);
        }

        [HttpPost]
        public string aaa()
        {
            return aLi.Get();
        }
    }

    public interface IALi
    {
        string Get();
    }

    public class Ali : IALi
    {
        public string Get()
        {
            return "ali get";
        }
    }
}

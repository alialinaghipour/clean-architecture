using ApplicationHandlerContracts.UserLogin;
using ApplicationServiceHandlers.CreateMemberAndUser;
using ApplicationServiceHandlers.UserLogin;
using Infrastructure.EndPointConfig.Auth;
using Infrastructure.EndPointConfig.Services;
using Infrastructure.Tools;

namespace Test.IntegrationHandlers;

public class Startup
{
    public void ConfigureServices(IServiceCollection services)
    {
        services.AddScoped(_ =>
            new ApplicationDbContext(
                "server=.;database=Name;trusted_connection=true;"));
        
    
        services
            .AddIdentity<User, Role>(option =>
            {
                option.Password.RequireNonAlphanumeric = false;
                option.Password.RequireLowercase = false;
                option.Password.RequireUppercase = false;
                option.Password.RequiredLength = 3;
                option.Password.RequireDigit = false;
                option.User.RequireUniqueEmail = true;
                option.Lockout.AllowedForNewUsers = false;
            }).AddEntityFrameworkStores<ApplicationDbContext>()
            .AddDefaultTokenProviders();
        
        services
            .AddScoped<IUserManagementService, UserManagementAppService>();
        services
            .AddScoped<ISignInManagementService, SignInManagementAppService>();
        services
            .AddScoped<IGenerateCodeService,GenerateCodeAppService>();
        services
            .AddScoped<IUnitOfWork, EfUnitOfWork>();
        services
            .AddScoped<IMemberService, MemberAppService>();
        services
            .AddScoped<IMemberRepository, EfMemberRepository>();
        services
            .AddScoped<ICreateMemberAndUserHandler, CreateMemberAndUserServiceHandler>();
        services
            .AddScoped<IUserLoginAndCreateTokenServiceHandler, UserLoginAndCreateTokenAppServiceHandler>();
        services
            .AddScoped<ITokenService, TokenAppService>();
    }
}
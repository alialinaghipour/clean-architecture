namespace Infrastructure.UserIdentity;

internal class HttpContextUserInfoIdentity : IUserInfoIdentity
{
    private readonly IHttpContextAccessor _accessor;

    public HttpContextUserInfoIdentity(IHttpContextAccessor accessor)
    {
        if (accessor.HttpContext?.User?.Claims == null)
            throw new Exception("Http context is null");
        _accessor = accessor;
    }


    public string GetUserId()
    {
        return GetUserIdFromJwtToken();
    }

    public IList<string> GetRoles()
    {
        return _accessor.HttpContext != null
            ? GetRolesFromJwtToken()
            : new List<string>();
    }

    public string GetUserName()
    {
        return GetUserNameFromJwtToken();
    }

    private string GetUserIdFromJwtToken()
    {
        return _accessor.HttpContext!.User!.Claims!
            .FirstOrDefault(_ => _.Type == ClaimTypes.NameIdentifier)!
            .Value;
    }

    private IList<string> GetRolesFromJwtToken()
    {
        return _accessor.HttpContext!.User.Claims
            .Where(_ => _.Type == ClaimTypes.Role)
            .Select(_ => _.Value)
            .ToList();
    }

    private string GetUserNameFromJwtToken()
    {
        var userName = _accessor.HttpContext!.User!.Claims!
            .FirstOrDefault(_ => _.Type == ClaimTypes.Name)!
            .Value;

        return userName;
    }
}
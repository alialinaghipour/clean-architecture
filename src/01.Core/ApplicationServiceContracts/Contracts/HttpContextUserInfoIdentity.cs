namespace ApplicationContracts.Contracts;

public interface IUserInfoIdentity : IScoped
{
    string GetUserId();
    IList<string> GetRoles();
    string GetUserName();
}
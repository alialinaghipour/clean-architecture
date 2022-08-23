namespace ApplicationContracts.Contracts;

public interface IUserInfoIdentity
{
    string GetUserId();
    IList<string> GetRoles();
    string GetUserName();
}
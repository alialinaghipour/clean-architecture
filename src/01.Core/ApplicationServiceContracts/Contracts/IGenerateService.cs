namespace ApplicationContracts.Contracts;

public interface IGenerateCodeService : IScoped
{
    string UniqueCode();
}
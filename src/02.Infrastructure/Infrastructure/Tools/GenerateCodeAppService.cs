namespace Infrastructure.Tools;

public class GenerateCodeAppService : IGenerateCodeService
{
    public string UniqueCode()
    {
        return Guid.NewGuid().ToString("N");
    }
}
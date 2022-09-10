using ApplicationContracts.Contracts;
using Infrastructure.EndPointConfig.Services;
using Infrastructure.Tools;
using Moq;

namespace Test.Infrastructure.Factory.GenerateCode;

public static class GenerateCodeFactory
{
    public static IGenerateCodeService Create()
    {
        return new GenerateCodeAppService();
    }

    public static IGenerateCodeService CreateMoq(string? input)
    {
        var code = "id_" + Guid.NewGuid().ToString("N");
        var moqService = new Mock<IGenerateCodeService>();
        moqService.Setup(_ => _.UniqueCode())
            .Returns(input ?? code);

        return moqService.Object;
    }
}
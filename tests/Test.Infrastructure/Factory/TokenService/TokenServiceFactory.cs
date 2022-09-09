using System.Security.Claims;
using ApplicationContracts.Contracts;
using Moq;

namespace Test.Infrastructure.Factory.TokenService;

public static class TokenServiceFactory
{
    public static Mock<ITokenService> CreateServiceMock()
    {
        return new Mock<ITokenService>();
    }

    public static void SetupCreateMethod(
        this Mock<ITokenService> tokenServiceMock,
        string userId,
        string result)
    {
        tokenServiceMock
            .Setup(_ => _.Create(
                new List<Claim>(),
                new List<string>(),
                userId))
            .Returns(result);
    }
    
    public static void VerifyCreateMethod(
        this Mock<ITokenService> tokenServiceMock,
        string userId)
    {
        tokenServiceMock.Verify(_ => _.Create(
            It.IsAny<List<Claim>>(),
            It.IsAny<ICollection<string>>(),
            It.Is<string>(d=>d == userId)));
    }
}
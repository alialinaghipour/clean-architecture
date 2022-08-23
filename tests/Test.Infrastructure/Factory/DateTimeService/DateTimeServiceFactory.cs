using ApplicationContracts.Contracts;
using Moq;

namespace Test.Infrastructure.Factory.DateTimeService;

public static class DateTimeServiceFactory
{
    public static IDateTimeService CreateMock(DateTime? date)
    {
        var fakeDate = new DateTime(2021, 1, 1);
        var moqService = new Mock<IDateTimeService>();
        moqService.Setup(_ => _.Now)
            .Returns(date ?? fakeDate);

        return moqService.Object;
    }
}
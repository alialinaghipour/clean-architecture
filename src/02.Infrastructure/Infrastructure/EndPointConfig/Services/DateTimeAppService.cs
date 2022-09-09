namespace Infrastructure.EndPointConfig.Services;

public class DateTimeAppService : IDateTimeService
{
    public DateTime Now => DateTime.Now;
    public DateTime UtcNow => DateTime.UtcNow;
}
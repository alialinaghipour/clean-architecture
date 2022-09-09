namespace ApplicationContracts.Contracts;

public interface IDateTimeService : ISingleton
{
    DateTime Now { get; }
    DateTime UtcNow { get; }
}
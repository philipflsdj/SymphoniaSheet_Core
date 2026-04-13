using SS.Domain.Contracts.Services;


namespace SS.Persistence.Services
{
    public class DateTimeProvider : IDateTimeProvider
    {
        public DateTime UtcNow => DateTime.UtcNow;
    }
}

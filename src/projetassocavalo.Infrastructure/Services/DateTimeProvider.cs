using projetassocavalo.Application.Services;

namespace projetassocavalo.Infrastructure.Services;

public class DateTimeProvider : IDateTimeProvider
{
    public DateTime UtcNow  => DateTime.UtcNow;
}
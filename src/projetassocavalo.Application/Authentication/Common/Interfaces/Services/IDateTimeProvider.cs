namespace projetassocavalo.Application.Services;

public interface IDateTimeProvider
{
    DateTime UtcNow { get; }
}
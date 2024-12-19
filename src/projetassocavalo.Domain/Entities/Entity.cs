namespace projetassocavalo.Domain.Entities;

public class Entity
{
    public Guid Id { get; set; } = Guid.NewGuid();
    public DateTime CreatedAt { get; private set; } =  DateTime.UtcNow;
    public DateTime UpdatedAt { get; private set; } =  DateTime.UtcNow;
}
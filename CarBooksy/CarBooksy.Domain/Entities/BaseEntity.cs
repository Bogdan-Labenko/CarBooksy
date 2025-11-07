namespace CarBooksy.Domain.Entities;

public abstract class BaseEntity
{
    public Guid Id { get; init; }
    
    public bool IsDeleted { get; protected set; }
}
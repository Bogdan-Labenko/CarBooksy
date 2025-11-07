namespace CarBooksy.Domain.Common;

public abstract class BaseEntity
{
    public Guid Id { get; init; }
    public bool IsDeleted { get; protected set; }
    public void Delete() => IsDeleted = true;
}
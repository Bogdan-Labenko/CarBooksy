namespace CarBooksy.Domain.Common;

public interface IAuditEntity
{
    DateTime CreatedAt { get; set; }
    DateTime? ModifiedAt { get; set; }
    Guid CreatedBy { get; set; }
    Guid? ModifiedBy { get; set; }
}
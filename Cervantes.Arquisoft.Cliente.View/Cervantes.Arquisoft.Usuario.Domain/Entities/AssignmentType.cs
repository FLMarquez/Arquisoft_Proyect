namespace Cervantes.Arquisoft.Domain.Entities;

public class AssignmentType
{
    public int AssignmentTypeId { get; set; }
    public string AssignmentTypeName { get; set; }
    public string AssignmentTypeDescription { get; set; }
    public int Order { get; set; }
    public int ServiceTypeId { get; set; }
    public ServiceType ServiceType { get; set; }
}
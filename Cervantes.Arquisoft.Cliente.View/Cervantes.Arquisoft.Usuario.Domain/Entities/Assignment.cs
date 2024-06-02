using Cervantes.Arquisoft.Domain.Entities.Common;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Assignment : AuditableEntity
    {
        public int AssignmentId { get; set; }
        public int ProjectId { get; set; }
        public int AssignmentTypeId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public bool IsCompleted { get; set; }
        public bool NotVisible { get; set; }
        public bool IsStarted { get; set; }
        public bool IsSkipped { get; set; }

        public DateTime? CompletedDate { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? SkippedDate { get; set; }
        public DateTime? OriginalDueDate { get; set; }


        public Project Project { get; set; }
        public AssignmentType AssignmentType { get; set; }

        public ICollection<Hub> Commitments { get; set; }
    }
}


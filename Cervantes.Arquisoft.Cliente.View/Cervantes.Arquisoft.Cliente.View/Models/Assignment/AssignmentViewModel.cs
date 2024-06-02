using Cervantes.Arquisoft.Domain.Entities;

namespace Cervantes.Arquisoft.View.Models
{
    public class AssignmentViewModel
    {
        // Datos básicos de la tarea
        public int AssignmentId { get; set; }
        public int ProjectId { get; set; }
        public int AssignmentTypeId { get; set; }
        public string AssignmentName { get; set; }
        public string AssignmentDescription { get; set; }
        public bool IsCompleted { get; set; }
        public bool NotVisible { get; set; }
        public bool IsStarted { get; set; }
        public bool IsSkipped { get; set; }

        // Fechas
        public DateTime? CompletedDate { get; set; }
        public DateTime? StartedDate { get; set; }
        public DateTime? SkippedDate { get; set; }
        public DateTime? OriginalDueDate { get; set; }
        public DateTime? LastDueDate { get; set; }
        public DateTime? NewDueDate { get; set; }
        public string CurrentUser { get; set; }
        public string CurrentUserName { get; set; }

        //public IEnumerable<Domain.Entities.Hub> HubList { get; set; }
        public IEnumerable<Hub> HubList { get; set; }
        public IEnumerable<User> UserList { get; set; }
        public Assignment.HubViewModel NewHub { get; set; }

    }
}

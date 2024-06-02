using Cervantes.Arquisoft.Domain.Entities.Common;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Project : AuditableEntity
    {
        [Key]
        public int ProjectId { get; set; }
        public string Name { get; set; }
        // Otras propiedades del proyecto

        public int UserId { get; set; }
        public User User { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

        public int ServiceTypeId { get; set; }

        public ServiceType ServiceType { get; set; }


        public int ProjectTypeId { get; set; }
        public ProjectType ProjectType { get; set; }

        public int? ProjectStateId { get; set; }
        public ProjectState ProjectStateNavigation { get; set; }

        public Decimal Budget { get; set; }


        public ICollection<Notification> Notifications { get; set; }
        public ICollection<Document> Documents { get; set; }
        public ICollection<Report> Reports { get; set; }
        public ICollection<Image> Images { get; set; }
    }

}

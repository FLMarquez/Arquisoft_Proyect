using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class HistoricalProject
    {
        [Key]
        public int HistoricalProjectId { get; set; }
        public int ProjectId { get; set; }
        public DateTime HistoricalDate { get; set; }
        public int StateId { get; set; }
        public int ProjectTypeId { get; set; }
    }
}

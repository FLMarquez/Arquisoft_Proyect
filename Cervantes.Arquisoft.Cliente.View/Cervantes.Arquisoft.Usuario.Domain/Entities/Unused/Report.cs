namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Report
    {
        public int ReportId { get; set; }
        public string Description { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

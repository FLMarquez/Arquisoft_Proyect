namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Event
    {
        public int EventId { get; set; }
        public string Name { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime EndDate { get; set; }
        // Other event properties



        public int ProjectId { get; set; }
        public Project Project { get; set; }
    }
}

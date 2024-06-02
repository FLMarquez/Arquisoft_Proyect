namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Document
    {
        public int DocumentId { get; set; }
        public string Description { get; set; }
        public DateTime Date { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

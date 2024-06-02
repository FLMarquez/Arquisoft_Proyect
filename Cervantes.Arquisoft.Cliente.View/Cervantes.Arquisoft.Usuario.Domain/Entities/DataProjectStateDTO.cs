namespace Cervantes.Arquisoft.Domain.Entities
{
    public class DataProjectStateDTO
    {
        public string Status { get; set; }
        public DateTime Date { get; set; }

        public int ProjectId { get; set; }
    }

    public class DataProjectTypeDTO
    {
        public string Type { get; set; }
        public DateTime Date { get; set; }
    }

    public class Amount_Method
    {
        public string MethodName { get; set; }
        public int Amount { get; set; }
    }

    public class ProjectType_Amount
    {
        public int Amount { get; set; }
        public string ProjectTypeDescription { get; set; }
    }

    public class Amount_Time
    {
        public int Amount { get; set; }
        public DateTime Date { get; set; }
    }
}

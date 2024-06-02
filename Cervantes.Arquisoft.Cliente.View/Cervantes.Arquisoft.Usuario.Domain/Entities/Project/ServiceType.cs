namespace Cervantes.Arquisoft.Domain.Entities
{
    public class ServiceType
    {

        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDescription { get; set; }
        public bool? IsPrivate { get; set; }
        public string? ServiceTypeImage { get; set; }
    }

}


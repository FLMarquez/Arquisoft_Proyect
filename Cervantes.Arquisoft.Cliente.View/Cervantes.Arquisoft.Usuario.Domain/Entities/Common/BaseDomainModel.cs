namespace Cervantes.Arquisoft.Domain.Entities.Common
{
    public class BaseDomainModel
    {
        //TODO: Add this to children classes who can be deleted.
        public DateTime? DateCreated { get; set; }
        public string? CreatedBy { get; set; }
        public DateTime? LastModifiedDate { get; set; }
        public string? LastModifiedBy { get; set; }
        public bool? IsDeleted { get; set; }
        public DateTime? DeleteDate { get; }
        public string? DeletedBy { get; set; }
    }
}

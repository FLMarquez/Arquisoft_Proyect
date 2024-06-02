namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Locality
    {
        public int LocalityId { get; set; }

        public int? ProvinceId { get; set; }
        public string Description { get; set; }

        public Province IdProvinceNavigation { get; set; }

        public virtual ICollection<Address> Address { get; set; }

    }
}

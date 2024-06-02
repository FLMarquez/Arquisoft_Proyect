using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Address
    {
        //TODO: Add Keys for EF.
        [Key]
        [DatabaseGenerated(DatabaseGeneratedOption.Identity)]
        public int AddressId { get; set; }
        public int? ProvinceId { get; set; }
        public int? LocalityId { get; set; }
        public string AddressLine { get; set; }
        public string PostalCode { get; set; }
        public int Numbering { get; set; }
        public string? Department { get; set; }
        public string? Floor { get; set; }
        public string Neighborhood { get; set; }
        public string? AdditionalInstructions { get; set; }




        public virtual Province ProvinceNavigation { get; set; }
        public virtual Locality LocalityNavigation { get; set; }

        public virtual ICollection<Client> Client { get; set; }


    }
}

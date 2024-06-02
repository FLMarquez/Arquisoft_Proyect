using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class ProjectType
    {
        [Key]
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public string ProjectTypeDescription { get; set; }
        public int RangeMax { get; set; }
        public int RangeMin { get; set; }
        [DisplayFormat(DataFormatString = "{0:N2}", ApplyFormatInEditMode = true)]
        public decimal ProfessionalFee { get; set; }
        public int IsDeleted { get; set; } = 0;
    }
}

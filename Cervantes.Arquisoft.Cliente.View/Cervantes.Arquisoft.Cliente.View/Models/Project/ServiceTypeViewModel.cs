using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class ServiceTypeViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Nombre del Servicio de Proyecto")]
        public string ServiceTypeName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 5000, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Descripción del Servicio de Proyecto")]
        public string ServiceTypeDescription { get; set; }        
    }
}

using Cervantes.Arquisoft.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class AssignmentTypeViewModel
    {
        public int AssignmentTypeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre de la tarea")]
        [StringLength(maximumLength: 40, MinimumLength = 5, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        public string AssignmentTypeName { get; set; }
        public string ServiceTypeName { get; set; }
        public int ServiceTypeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 120, MinimumLength = 5, ErrorMessage = "La longitud de {0} debe estar entre {2} y {1}")]
        [Display(Name = "Descripción del Proyecto")]
        public string AssignmentTypeDescription { get; set; }
        public int? Order { get; set; }
        public IEnumerable<AssignmentTypeDTO> AssignmentTypeList { get; set; }


    }
}
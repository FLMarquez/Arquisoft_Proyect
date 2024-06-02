using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class ProjectTypeViewModel
    {
        public int ProjectTypeId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Nombre del Tipo Proyecto")]
        public string ProjectTypeName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 500, MinimumLength = 10, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Descripción del Proyecto")]
        public string ProjectTypeDescription { get; set; }

        [Display(Name = "Valor Máximo")]
        [RangeMaxGreaterThanMin(ErrorMessage = "El valor máximo debe ser mayor que el valor mínimo.")]
        public int RangeMax { get; set; }


        [Display(Name = "Valor Mínimo")]
        public int RangeMin { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Honorarios")]
        public decimal ProfessionalFee { get; set; }

        private int _compareRange;

        public void CalculateCompareRange()
        {
            _compareRange = RangeMax - RangeMin;
        }

        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            CalculateCompareRange();

            if (_compareRange <= 0)
            {
                yield return new ValidationResult("El rango máximo debe ser mayor que el rango mínimo.", new[] { nameof(RangeMax), nameof(RangeMin) });
            }
        }

    }
}
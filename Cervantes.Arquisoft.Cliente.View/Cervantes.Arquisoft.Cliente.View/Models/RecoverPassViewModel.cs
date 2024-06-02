using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class RecoverPassViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, MinimumLength = 8,
            ErrorMessage = "La longitud de {0} debe ser de {1} numeros")]
        [Display(Name = "DNI")]

        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 7,
            ErrorMessage = "La longitud de {0} debe ser de {2} numeros")]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }


    }


}

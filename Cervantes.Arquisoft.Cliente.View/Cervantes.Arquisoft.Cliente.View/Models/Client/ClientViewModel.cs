using Cervantes.Arquisoft.View.Models.Cervantes.Arquisoft.View.Models;
using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class ClientViewModel
    {

        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Apellido")]
        public string Lastname { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "La longitud de {0} debe ser de {1} numeros")]
        [Display(Name = "DNI")]
        [Remote(action: "AlreadyExistCheck", controller: "Client")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress, ErrorMessage = "El campo {0} debe conter el siguiente formato: ejemplo@ejemplo.com")]
        [EmailAddress]
        [Display(Name = "Mail")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 10, ErrorMessage = "La longitud de {0} debe ser de {2} numeros")]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }

        public AddressViewModel Address { get; set; }


    }

}

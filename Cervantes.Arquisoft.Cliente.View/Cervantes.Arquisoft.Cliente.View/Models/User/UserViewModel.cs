using Microsoft.AspNetCore.Mvc;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class UserViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Nombre")]
        public string Name { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Apellido")]
        public string LastName { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Contraseña")]
        public string Password { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 8, MinimumLength = 8, ErrorMessage = "La longitud de {0} debe ser de {1} numeros")]
        [Display(Name = "Dni del Usuario")]
        [Remote(action: "AlreadyExistCheck", controller: "User")]
        public string DocumentNumber { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [DataType(DataType.EmailAddress)]
        [EmailAddress]
        [Display(Name = "Email")]
        public string Mail { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 10, MinimumLength = 7, ErrorMessage = "La longitud de {0} debe ser de {2} numeros")]
        [Display(Name = "Telefono")]
        public string Telephone { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]

        [Display(Name = "Rol de Usuario")]
        public int UserRoleId { get; set; }

        public int UserStateId { get; set; }

        public int RoleId { get; set; }

        public int StateId { get; set; }



    }

}


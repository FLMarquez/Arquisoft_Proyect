using Cervantes.Arquisoft.Application.DTOs;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class ProjectViewModel
    {
        public int Id { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [StringLength(maximumLength: 50, MinimumLength = 3, ErrorMessage = "La longitud de {0} debe estar entre {1} y {2}")]
        [Display(Name = "Nombre del Proyecto")]
        public string Name { get; set; }

        public int UserId { get; set; }
        public string? UserName { get; set; }
        public string? UserLastName { get; set; }

        public int ClientId { get; set; }
        public string? ClientName { get; set; }
        public string? ClientLastName { get; set; }

        public int ProjectTypeId { get; set; }
        public string? ProjectTypeName { get; set; }
        public int ServiceTypeId { get; set; }
        public string? ServiceTypeName { get; set; }

        public int ProjectStateId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Usuario")]
        public IEnumerable<UserDto>? UserList { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Cliente")]
        public IEnumerable<ClientDto>? ClientList { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Servicio")]
        public IEnumerable<ServiceTypeDto>? ServiceTypeList { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Tipologia")]
        public IEnumerable<ProjectTypeDTO>? ProjectTypeList { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Estado")]
        public IEnumerable<ProjectStateDto>? ProjectStateList { get; set; }

        public int UserValue { get; set; }
        public int ClientValue { get; set; }
        public int ServiceTypeValue { get; set; }
        public int ProjectTypeValue { get; set; }
        public int ProjectStateValue { get; set; }

        public decimal Budget { get; set; }

    }
}

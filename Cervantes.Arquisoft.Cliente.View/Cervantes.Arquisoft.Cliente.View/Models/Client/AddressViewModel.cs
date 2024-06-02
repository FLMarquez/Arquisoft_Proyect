using Cervantes.Arquisoft.Domain.Entities;

namespace Cervantes.Arquisoft.View.Models
{
    using global::Cervantes.Arquisoft.Application.DTOs;
    using System.ComponentModel.DataAnnotations;

    namespace Cervantes.Arquisoft.View.Models
    {
        public class AddressViewModel
        {
            public int Id { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Dirección")]
            public string AddressLine { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Código Postal")]
            public string PostalCode { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Número")]
            public int Numbering { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Departamento")]
            public string Department { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Piso")]
            public string Floor { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Barrio")]
            public string Neighborhood { get; set; }

            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Provincia")]
            public IEnumerable<ProvinceDto>? ProvinceList { get; set; }


            [Required(ErrorMessage = "El campo {0} es requerido")]
            [Display(Name = "Localidad")]
            public IEnumerable<LocalityDto>? LocalitiesList { get; set; }

            public int ProvinceValue { get; set; }
            public int LocalityValue { get; set; }

            public string? AdditionalInstructions { get; set; }

            public static AddressDto FromViewModelToAddressDto(AddressViewModel model)
            {
                return new AddressDto
                {
                    AddressId = model.Id,
                    AddressLine = model.AddressLine,
                    PostalCode = model.PostalCode,
                    Numbering = model.Numbering,
                    Department = model.Department,
                    Floor = model.Floor,
                    Neighborhood = model.Neighborhood,
                    ProvinceId = model.ProvinceValue,
                    LocalityId = model.LocalityValue,
                    AdditionalInstructions = model.AdditionalInstructions
                };
            }

            public static AddressViewModel FromDtoToViewModel(AddressDto dto)
            {
                return new AddressViewModel
                {
                    Id = dto.AddressId,
                    AddressLine = dto.AddressLine,
                    PostalCode = dto.PostalCode,
                    Numbering = dto.Numbering,
                    Department = dto.Department,
                    Floor = dto.Floor,
                    Neighborhood = dto.Neighborhood,
                    ProvinceValue = dto.ProvinceId ?? 0,
                    LocalityValue = dto.LocalityId ?? 0,
                    AdditionalInstructions = dto.AdditionalInstructions
                };
            }

            public static IEnumerable<AddressViewModel> FromDtoToViewModel(IEnumerable<AddressDto> addressDtos)
            {
                return addressDtos.Select(FromDtoToViewModel);
            }

            public static AddressViewModel FromDtoToViewModel(Address dto)
            {
                return new AddressViewModel
                {
                    Id = dto.AddressId,
                    AddressLine = dto.AddressLine,
                    PostalCode = dto.PostalCode,
                    Numbering = dto.Numbering,
                    Department = dto.Department,
                    Floor = dto.Floor,
                    Neighborhood = dto.Neighborhood,
                    ProvinceValue = dto.ProvinceId ?? 0,
                    LocalityValue = dto.LocalityId ?? 0,
                    AdditionalInstructions = dto.AdditionalInstructions
                };
            }
        }
    }
}

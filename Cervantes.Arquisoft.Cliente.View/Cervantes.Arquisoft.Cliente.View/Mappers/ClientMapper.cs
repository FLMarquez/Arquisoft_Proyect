using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Models.Cervantes.Arquisoft.View.Models;

namespace Cervantes.Arquisoft.View.Mappers
{
    public class ClientMapper
    {
        public static ClientDto FromViewModelToDto(ClientViewModel model)
        {
            return new ClientDto
            {
                ClientId = model.Id,
                Name = model.Name,
                LastName = model.Lastname,
                DocumentNumber = model.DocumentNumber,
                Mail = model.Mail,
                Telephone = model.Telephone,
                AddressNavigation = AddressViewModel.FromViewModelToAddressDto(model.Address),
                AddressId = model.Address.Id
            };
        }

        public static ClientViewModel FromDtoToViewModel(ClientDto dto)
        {
            return new ClientViewModel
            {
                Id = dto.ClientId,
                Name = dto.Name,
                Lastname = dto.LastName,
                DocumentNumber = dto.DocumentNumber,
                Mail = dto.Mail,
                Telephone = dto.Telephone,
                Address = AddressViewModel.FromDtoToViewModel(dto.AddressNavigation),


            };
        }

        public static IEnumerable<ClientViewModel> FromDtoToViewModel(IEnumerable<ClientDto> clientDtos)
        {
            return clientDtos.Select(FromDtoToViewModel);
        }
    }
}

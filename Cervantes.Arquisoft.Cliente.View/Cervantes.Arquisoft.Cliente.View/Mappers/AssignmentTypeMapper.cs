using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.View.Models;


namespace Cervantes.Arquisoft.View.Mappers
{
    public class AssignmentTypeMapper
    {
        public static AssignmentTypeDTO FromViewModelToDto(AssignmentTypeViewModel model)
        {
            return new AssignmentTypeDTO
            {
                AssignmentTypeId = model.AssignmentTypeId,
                AssignmentTypeName = model.AssignmentTypeName,
                AssignmentTypeDescription = model.AssignmentTypeDescription,
                Order = (model.Order != null) ? (int)model.Order : 0,
                ServiceTypeId = model.ServiceTypeId,


            };
        }

        public static AssignmentTypeViewModel FromDtoToViewModel(AssignmentTypeDTO dto)
        {
            return new AssignmentTypeViewModel
            {
                AssignmentTypeId = dto.AssignmentTypeId,
                AssignmentTypeName = dto.AssignmentTypeName,
                AssignmentTypeDescription = dto.AssignmentTypeDescription,
                Order = dto.Order,
                ServiceTypeId = dto.ServiceTypeId,


            };
        }

        public static IEnumerable<AssignmentTypeViewModel> FromDtoToViewModel(IEnumerable<AssignmentTypeDTO> AssignmentTypeDtos)
        {
            return AssignmentTypeDtos.Select(FromDtoToViewModel);
        }
    }
}
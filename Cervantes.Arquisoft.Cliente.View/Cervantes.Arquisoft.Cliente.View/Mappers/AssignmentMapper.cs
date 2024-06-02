using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.View.Models;

namespace Cervantes.Arquisoft.View.Mappers
{
    public class AssignmentMapper
    {
        public static AssignmentDTO FromViewModelToDto(AssignmentViewModel model)
        {
            return new AssignmentDTO
            {
                AssignmentId = model.AssignmentId,
                ProjectId = model.ProjectId,
                AssignmentTypeId = model.AssignmentTypeId,
                AssignmentName = model.AssignmentName,
                AssignmentDescription = model.AssignmentDescription,
                IsCompleted = model.IsCompleted,
                NotVisible = model.NotVisible,
                IsStarted = model.IsStarted,
                IsSkipped = model.IsSkipped

            };
        }

        public static AssignmentViewModel FromDtoToViewModel(AssignmentDTO dto)
        {
            if (dto == null)
            {
                // Manejo de caso de objeto nulo
                return new AssignmentViewModel(); // O inicializa con valores predeterminados
            }


            return new AssignmentViewModel
            {
                AssignmentId = dto.AssignmentId,
                ProjectId = dto.ProjectId,
                AssignmentTypeId = dto.AssignmentTypeId,
                AssignmentName = dto.AssignmentName,
                AssignmentDescription = dto.AssignmentDescription,
                IsCompleted = dto.IsCompleted,
                NotVisible = dto.NotVisible,
                IsStarted = dto.IsStarted,
                IsSkipped = dto.IsSkipped

            };
        }

    }
}

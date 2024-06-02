using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ProjectStateSeed : IEntityTypeConfiguration<ProjectState>
    {
        public void Configure(EntityTypeBuilder<ProjectState> builder)
        {
            builder.HasData(
                new ProjectState { ProjectStateId = 1, Description = "Activo" },
                new ProjectState { ProjectStateId = 2, Description = "Inactivo" },
                new ProjectState { ProjectStateId = 3, Description = "Iniciado" },
                new ProjectState { ProjectStateId = 4, Description = "Completo" },
                new ProjectState { ProjectStateId = 5, Description = "En Espera" }
            );
        }
    }
}
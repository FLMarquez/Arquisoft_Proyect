using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ProjectSeed : IEntityTypeConfiguration<Cervantes.Arquisoft.Domain.Entities.Project>
    {
        public void Configure(EntityTypeBuilder<Cervantes.Arquisoft.Domain.Entities.Project> builder)
        {
            builder.HasData(
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 1, Name = "Casa en desnivel", UserId = 4, ClientId = 4, ServiceTypeId = 3, ProjectTypeId = 2, ProjectStateId = 4 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 2, Name = "Remodelación de oficina", UserId = 3, ClientId = 7, ServiceTypeId = 1, ProjectTypeId = 5, ProjectStateId = 1 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 3, Name = "Construcción de edificio residencial", UserId = 2, ClientId = 2, ServiceTypeId = 2, ProjectTypeId = 4, ProjectStateId = 5 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 4, Name = "Renovación de cocina", UserId = 4, ClientId = 5, ServiceTypeId = 1, ProjectTypeId = 1, ProjectStateId = 2 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 5, Name = "Ampliación de casa", UserId = 3, ClientId = 3, ServiceTypeId = 3, ProjectTypeId = 3, ProjectStateId = 3 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 6, Name = "Diseño de jardín", UserId = 2, ClientId = 9, ServiceTypeId = 1, ProjectTypeId = 2, ProjectStateId = 4 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 7, Name = "Proyecto de infraestructura vial", UserId = 4, ClientId = 1, ServiceTypeId = 2, ProjectTypeId = 5, ProjectStateId = 5 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 8, Name = "Construcción de centro comercial", UserId = 2, ClientId = 6, ServiceTypeId = 3, ProjectTypeId = 4, ProjectStateId = 4 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 9, Name = "Remodelación de baño", UserId = 3, ClientId = 8, ServiceTypeId = 1, ProjectTypeId = 3, ProjectStateId = 3 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 10, Name = "Casa en la playa", UserId = 4, ClientId = 10, ServiceTypeId = 2, ProjectTypeId = 1, ProjectStateId = 1 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 11, Name = "Proyecto de desarrollo de software", UserId = 2, ClientId = 2, ServiceTypeId = 3, ProjectTypeId = 2, ProjectStateId = 2 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 12, Name = "Construcción de hotel", UserId = 3, ClientId = 3, ServiceTypeId = 2, ProjectTypeId = 4, ProjectStateId = 4 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 13, Name = "Renovación de fachada", UserId = 4, ClientId = 5, ServiceTypeId = 1, ProjectTypeId = 5, ProjectStateId = 5 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 14, Name = "Construcción de parque temático", UserId = 3, ClientId = 9, ServiceTypeId = 3, ProjectTypeId = 3, ProjectStateId = 3 },
                new Cervantes.Arquisoft.Domain.Entities.Project { ProjectId = 15, Name = "Remodelación de local comercial", UserId = 2, ClientId = 1, ServiceTypeId = 1, ProjectTypeId = 1, ProjectStateId = 1 }
            );
        }
    }
}
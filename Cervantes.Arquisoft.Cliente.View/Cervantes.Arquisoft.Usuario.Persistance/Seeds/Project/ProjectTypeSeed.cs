using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cervantes.Arquisoft.Data.Seeds.Project
{
    public class ProjectTypeSeed : IEntityTypeConfiguration<ProjectType>
    {
        public void Configure(EntityTypeBuilder<ProjectType> builder)
        {
            builder.HasData(
                new ProjectType { ProjectTypeId = 1, ProjectTypeName = "ProjectTypeName1", ProjectTypeDescription = "ProjectTypeDesc1", RangeMax = 10, RangeMin = 1, ProfessionalFee = 200 },
                new ProjectType { ProjectTypeId = 2, ProjectTypeName = "ProjectTypeName2", ProjectTypeDescription = "ProjectTypeDesc2", RangeMax = 20, RangeMin = 10, ProfessionalFee = 300 }


            );
        }
    }
}

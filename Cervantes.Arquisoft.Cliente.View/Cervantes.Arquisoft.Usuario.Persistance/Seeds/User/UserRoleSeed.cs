using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class UserRoleSeed : IEntityTypeConfiguration<UserRole>
    {
        public void Configure(EntityTypeBuilder<UserRole> builder)
        {
            builder.HasData(
                new UserRole { UserRoleId = 1, Description = "Admin" },
                new UserRole { UserRoleId = 2, Description = "Usuario" },
                new UserRole { UserRoleId = 3, Description = "Soporte" },
                new UserRole { UserRoleId = 4, Description = "Técnico" },
                new UserRole { UserRoleId = 5, Description = "Visitante" }
            );
        }
    }
}
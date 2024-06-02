using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class UserStateSeed : IEntityTypeConfiguration<UserState>
    {
        public void Configure(EntityTypeBuilder<UserState> builder)
        {
            builder.HasData(
                new UserState { UserStateId = 1, Description = "Activo" },
                new UserState { UserStateId = 2, Description = "Inactivo" }
            );
        }
    }
}
using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ClientRoleSeed : IEntityTypeConfiguration<ClientRole>
    {
        public void Configure(EntityTypeBuilder<ClientRole> builder)
        {
            builder.HasData(
                new ClientRole {ClientRoleId = 1, Description = "Cliente"}
            );
        }
    }
}
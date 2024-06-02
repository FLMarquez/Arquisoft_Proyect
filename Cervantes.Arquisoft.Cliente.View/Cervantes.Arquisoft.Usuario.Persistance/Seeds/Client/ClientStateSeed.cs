using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ClientStateSeed : IEntityTypeConfiguration<ClientState>
    {
        public void Configure(EntityTypeBuilder<ClientState> builder)
        {
            builder.HasData(
                new ClientState { ClientStateId = 1, Description = "Activo" },
                new ClientState { ClientStateId = 2, Description = "Inactivo" }
            );
        }
    }
}
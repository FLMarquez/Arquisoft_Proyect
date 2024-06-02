using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using global::Cervantes.Arquisoft.Domain.Entities;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ProvinceSeed : IEntityTypeConfiguration<Province>
    {
        public void Configure(EntityTypeBuilder<Province> builder)
        {
            builder.HasData(
                new Province { ProvinceId = 1, Description = "Buenos Aires" },
                new Province { ProvinceId = 2, Description = "Catamarca" },
                new Province { ProvinceId = 3, Description = "Chaco" },
                new Province { ProvinceId = 4, Description = "Chubut" },
                new Province { ProvinceId = 5, Description = "Córdoba" },
                new Province { ProvinceId = 6, Description = "Corrientes" },
                new Province { ProvinceId = 7, Description = "Entre Ríos" },
                new Province { ProvinceId = 8, Description = "Formosa" },
                new Province { ProvinceId = 9, Description = "Jujuy" },
                new Province { ProvinceId = 10, Description = "La Pampa" },
                new Province { ProvinceId = 11, Description = "La Rioja" },
                new Province { ProvinceId = 12, Description = "Mendoza" },
                new Province { ProvinceId = 13, Description = "Misiones" },
                new Province { ProvinceId = 14, Description = "Neuquén" },
                new Province { ProvinceId = 15, Description = "Río Negro" },
                new Province { ProvinceId = 16, Description = "Salta" },
                new Province { ProvinceId = 17, Description = "San Juan" },
                new Province { ProvinceId = 18, Description = "San Luis" },
                new Province { ProvinceId = 19, Description = "Santa Cruz" },
                new Province { ProvinceId = 20, Description = "Santa Fe" },
                new Province { ProvinceId = 21, Description = "Santiago del Estero" },
                new Province { ProvinceId = 22, Description = "Tierra del Fuego" },
                new Province { ProvinceId = 23, Description = "Tucumán" }
            );
        }
    }
}
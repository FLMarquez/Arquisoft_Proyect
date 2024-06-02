using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;


namespace Cervantes.Arquisoft.Data.Seeds
{
    public class AddressSeed : IEntityTypeConfiguration<Address>
    {
        public void Configure(EntityTypeBuilder<Address> builder)
        {
            builder.HasData(
                new Address { AddressId = 1, AddressLine = "Boyero", PostalCode = "5000", Numbering = 528, Department = "1", Floor = "1", Neighborhood = "Chateau Carreras", ProvinceId = 5, LocalityId = 3, AdditionalInstructions = null },
                new Address { AddressId = 2, AddressLine = "Cerrito", PostalCode = "5000", Numbering = 173, Department = "1", Floor = "1", Neighborhood = "Arguello", ProvinceId = 5, LocalityId = 3, AdditionalInstructions = null },
                new Address { AddressId = 3, AddressLine = "Chancay", PostalCode = "5003", Numbering = 1401, Department = "1", Floor = "1", Neighborhood = "Observatorio", ProvinceId = 5, LocalityId = 2, AdditionalInstructions = null },
                new Address { AddressId = 4, AddressLine = "San Martín", PostalCode = "5000", Numbering = 867, Department = "1", Floor = "1", Neighborhood = "San Vicente", ProvinceId = 7, LocalityId = 5, AdditionalInstructions = null },
                new Address { AddressId = 5, AddressLine = "9 de Julio", PostalCode = "5010", Numbering = 422, Department = "1", Floor = "1", Neighborhood = "San Martín", ProvinceId = 8, LocalityId = 4, AdditionalInstructions = null },
                new Address { AddressId = 6, AddressLine = "25 de Mayo", PostalCode = "5800", Numbering = 8, Department = "1", Floor = "1", Neighborhood = "9 de Julio", ProvinceId = 3, LocalityId = 3, AdditionalInstructions = null },
                new Address { AddressId = 7, AddressLine = "Rosario", PostalCode = "5125", Numbering = 914, Department = "1", Floor = "1", Neighborhood = "Bella Vista", ProvinceId = 2, LocalityId = 4, AdditionalInstructions = null },
                new Address { AddressId = 8, AddressLine = "Colon", PostalCode = "4052", Numbering = 777, Department = "1", Floor = "1", Neighborhood = "Quintana", ProvinceId = 1, LocalityId = 3, AdditionalInstructions = null },
                new Address { AddressId = 9, AddressLine = "Salta", PostalCode = "3582", Numbering = 1522, Department = "1", Floor = "1", Neighborhood = "Belgrano", ProvinceId = 1, LocalityId = 2, AdditionalInstructions = null },
                new Address { AddressId = 10, AddressLine = "Jujuy", PostalCode = "5008", Numbering = 4006, Department = "1", Floor = "1", Neighborhood = "Palermo", ProvinceId = 9, LocalityId = 1, AdditionalInstructions = null }

            );
        }
    }
}
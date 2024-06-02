using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cervantes.Arquisoft.Data.Seeds
{
    internal class PaymentMethodsSeed : IEntityTypeConfiguration <PaymentMethod>
    {
        public void Configure(EntityTypeBuilder<PaymentMethod> builder)
        {
            builder.HasData(
                new PaymentMethod { PaymentMethodId = 1, MethodName = "Efectivo" },
                new PaymentMethod { PaymentMethodId = 2, MethodName = "Transferencia" },
                new PaymentMethod { PaymentMethodId = 3, MethodName = "Débito" }
                
            );
        }

        
}
}

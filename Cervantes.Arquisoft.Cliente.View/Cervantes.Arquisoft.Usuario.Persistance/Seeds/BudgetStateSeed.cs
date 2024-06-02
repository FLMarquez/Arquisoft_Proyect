using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class BudgetStateSeed : IEntityTypeConfiguration<BudgetState>
    {
        public void Configure(EntityTypeBuilder<BudgetState> builder)
        {
            builder.HasData(
                new BudgetState { BudgetStateId = 1, BudgetStateDescription = "Revisión" },
                new BudgetState { BudgetStateId = 2, BudgetStateDescription = "Finalizado" },
                new BudgetState { BudgetStateId = 3, BudgetStateDescription = "Aprobado" },
                new BudgetState { BudgetStateId = 4, BudgetStateDescription = "Pagado" }
            );
        }
    }
}
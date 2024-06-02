using Cervantes.Arquisoft.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IBudgetStateRepository
    {
        Task Create(BudgetStateDTO budgetStateDto);
        Task Delete(int budgetStateId);
        Task<bool> Exist(string budgetDescipcion);
        Task<IEnumerable<BudgetStateDTO>> GetAll();
        Task<BudgetStateDTO> GetById(int budgetStateId);

        Task Update(BudgetStateDTO budgetStateDto);
    }
}

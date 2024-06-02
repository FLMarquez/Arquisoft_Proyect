using Cervantes.Arquisoft.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IBudgetRepository
    {
        Task Create(BudgetDTO budgetDto);
        Task Delete(int budgetId);
        Task<bool> Exist(string projectName);
        Task<IEnumerable<BudgetDTO>> GetAll();
        Task<BudgetDTO> GetById(int budgetId);

        Task Update(BudgetDTO budgetDto);
    }
}

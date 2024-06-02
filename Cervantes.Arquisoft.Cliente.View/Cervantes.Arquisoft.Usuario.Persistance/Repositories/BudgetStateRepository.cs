using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class BudgetStateRepository : IBudgetStateRepository
    {
        private readonly string connectionString;

        public BudgetStateRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }
        public Task Create(BudgetStateDTO budgetStateDto)
        {
            throw new NotImplementedException();
        }

        public Task Delete(int budgetStateId)
        {
            throw new NotImplementedException();
        }

        public Task<bool> Exist(string budgetDescipcion)
        {
            throw new NotImplementedException();
        }

        public Task<IEnumerable<BudgetStateDTO>> GetAll()
        {
            throw new NotImplementedException();
        }

        public Task<BudgetStateDTO> GetById(int budgetStateId)
        {
            throw new NotImplementedException();
        }

        public Task Update(BudgetStateDTO budgetStateDto)
        {
            throw new NotImplementedException();
        }
    }
}

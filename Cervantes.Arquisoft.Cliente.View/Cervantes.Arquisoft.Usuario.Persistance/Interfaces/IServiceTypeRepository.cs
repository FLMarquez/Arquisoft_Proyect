using Cervantes.Arquisoft.Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IServiceTypeRepository
    {
        Task Create(ServiceTypeDto serviceTypeDto);
        Task Delete(int id);
        Task<IEnumerable<ServiceTypeDto>> GetAll();
        Task<ServiceTypeDto> GetById(int id);
        Task Update(ServiceTypeDto serviceTypeDto);
        Task<bool> Exist(string name);
        Task<string> GetServiceTypeNameById(int id);
    }
}

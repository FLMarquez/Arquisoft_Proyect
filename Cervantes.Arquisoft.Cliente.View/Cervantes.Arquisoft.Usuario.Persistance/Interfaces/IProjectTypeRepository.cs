using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IProjectTypeRepository
    {
        Task Create(ProjectType projectTypeDTO);
        Task Delete(int id);
        Task<IEnumerable<ProjectTypeDTO>> GetAll();
        Task<ProjectTypeDTO> GetById(int id);
        Task Update(ProjectType projectTypeDTO);

        Task<bool> Exist(string name);
    }
}
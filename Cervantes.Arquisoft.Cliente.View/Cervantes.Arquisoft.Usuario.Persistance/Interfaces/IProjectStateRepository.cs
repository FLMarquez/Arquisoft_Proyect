using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IProjectStateRepository
    {
        Task Create(ProjectStateDto projectStateDto);
        Task Delete(int dni);
        Task<bool> Exist(int dni);
        Task<IEnumerable<ProjectStateDto>> GetAll();
        Task<ProjectStateDto> GetById(int dni);
        Task Update(ProjectStateDto projectStateDto);
    }
}

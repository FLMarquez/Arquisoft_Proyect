using Cervantes.Arquisoft.Application.DTOs;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IUserRepository
    {
        Task Create(UserDto userDto);
        Task Delete(int userId);
        Task<bool> Exist(int documentNumber);
        Task<IEnumerable<UserDto>> GetAll();
        Task<UserDto> GetById(int userId);
        Task Update(UserDto userDto);
    }
}

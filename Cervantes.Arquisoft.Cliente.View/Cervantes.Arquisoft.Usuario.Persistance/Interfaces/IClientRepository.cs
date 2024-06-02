using Cervantes.Arquisoft.Application.DTOs;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IClientRepository
    {
        Task Create(ClientDto clientDto);
        Task Delete(int dni);
        Task<bool> Exist(int dni);
        Task<IEnumerable<ClientDto>> GetAll();
        Task<ClientDto> GetById(int dni);
        Task Update(ClientDto clientDto);
    }
}
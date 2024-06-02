using Cervantes.Arquisoft.Application.DTOs;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IClientDashboardRepository
    {
        Task<IEnumerable<ClientDashboardDTO>> GetAllClientDashboard(int clientId);
    }
}


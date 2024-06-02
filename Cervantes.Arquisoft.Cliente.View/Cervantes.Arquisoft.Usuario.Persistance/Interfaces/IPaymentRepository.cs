using Cervantes.Arquisoft.Application.DTOs;



namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IPaymentRepository
    {

        Task Create(PaymentDTO paymentDto);
        Task<IEnumerable<PaymentDTO>> GetAll();
        Task<PaymentDTO> GetById(int id);
        Task<IEnumerable<PaymentDTO>> GetPaymentByProjectId(int id);
        Task<bool> Exist(int id);
        Task DeleteWithReason(int hubId, string deletedReason);
        Task<int> GetLastId();
    }
}
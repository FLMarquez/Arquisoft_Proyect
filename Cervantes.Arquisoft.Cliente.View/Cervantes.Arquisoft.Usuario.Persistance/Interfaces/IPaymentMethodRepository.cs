using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Application.DTOs.Budget;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Data.Interfaces
{
    public interface IPaymentMethodRepository
    {
        Task<IEnumerable<PaymentMethodDTO>> GetAll();
        Task<PaymentMethodDTO> GetById(int id);
        Task<PaymentMethodDTO> GetByProjectId(int id);
        Task<PaymentMethodDTO> GetMethodByPaymentId(int id);
    }
}

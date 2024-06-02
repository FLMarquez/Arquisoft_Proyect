using Cervantes.Arquisoft.Application.DTOs.Budget;
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models
{
    public class PaymentViewModel
    {
        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Monto")]
        [Range(0.01, double.MaxValue, ErrorMessage = "El campo {0} debe ser mayor que cero.")]

        public decimal Amount { get; set; }
        public decimal Balance { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal ProjectBudget { get; set; }
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public string? MethodName { get; set; }

        public bool IsDeleted { get; set; }
        public string? DeletedReason { get; set; }

        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Metodo de Pago")]
        public IEnumerable<PaymentMethodDTO> PaymentMethodList { get; set; }
        [Required(ErrorMessage = "El campo {0} es requerido")]
        [Display(Name = "Metodo de Pago")]
        public int? PaymentMethodValue { get; set; }




    }
    public class PaymentMethodViewModelList
    {
        public int ProjectId { get; set; }
        public string? ProjectName { get; set; }
        public decimal ProjectBudget { get; set; }
        public decimal TotalBalance { get; set; }
        public decimal TotalAmount { get; set; }

        public string ClientName { get; set; }

        public IEnumerable<PaymentViewModel> PaymentList { get; set; }
    }
}
using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Payment
    {


        [Key]
        public int PaymentId { get; set; }
        public int? BudgetId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public int ProjectId { get; set; }
        public bool? IsDeleted { get; set; }
        public string? DeletedReason { get; set; }


    }
}
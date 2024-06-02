using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class PaymentMethod
    {
        [Key]
        public int PaymentMethodId { get; set; }
        public string MethodName { get; set; }
    }
}

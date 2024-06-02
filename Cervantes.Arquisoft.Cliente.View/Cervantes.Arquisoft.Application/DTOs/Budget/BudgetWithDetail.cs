namespace Cervantes.Arquisoft.Application.DTOs
{
    public class BudgetWithDetailDTO
    {
        public int BudgetId { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime DueDate { get; set; }
        public string BudgetDesciption { get; set; }
        public decimal AmountBudget { get; set; }
        public int BudgetStateId { get; set; }

    }
}
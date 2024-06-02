using Cervantes.Arquisoft.Domain.Entities;

namespace Cervantes.Arquisoft.View.Models
{
    public class BudgetViewModel
    {
        public int BudgetId { get; set; }
        public int ProjectId { get; set; }
        public int ProjectTypeId { get; set; }
        public int ServiceTypeId { get; set; }
        public int ClientId { get; set; }
        public int UserId { get; set; }
        public DateTime EmissionDate { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectSquareMeters { get; set; }
        public int CostPerSquareMeters { get; set; }
        public string BudgetDesciption { get; set; }
        public int BudgetStateId { get; set; }

        public ServiceType ServiceType { get; set; }
        public Project Project { get; set; }
        public Client Client { get; set; }
        public User User { get; set; }
        public ProjectType ProjectType { get; set; }
        public BudgetState BudgetState { get; set; }
    }
}

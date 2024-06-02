namespace Cervantes.Arquisoft.Domain.Entities.Budget
{
    public class Budget
    {
        //Presupues
        //    IdProyecto int
        //    Idpresupuesto int
        //    FechaDeCreacion datetime
        //    Fechavto datetime
        //    Precioporm2 decimal (18,2)
        //    M2 double o int no estoy seguro
        //Totalpresupuesto decimal (18,2)

        public int BudgetId { get; set; }
        public int ProjectId { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime DueDate { get; set; }
        public int ProjectSquareMeters { get; set; }
        public int CostPerSquareMeters { get; set; }
        public string BudgetDescription { get; set; }
        public int BudgetStateId { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cervantes.Arquisoft.Application.DTOs.Budget
{
    public class ProjectPaymentsDetailsDTO
    {
        public int PaymentId { get; set; }
        public int PaymentMethodId { get; set; }
        public decimal Amount { get; set; }
        public DateTime PaymentDate { get; set; }
        public decimal ProjectBudget { get; set; }
        
        //Proyecto/////////////////////////////
        public int ProjectId { get; set; }
        public string ProjectName { get; set; }
        public decimal Budget { get; set; }
        public int ProjectStateId { get; set; }
        public string StateDescription { get; set; }


        //Usuarios/////////////////////////////
        public int UserId { get; set; }
        public string UserName { get; set; }
        public string UserLastName { get; set; }
        
        //Clientes/////////////////////////////
        public int ClientId { get; set; }
        public string ClientName { get; set; }
        public string ClientLastName { get; set; }

        //TIpologia/////////////////////////////
        public int ProjectTypeId { get; set; }
        public string ProjectTypeName { get; set; }
        public int RangeMax { get; set; }
        public int RangeMin { get; set; }
        public decimal ProfessionalFee { get; set; }

        //Servicios/////////////////////////////
        public int ServiceTypeId { get; set; }
        public string ServiceTypeName { get; set; }
        public string ServiceTypeDescription { get; set; }

    }
}

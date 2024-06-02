using Cervantes.Arquisoft.Domain.Entities;
using static Cervantes.Arquisoft.Data.Repositories.StadisticsRepository;


namespace Cervantes.Arquisoft.View.Models
{

    public class DashboardUserViewModel
    {
        public List<UserCountByType> UsuariosHistoricosPorEstado { get; set; }
        public List<UserCountByType> UsuariosActivosPorEstados { get; set; }
        public List<ProjectCountByType> ProyectosPorTipo { get; set; }
        public List<ClientCountByType> ClientesActivosPorEstado { get; set; }
        public List<ClientCountByType> ClientesHistoricosPorEstado { get; set; }
        public string NombreUltimoCliente { get; set; }
        public string NombreUltimoUsuario { get; set; }
        public string NombreUltimoProyecto { get; set; }
        public Dictionary<string, double> PorcentajeProyectosPorTipo { get; set; }

        public IEnumerable<DataProjectStateDTO> DataProjectStateList { get; set; }
        public IEnumerable<DataProjectTypeDTO> DataProjectTypeList { get; set; }

        public IEnumerable<Amount_Method> Amount_MethodList { get; set; }
        public IEnumerable<ProjectType_Amount> ProjectType_AmountList { get; set; }
        public IEnumerable<Amount_Time> Amount_TimeList { get; set; }


    }
}



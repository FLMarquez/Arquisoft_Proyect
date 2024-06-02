using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using static Cervantes.Arquisoft.Data.Repositories.StadisticsRepository;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public interface IStadisticsRepository
    {
        List<UserCountByType> GetCantidadUsuariosPorEstado();
        List<ProjectCountByType> GetCantidadProyectosPorEstado();
        List<ClientCountByType> GetCantidadClientesPorEstado();
        string GetNombreUltimoCliente();
        string GetNombreUltimoUsuario();
        string GetNombreUltimoProyecto();
        List<UserCountByType> GetCantidadUsuariosActivosPorEstado();
        List<ClientCountByType> GetCantidadClientesActivosPorEstado();
        Dictionary<string, double> CalcularPorcentajeProyectosPorTipo();

    }

    public class StadisticsRepository : IStadisticsRepository
    {
        private readonly string connectionString;

        public StadisticsRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public class UserCountByType
        {
            public string UserType { get; set; }
            public int Count { get; set; }
        }

        public class ClientCountByType
        {
            public string ClientType { get; set; }
            public int Count { get; set; }
        }

        public class ProjectCountByType
        {
            public string ProjectType { get; set; }
            public int Count { get; set; }
        }

        public List<UserCountByType> GetCantidadUsuariosPorEstado()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT UserRoles.Description AS UserType, COUNT(*) AS Count
                           FROM Users
                           LEFT JOIN UserRoles ON Users.UserRoleId = UserRoles.UserRoleId
                           GROUP BY UserRoles.Description";
            return conn.Query<UserCountByType>(sql).ToList();
        }

        public List<UserCountByType> GetCantidadUsuariosActivosPorEstado()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"
SELECT UserRoles.Description AS UserType, COUNT(*) AS Count
                           FROM Users
                           LEFT JOIN UserRoles ON Users.UserRoleId = UserRoles.UserRoleId where UserStateId = 1
                           GROUP BY UserRoles.Description";
            return conn.Query<UserCountByType>(sql).ToList();
        }

        public List<ProjectCountByType> GetCantidadProyectosPorEstado()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT ProjectState.Description AS ProjectType, COUNT(*) AS Count
                        FROM Projects
                        LEFT JOIN ProjectState ON Projects.ProjectStateId = ProjectState.ProjectStateId
                        GROUP BY ProjectState.Description ORDER BY ProjectState.Description ASC;";
            return conn.Query<ProjectCountByType>(sql).ToList();
        }

        public List<ClientCountByType> GetCantidadClientesPorEstado()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT cs.Description AS ClientType, COUNT(*) AS Count
                    FROM Clients c
                    LEFT JOIN ClientStates cs ON c.ClientStateId = cs.ClientStateId
                    GROUP BY cs.Description";
            return conn.Query<ClientCountByType>(sql).ToList();
        }

        public List<ClientCountByType> GetCantidadClientesActivosPorEstado()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT cs.Description AS ClientType, COUNT(*) AS Count
FROM Clients c
LEFT JOIN ClientStates cs ON c.ClientStateId = cs.ClientStateId
WHERE c.ClientStateId = 1
GROUP BY cs.Description;";
            return conn.Query<ClientCountByType>(sql).ToList();
        }

        public string GetNombreUltimoCliente()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT TOP 1 Name, LastName
                           FROM Clients
                           ORDER BY ClientId DESC";
            var result = conn.QueryFirstOrDefault(sql);
            if (result != null)
            {
                string name = result.Name;
                string lastName = result.LastName;
                return $"{name} {lastName}";
            }
            return string.Empty;
        }

        public string GetNombreUltimoUsuario()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT TOP 1 Name, LastName, Description
                           FROM Users
                           LEFT JOIN UserRoles ON Users.UserRoleId = UserRoles.UserRoleId
                           ORDER BY UserId DESC";
            var result = conn.QueryFirstOrDefault(sql);
            if (result != null)
            {
                string name = result.Name;
                string lastName = result.LastName;
                string role = result.Description ?? string.Empty;
                return $"{name} {lastName} ({role})";
            }
            return string.Empty;
        }

        public string GetNombreUltimoProyecto()
        {
            using var conn = new SqlConnection(connectionString);

            string sql = @"SELECT TOP 1 Name
                           FROM Projects
                           ORDER BY ProjectId DESC";
            return conn.QueryFirstOrDefault<string>(sql) ?? string.Empty;
        }





        public Dictionary<string, double> CalcularPorcentajeProyectosPorTipo()
        {
            List<ProjectCountByType> proyectosTotales = GetCantidadProyectosPorEstado();

            int proyectosTotalesTotal = proyectosTotales.Sum(p => p.Count);

            if (proyectosTotalesTotal == 0)
            {
                return new Dictionary<string, double>();
            }

            Dictionary<string, double> porcentajesPorTipo = new Dictionary<string, double>();

            foreach (var proyecto in proyectosTotales)
            {
                double porcentaje = (double)proyecto.Count / proyectosTotalesTotal * 100;
                string porcentajeFormateado = porcentaje.ToString("0.00"); // Establece el formato para dos decimales
                porcentajesPorTipo.Add(proyecto.ProjectType, double.Parse(porcentajeFormateado));
            }

            return porcentajesPorTipo;
        }

    }
}

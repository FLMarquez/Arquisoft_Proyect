using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Domain.Entities;
using Dapper;
using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Data.Repositories
{
    public class ClientRepository : IClientRepository
    {
        private readonly string connectionString;

        public ClientRepository(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        public async Task Create(ClientDto client)
        {

            using var conn = new SqlConnection(connectionString);
            client.Password = client.DocumentNumber;
            client.ClientRoleId = 1;
            client.ClientStateId = 1;
            try
            {
                var addressId = await conn.QuerySingleAsync<int>(@"
            INSERT INTO Addresses (AddressLine, PostalCode, Numbering, Department, Floor, Neighborhood, ProvinceId, LocalityId, AdditionalInstructions)
            VALUES (@AddressLine, @PostalCode, @Numbering, @Department, @Floor, @Neighborhood, @ProvinceId, @LocalityId, @AdditionalInstructions);
            SELECT SCOPE_IDENTITY();", client.AddressNavigation);

                client.AddressId = addressId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de inserción de la direccion del cliente: " + ex.Message);
            }
            try
            {
                var clientId = await conn.QuerySingleAsync<int>(@"
            INSERT INTO Clients (Name, LastName, Password, DocumentNumber, Mail, Telephone, ClientStateId, ClientRoleId, PreferencesId, AddressId)
            VALUES (@Name, @LastName, @Password, @DocumentNumber, @Mail, @Telephone, @ClientStateId, @ClientRoleId, @PreferencesId, @AddressId);
            SELECT SCOPE_IDENTITY();", client);

                client.ClientId = clientId;
            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta de inserción del cliente: " + ex.Message);
            }



        }

        public async Task<bool> Exist(int dni)
        {

            try
            {
                using var conn = new SqlConnection(connectionString);
                var result = await conn.QueryFirstOrDefaultAsync<int>(@"
                SELECT 1 FROM Clients WHERE DocumentNumber = @Dni AND ClientStateId = 1;", new { dni });
                Console.WriteLine("Consulta Exist: " + result);
                return result == 1;

            }
            catch (Exception ex)
            {
                Console.WriteLine("Error al ejecutar la consulta Exist: " + ex.Message);
            }
            return false;

        }

        public async Task<IEnumerable<ClientDto>> GetAll()
        {
            using var conn = new SqlConnection(connectionString);
            var query = @"
                 SELECT * FROM Clients
                 JOIN Addresses ON Clients.AddressId = Addresses.AddressId
                 WHERE Clients.ClientStateId != 2
                 ORDER BY LastName ASC, NAME ASC"; // Excluir clientes eliminados

            var clients = await conn.QueryAsync<ClientDto, Address, ClientDto>(query,
                (client, address) =>
                {
                    client.AddressNavigation = address;
                    return client;
                },
                splitOn: "AddressId");

            return clients;
        }

        public async Task Update(ClientDto client)
        {
            using var conn = new SqlConnection(connectionString);

            try
            {
                var result1 = await conn.ExecuteAsync(@"
            UPDATE Addresses
            SET ProvinceId = @ProvinceId, LocalityId = @LocalityId,
            AddressLine = @AddressLine, PostalCode = @PostalCode, Numbering = @Numbering,
            Department = @Department, Floor = @Floor, Neighborhood = @Neighborhood, AdditionalInstructions = @AdditionalInstructions
            WHERE AddressId = @AddressId", client.AddressNavigation);

                Console.WriteLine($"{nameof(Update)} - Filas afectadas en la consulta 1: {result1}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(Update)} - Error en la modificación de la dirección del cliente: {ex.Message}");
            }

            try
            {
                var result2 = await conn.ExecuteAsync(@"
            UPDATE Clients
            SET Name = @Name, LastName = @LastName, DocumentNumber = @DocumentNumber,
            Mail = @Mail, Telephone = @Telephone
            WHERE ClientId = @ClientId", client);

                Console.WriteLine($"{nameof(Update)} - Filas afectadas en la consulta 2: {result2}");
            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(Update)} - Error en la modificación del cliente: {ex.Message}");
            }
        }



        public async Task Delete(int id)
        {
            using var conn = new SqlConnection(connectionString);
            try
            {
                await conn.ExecuteAsync(@"
                UPDATE Clients SET CLientStateId = 2 WHERE ClientId = @id",
                    new { id }); //TODO Actualizar el estado del cliente a "2" (eliminado)

            }
            catch (Exception ex)
            {
                Console.WriteLine($"{nameof(Delete)} - Error en la modificación del cliente: {ex.Message}");
            }
        }

        public async Task<ClientDto> GetById(int id)
        {
            using var conn = new SqlConnection(connectionString);
            try
            {
                var addressQuery = @"
        SELECT * FROM Addresses
        WHERE AddressId = (SELECT AddressId FROM Clients WHERE ClientId = @Id)";

                var clientQuery = @"
        SELECT * FROM Clients
        WHERE ClientId = @Id";

                var address = await conn.QueryFirstOrDefaultAsync<Address>(addressQuery, new { Id = id });
                var client = await conn.QueryFirstOrDefaultAsync<ClientDto>(clientQuery, new { Id = id });

                var clientDto = FromQueryToClientAddres(client, address);

                return clientDto;
            }
            catch (Exception ex)
            {
                Console.WriteLine($" Error en Get Client By Id: {ex.Message}");
            }
            return null;
        }


        private ClientDto FromQueryToClientAddres(Client client, Address address)
        {
            var clientDto = new ClientDto
            {
                ClientId = client.ClientId,
                Name = client.Name,
                LastName = client.LastName,
                Password = client.Password,
                DocumentNumber = client.DocumentNumber,
                Mail = client.Mail,
                Telephone = client.Telephone,
                ClientStateId = client.ClientStateId,
                ClientRoleId = client.ClientRoleId,
                PreferencesId = client.PreferencesId,
                AddressId = client.AddressId,
                AddressNavigation = address
            };

            return clientDto;
        }
    }
}

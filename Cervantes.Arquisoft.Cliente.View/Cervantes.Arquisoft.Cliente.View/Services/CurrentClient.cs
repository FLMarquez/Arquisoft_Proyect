using Cervantes.Arquisoft.Application.DTOs;

namespace Cervantes.Arquisoft.View.Services
{
    public interface ICurrentClientService
    {
        ClientFromService GetCurrentClient();
        void SetCurrentClient(ClientDto client);
    }

    public class CurrentClientService : ICurrentClientService
    {
        private ClientFromService currentClient;

        public ClientFromService GetCurrentClient()
        {
            Console.WriteLine(currentClient);

            return currentClient;
        }

        public void SetCurrentClient(ClientDto client)
        {
            if (client != null)
            {
                currentClient = MapClientToClientFromService(client);
            }
            else
            {
                currentClient = null;
            }
        }

        private ClientFromService MapClientToClientFromService(ClientDto client)
        {
            return new ClientFromService
            {
                CurrentClientId = client.ClientId.ToString(),
                CurrentClientFirstName = client.Name,
                CurrentClientLastName = client.LastName,
                CurrentClientRole = client.ClientRoleId.ToString(),
                CurrentClientEmail = client.Mail
            };
        }
    }
}
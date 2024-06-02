namespace Cervantes.Arquisoft.Domain.Entities
{
    public class ClientRegister
    {

        public int ClientRegisterId { get; set; }
        public DateTime Date { get; set; }
        // Otras propiedades del registro
        public string Description { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}

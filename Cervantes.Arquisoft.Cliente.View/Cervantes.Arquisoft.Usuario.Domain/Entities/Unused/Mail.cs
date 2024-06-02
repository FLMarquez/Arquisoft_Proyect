namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Mail
    {
        public int MailId { get; set; }
        public string State { get; set; }
        public string MailText { get; set; }

        // Clave externa para el usuario
        public int UserId { get; set; }
        public User User { get; set; }

        // Clave externa para el cliente
        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}
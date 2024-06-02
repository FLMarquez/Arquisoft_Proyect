namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Message
    {

        public int MessageId { get; set; }
        public string Text { get; set; }
        public DateTime Date { get; set; }

        public int UserId { get; set; }
        public User User { get; set; }

        public int ClientId { get; set; }
        public Client Client { get; set; }

    }
}

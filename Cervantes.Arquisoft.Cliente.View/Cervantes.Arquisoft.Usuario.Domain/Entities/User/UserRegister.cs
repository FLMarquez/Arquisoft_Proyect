namespace Cervantes.Arquisoft.Domain.Entities
{
    public class UserRegister
    {

        public int UserRegisterId { get; set; }
        public DateTime Date { get; set; }

        public string Description { get; set; }
        public int UserId { get; set; }
        public User User { get; set; }

    }
}

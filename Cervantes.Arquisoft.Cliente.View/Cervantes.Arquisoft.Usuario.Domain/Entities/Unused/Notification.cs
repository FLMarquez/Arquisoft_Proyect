namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Notification
    {
        public int NotificationId { get; set; }
        public string Message { get; set; }
        public DateTime Date { get; set; }

        public int ProjectId { get; set; }
        public virtual Project Project { get; set; }
    }
}

namespace Cervantes.Arquisoft.View.Models.Assignment
{
    public class CommentViewModel
    {
        public int CommentId { get; set; }
        public int AssignmentId { get; set; }
        public DateTime CommentCreatedDate { get; set; }
        public DateTime CommentEditedDate { get; set; }
        public bool IsEdited { get; set; }
        public string CommentText { get; set; }
        public int UserId { get; set; }
        public int ClientId { get; set; }
        public string UserFullName { get; set; }
        public string ClientFullName { get; set; }
        public bool IsUserSender { get; set; }

    }
}

using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Hub
    {
        //General
        [Key]
        public int HubId { get; set; }
        public int AssignmentId { get; set; }
        public DateTime HubDate { get; set; }

        //Commitment
        public bool IsCommitment { get; set; }
        public DateTime? DueDate { get; set; }

        //Message
        public string Note { get; set; }
        public int UserId { get; set; }
        public string UserName { get; set; }

        //Attachment
        public bool IsAttachment { get; set; }
        public string? FileName { get; set; }
        public string? FileDescription { get; set; }
        public string? ContentType { get; set; }
        public byte[]? AttachmentData { get; set; } // Cambiar de string a byte[] para el archivo adjunto

        //IsDeleted
        public bool? IsDeleted { get; set; }
        public string? DeletedReason { get; set; }
        public Hub()
        {
            IsCommitment = false;
            IsAttachment = false;
        }
    }
}

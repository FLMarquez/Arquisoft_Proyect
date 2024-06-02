using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.View.Models.Assignment
{
    public class HubViewModel
    {
        public int HubId { get; set; }
        public int AssignmentId { get; set; }
        public DateTime HubDate { get; set; }
        public int ItemSelect { get; set; }

        //Commitment
        public bool IsCommitment { get; set; }

        public DateTime? DueDate { get; set; }

        //Message

        public string Note { get; set; }
        public int? UserId { get; set; }
        public string? UserName { get; set; }

        //Attachment
        public bool IsAttachment { get; set; }
        public string FileName { get; set; }
        public string FileDescription { get; set; }
        public byte[] FileInput { get; set; }

        //IsDeleted
        public bool IsDeleted { get; set; }

        public HubViewModel()
        {
            IsCommitment = false;
            IsAttachment = false;
        }
        public IEnumerable<ValidationResult> Validate(ValidationContext validationContext)
        {
            if (ItemSelect == 1 || ItemSelect == 3)
            {
                if (DueDate == null)
                {
                    yield return new ValidationResult("La fecha de vencimiento es requerida.", new[] { nameof(DueDate) });
                }

                if (string.IsNullOrEmpty(Note))
                {
                    yield return new ValidationResult("La nota es requerida.", new[] { nameof(Note) });
                }

                if (UserId == null)
                {
                    yield return new ValidationResult("El usuario es requerido.", new[] { nameof(UserId) });
                }
            }

            if (ItemSelect == 2 || ItemSelect == 3)
            {
                if (string.IsNullOrEmpty(FileName))
                {
                    yield return new ValidationResult("El nombre del archivo es requerido.", new[] { nameof(FileName) });
                }

                if (UserId == null)
                {
                    yield return new ValidationResult("El usuario es requerido.", new[] { nameof(UserId) });
                }

                if (string.IsNullOrEmpty(FileDescription))
                {
                    yield return new ValidationResult("La descripción del archivo es requerida.", new[] { nameof(FileDescription) });
                }

                if (FileInput == null)
                {
                    yield return new ValidationResult("El archivo adjunto es requerido.", new[] { nameof(FileInput) });
                }
            }
        }
    }
}
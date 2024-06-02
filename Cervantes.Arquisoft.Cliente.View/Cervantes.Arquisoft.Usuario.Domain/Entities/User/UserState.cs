using System.ComponentModel.DataAnnotations;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class UserState
    {
        [Key]
        public int UserStateId { get; set; }
        public string Description { get; set; }

    }
}

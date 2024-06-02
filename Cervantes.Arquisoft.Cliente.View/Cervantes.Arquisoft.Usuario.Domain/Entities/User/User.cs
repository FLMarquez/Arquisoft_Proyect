using Cervantes.Arquisoft.Domain.Entities.Common;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class User : AuditableEntity
    {
        public int UserId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DocumentNumber { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }



        public int UserStateId { get; set; }
        public UserState UserState { get; set; }

        public int UserRoleId { get; set; }
        public UserRole? UserRole { get; set; }

        public int? UserPreferenceId { get; set; }
        public UserPreference Preferences { get; set; }

        public ICollection<Project> Projects { get; set; }
        public ICollection<Event> Events { get; set; }
        public ICollection<Message> Messages { get; set; }
        public ICollection<UserRegister> UserRegisters { get; set; }
        public ICollection<Mail> Mails { get; set; }



    }
}


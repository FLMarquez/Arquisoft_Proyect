using Cervantes.Arquisoft.Domain.Entities.Common;

namespace Cervantes.Arquisoft.Domain.Entities
{
    public class Client : AuditableEntity
    {
        //TODO: Separate entities in different folders. Aggregate Client, Aggregate Project, Aggregate User.

        public int ClientId { get; set; }
        public string Name { get; set; }
        public string LastName { get; set; }
        public string Password { get; set; }
        public string DocumentNumber { get; set; }
        public string Mail { get; set; }
        public string Telephone { get; set; }

        public int ClientStateId { get; set; }
        public int ClientRoleId { get; set; }

        public ClientState ClientStateNavigation { get; set; }
        public ClientRole ClientRoleNavigation { get; set; }

        //TODO: Check virtual class for EF. Improve fields used.
        public int? PreferencesId { get; set; }
        public int AddressId { get; set; }
        public virtual Address AddressNavigation { get; set; }



        public virtual ICollection<Project> Projects { get; set; }
        public virtual ICollection<Event> Events { get; set; }
        public virtual ICollection<Message> Messages { get; set; }
        public virtual ICollection<ClientRegister> ClientRegisters { get; set; }
        public ICollection<Mail> Mails { get; set; }


    }
}

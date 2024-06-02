using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class ClientSeed : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            builder.HasData(
                 new Client { ClientId = 1, Name = "Marcos", LastName = "Mateos", Password = "1234", DocumentNumber = "38474256", Mail = "marcosmateos@gmail.com", Telephone = "3551122334", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 1 },
                 new Client { ClientId = 2, Name = "Juan", LastName = "Gómez", Password = "1234", DocumentNumber = "47768238", Mail = "juangomez@gmail.com", Telephone = "3998877665", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 2 },
                 new Client { ClientId = 3, Name = "Luisa", LastName = "Sánchez", Password = "1234", DocumentNumber = "22349641", Mail = "luisasanchez@gmail.com", Telephone = "3889998877", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 3 },
                 new Client { ClientId = 4, Name = "Andrés", LastName = "Pérez", Password = "1234", DocumentNumber = "44000670", Mail = "andresperez@gmail.com", Telephone = "3776665544", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 4 },
                 new Client { ClientId = 5, Name = "Carolina", LastName = "López", Password = "1234", DocumentNumber = "15487263", Mail = "carolinalopez@gmail.com", Telephone = "3444455556", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 5 },
                 new Client { ClientId = 6, Name = "Mariana", LastName = "Rodríguez", Password = "1234", DocumentNumber = "29684212", Mail = "marianarodriguez@gmail.com", Telephone = "3222233334", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 6 },
                 new Client { ClientId = 7, Name = "Javier", LastName = "Hernández", Password = "1234", DocumentNumber = "40699925", Mail = "javierhernandez@gmail.com", Telephone = "3111122223", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 7 },
                 new Client { ClientId = 8, Name = "Valentina", LastName = "García", Password = "1234", DocumentNumber = "18008722", Mail = "valentinagarcia@gmail.com", Telephone = "3777788899", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 8 },
                 new Client { ClientId = 9, Name = "Camilo", LastName = "Martínez", Password = "1234", DocumentNumber = "29557139", Mail = "camilomartinez@gmail.com", Telephone = "3666677778", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 9 },
                 new Client { ClientId = 10, Name = "Daniela", LastName = "Torres", Password = "1234", DocumentNumber = "45020321", Mail = "danielatorres@gmail.com", Telephone = "3888888999", ClientStateId = 1, ClientRoleId = 1, PreferencesId = 1, AddressId = 10 }
             );
        }
    }
}
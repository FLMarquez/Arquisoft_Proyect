using Cervantes.Arquisoft.Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;

namespace Cervantes.Arquisoft.Data.Seeds
{
    public class UserSeed : IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.HasData(
                new User
                {
                    UserId = 1,
                    Name = "Admin",
                    LastName = "Admin",
                    Password = "1234",
                    DocumentNumber = "30236541",
                    Mail = "admin@admin.com",
                    Telephone = "4795263",
                    UserRoleId = 1,
                    UserStateId = 1
                },
                new User
                {
                    UserId = 2,
                    Name = "Dario",
                    LastName = "Martin",
                    Password = "1234",
                    DocumentNumber = "47768238",
                    Mail = "dariomartin@gmail.com",
                    Telephone = "3998877665",
                    UserRoleId = 2,
                    UserStateId = 1
                },
                new User
                {
                    UserId = 3,
                    Name = "Melissa",
                    LastName = "Fulgenzi",
                    Password = "1234",
                    DocumentNumber = "22349641",
                    Mail = "melissafulgenzi@gmail.com",
                    Telephone = "3889998877",
                    UserRoleId = 2,
                    UserStateId = 1
                },
                new User
                {
                    UserId = 4,
                    Name = "German",
                    LastName = "D´Gaudio",
                    Password = "1234",
                    DocumentNumber = "44000670",
                    Mail = "germandgaudio@gmail.com",
                    Telephone = "3776665544",
                    UserRoleId = 2,
                    UserStateId = 1
                }
            );
        }
    }
}
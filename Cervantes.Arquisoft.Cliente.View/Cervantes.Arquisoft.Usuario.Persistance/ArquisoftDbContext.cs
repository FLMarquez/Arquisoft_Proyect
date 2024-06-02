using Cervantes.Arquisoft.Data.Seeds;
using Cervantes.Arquisoft.Data.Seeds.Project;
using Cervantes.Arquisoft.Domain.Entities;
using Cervantes.Arquisoft.Domain.Entities.Budget;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;

namespace Cervantes.Arquisoft.Usuario.Data
{
    public class ArquisoftDbContext : DbContext
    {
        private readonly string connectionString;

        public ArquisoftDbContext(IConfiguration configuration)
        {
            connectionString = configuration.GetConnectionString("DefaultConnection")!;
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer(connectionString);

        }

        public DbSet<User> Users { get; set; }
        public DbSet<UserState> UserStates { get; set; }
        public DbSet<UserRole> UserRoles { get; set; }
        public DbSet<UserRegister> UserRegisters { get; set; }
        public DbSet<UserPreference> UserPreferences { get; set; }


        public DbSet<Client> Clients { get; set; }
        public DbSet<ClientState> ClientStates { get; set; }
        public DbSet<ClientRole> ClientRoles { get; set; }
        public DbSet<ClientRegister> ClientRegisters { get; set; }
        public DbSet<ClientPreference> ClientPreferences { get; set; }


        public DbSet<Event> Events { get; set; }
        public DbSet<Message> Messages { get; set; }
        public DbSet<Report> Reports { get; set; }
        public DbSet<Mail> Mails { get; set; }
        public DbSet<Document> Documents { get; set; }
        public DbSet<Project> Projects { get; set; }
        public DbSet<Image> Images { get; set; }
        public DbSet<Notification> Notifications { get; set; }

        public DbSet<Province> Provinces { get; set; }
        public DbSet<Locality> Localities { get; set; }
        public DbSet<Address> Addresses { get; set; }

        public DbSet<ProjectType> ProjectTypes { get; set; }
        public DbSet<ServiceType> ServiceTypes { get; set; }
        public DbSet<BudgetState> BudgetStates { get; set; }
        public DbSet<Budget> Budgets { get; set; }
        public DbSet<AssignmentType> AssignmentsTypes { get; set; }
        public DbSet<Assignment> Assignments { get; set; }
        public DbSet<Hub> Hub { get; set; }
        public DbSet<Payment> Payments { get; set; }
        public DbSet<PaymentMethod> PaymentMethods { get; set; }
        public DbSet<HistoricalProject> HistoricalProjects { get; set; }


        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PaymentMethodsSeed());
            builder.ApplyConfiguration(new ProvinceSeed());
            builder.ApplyConfiguration(new UserRoleSeed());
            builder.ApplyConfiguration(new ProjectStateSeed());
            builder.ApplyConfiguration(new ClientStateSeed());
            builder.ApplyConfiguration(new ClientRoleSeed());
            builder.ApplyConfiguration(new ServiceTypeSeed());
            builder.ApplyConfiguration(new LocalitySeed());
            builder.ApplyConfiguration(new AddressSeed());
            builder.ApplyConfiguration(new ClientSeed());
            builder.ApplyConfiguration(new UserStateSeed());
            builder.ApplyConfiguration(new AssignmentTypeSeed());
            builder.ApplyConfiguration(new BudgetStateSeed());
            builder.ApplyConfiguration(new ProjectTypeSeed());

            builder.ApplyConfiguration(new UserSeed());

            //builder.ApplyConfiguration(new AssignmentSeed());
            builder.ApplyConfiguration(new ProjectSeed());


        }
    }
}

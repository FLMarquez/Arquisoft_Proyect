using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.Data.Repositories.Assignment;
using Cervantes.Arquisoft.Data.Repositories.Project;
using Cervantes.Arquisoft.Data.Services;
using Cervantes.Arquisoft.Usuario.Data;
using Cervantes.Arquisoft.View.Services;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

IConfiguration configuration = new ConfigurationBuilder()
    .SetBasePath(Directory.GetCurrentDirectory())
    .AddJsonFile("appsettings.json", optional: false, reloadOnChange: true)
    .Build();

// Add services to the container.
builder.Services.AddControllersWithViews();

//Dependency Injection
builder.Services.AddTransient<IClientRepository, ClientRepository>();
builder.Services.AddTransient<IProvinceRepository, ProvinceRepository>();
builder.Services.AddTransient<ILocalityRepository, LocalityRepository>();

builder.Services.AddTransient<IProjectRepository, ProjectRepository>();
builder.Services.AddTransient<IServiceTypeRepository, ServiceTypeRepository>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, DeletemeUserService>();
builder.Services.AddTransient<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddTransient<ILoginClientRepository, LoginClientRepository>();
builder.Services.AddTransient<ILoginUserRepository, LoginUserRepository>();
builder.Services.AddTransient<IProjectStateRepository, ProjectStateRepository>();
builder.Services.AddTransient<IStadisticsRepository, StadisticsRepository>();
builder.Services.AddTransient<IProjectTypeRepository, ProjectTypeRepository>();
builder.Services.AddTransient<IAssignmentTypeRepository, AssignmentTypeRepository>();
builder.Services.AddTransient<IAssignmentRepository, AssignmentRepository>();
builder.Services.AddTransient<IBudgetStateRepository, BudgetStateRepository>();
builder.Services.AddTransient<IBudgetRepository, BudgetRepository>();
builder.Services.AddTransient<IPaymentRepository, Cervantes.Arquisoft.Data.Repositories.PaymentRepository>();
builder.Services.AddTransient<IPaymentMethodRepository, PaymentMethodRepository>();
builder.Services.AddTransient<IHubRepository, Cervantes.Arquisoft.Data.Repositories.Assignment.PaymentRepository>();
builder.Services.AddTransient<IClientDashboardRepository, ClientDashboardRepository>();
builder.Services.AddTransient<IAuditableRepository, AuditableRepository>();
builder.Services.AddTransient<IHistoricalProjectRepository, HistoricalProjectRepository>();
builder.Services.AddTransient<IDataProjectRepository, DataProjectRepository>();



builder.Services.AddSingleton<ICurrentUserService, CurrentUserService>();
builder.Services.AddSingleton<ICurrentClientService, CurrentClientService>();

builder.Services.AddScoped<IClientDashboardRepository, ClientDashboardRepository>();


builder.Services.AddDbContext<ArquisoftDbContext>(options =>
{
    options.UseSqlServer(configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (!app.Environment.IsDevelopment())
{
    app.UseExceptionHandler("/Home/Error");
    // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
    app.UseHsts();
}

app.UseHttpsRedirection();
app.UseStaticFiles();

app.UseRouting();

app.UseAuthorization();

app.MapControllerRoute(
    name: "default",
    pattern: "{controller=Home}/{action=Index}/{id?}");

app.Run();

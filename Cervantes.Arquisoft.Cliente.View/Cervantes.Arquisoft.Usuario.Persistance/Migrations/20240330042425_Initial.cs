using Microsoft.EntityFrameworkCore.Migrations;

#nullable disable

#pragma warning disable CA1814 // Prefer jagged arrays over multidimensional

namespace Cervantes.Arquisoft.Data.Migrations
{
    /// <inheritdoc />
    public partial class Initial : Migration
    {
        /// <inheritdoc />
        protected override void Up(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.CreateTable(
                name: "Budgets",
                columns: table => new
                {
                    BudgetId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    CreationDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectSquareMeters = table.Column<int>(type: "int", nullable: false),
                    CostPerSquareMeters = table.Column<int>(type: "int", nullable: false),
                    BudgetDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    BudgetStateId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Budgets", x => x.BudgetId);
                });

            migrationBuilder.CreateTable(
                name: "BudgetStates",
                columns: table => new
                {
                    BudgetStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetStateDescription = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_BudgetStates", x => x.BudgetStateId);
                });

            migrationBuilder.CreateTable(
                name: "ClientRoles",
                columns: table => new
                {
                    ClientRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRoles", x => x.ClientRoleId);
                });

            migrationBuilder.CreateTable(
                name: "ClientStates",
                columns: table => new
                {
                    ClientStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientStates", x => x.ClientStateId);
                });

            migrationBuilder.CreateTable(
                name: "HistoricalProjects",
                columns: table => new
                {
                    HistoricalProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    HistoricalDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    StateId = table.Column<int>(type: "int", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_HistoricalProjects", x => x.HistoricalProjectId);
                });

            migrationBuilder.CreateTable(
                name: "PaymentMethods",
                columns: table => new
                {
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    MethodName = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_PaymentMethods", x => x.PaymentMethodId);
                });

            migrationBuilder.CreateTable(
                name: "Payments",
                columns: table => new
                {
                    PaymentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    BudgetId = table.Column<int>(type: "int", nullable: true),
                    PaymentMethodId = table.Column<int>(type: "int", nullable: false),
                    Amount = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    PaymentDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Payments", x => x.PaymentId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectState",
                columns: table => new
                {
                    ProjectStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectState", x => x.ProjectStateId);
                });

            migrationBuilder.CreateTable(
                name: "ProjectTypes",
                columns: table => new
                {
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    RangeMax = table.Column<int>(type: "int", nullable: false),
                    RangeMin = table.Column<int>(type: "int", nullable: false),
                    ProfessionalFee = table.Column<decimal>(type: "decimal(18,2)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ProjectTypes", x => x.ProjectTypeId);
                });

            migrationBuilder.CreateTable(
                name: "Provinces",
                columns: table => new
                {
                    ProvinceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Provinces", x => x.ProvinceId);
                });

            migrationBuilder.CreateTable(
                name: "ServiceTypes",
                columns: table => new
                {
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ServiceTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ServiceTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsPrivate = table.Column<bool>(type: "bit", nullable: true),
                    ServiceTypeImage = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ServiceTypes", x => x.ServiceTypeId);
                });

            migrationBuilder.CreateTable(
                name: "UserPreferences",
                columns: table => new
                {
                    UserPreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1")
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserPreferences", x => x.UserPreferenceId);
                });

            migrationBuilder.CreateTable(
                name: "UserRoles",
                columns: table => new
                {
                    UserRoleId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRoles", x => x.UserRoleId);
                });

            migrationBuilder.CreateTable(
                name: "UserStates",
                columns: table => new
                {
                    UserStateId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserStates", x => x.UserStateId);
                });

            migrationBuilder.CreateTable(
                name: "Localities",
                columns: table => new
                {
                    LocalityId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Localities", x => x.LocalityId);
                    table.ForeignKey(
                        name: "FK_Localities_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                });

            migrationBuilder.CreateTable(
                name: "AssignmentsTypes",
                columns: table => new
                {
                    AssignmentTypeId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentTypeName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentTypeDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Order = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_AssignmentsTypes", x => x.AssignmentTypeId);
                    table.ForeignKey(
                        name: "FK_AssignmentsTypes_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Users",
                columns: table => new
                {
                    UserId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserStateId = table.Column<int>(type: "int", nullable: false),
                    UserRoleId = table.Column<int>(type: "int", nullable: false),
                    UserPreferenceId = table.Column<int>(type: "int", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Users", x => x.UserId);
                    table.ForeignKey(
                        name: "FK_Users_UserPreferences_UserPreferenceId",
                        column: x => x.UserPreferenceId,
                        principalTable: "UserPreferences",
                        principalColumn: "UserPreferenceId");
                    table.ForeignKey(
                        name: "FK_Users_UserRoles_UserRoleId",
                        column: x => x.UserRoleId,
                        principalTable: "UserRoles",
                        principalColumn: "UserRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Users_UserStates_UserStateId",
                        column: x => x.UserStateId,
                        principalTable: "UserStates",
                        principalColumn: "UserStateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Addresses",
                columns: table => new
                {
                    AddressId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProvinceId = table.Column<int>(type: "int", nullable: true),
                    LocalityId = table.Column<int>(type: "int", nullable: true),
                    AddressLine = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    PostalCode = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Numbering = table.Column<int>(type: "int", nullable: false),
                    Department = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Floor = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    Neighborhood = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AdditionalInstructions = table.Column<string>(type: "nvarchar(max)", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Addresses", x => x.AddressId);
                    table.ForeignKey(
                        name: "FK_Addresses_Localities_LocalityId",
                        column: x => x.LocalityId,
                        principalTable: "Localities",
                        principalColumn: "LocalityId");
                    table.ForeignKey(
                        name: "FK_Addresses_Provinces_ProvinceId",
                        column: x => x.ProvinceId,
                        principalTable: "Provinces",
                        principalColumn: "ProvinceId");
                });

            migrationBuilder.CreateTable(
                name: "UserRegisters",
                columns: table => new
                {
                    UserRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_UserRegisters", x => x.UserRegisterId);
                    table.ForeignKey(
                        name: "FK_UserRegisters_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Clients",
                columns: table => new
                {
                    ClientId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    LastName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Password = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    DocumentNumber = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Mail = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Telephone = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientStateId = table.Column<int>(type: "int", nullable: false),
                    ClientRoleId = table.Column<int>(type: "int", nullable: false),
                    PreferencesId = table.Column<int>(type: "int", nullable: true),
                    AddressId = table.Column<int>(type: "int", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Clients", x => x.ClientId);
                    table.ForeignKey(
                        name: "FK_Clients_Addresses_AddressId",
                        column: x => x.AddressId,
                        principalTable: "Addresses",
                        principalColumn: "AddressId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_ClientRoles_ClientRoleId",
                        column: x => x.ClientRoleId,
                        principalTable: "ClientRoles",
                        principalColumn: "ClientRoleId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Clients_ClientStates_ClientStateId",
                        column: x => x.ClientStateId,
                        principalTable: "ClientStates",
                        principalColumn: "ClientStateId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientPreferences",
                columns: table => new
                {
                    ClientPreferenceId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientPreferences", x => x.ClientPreferenceId);
                    table.ForeignKey(
                        name: "FK_ClientPreferences_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "ClientRegisters",
                columns: table => new
                {
                    ClientRegisterId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_ClientRegisters", x => x.ClientRegisterId);
                    table.ForeignKey(
                        name: "FK_ClientRegisters_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Mails",
                columns: table => new
                {
                    MailId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    State = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    MailText = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Mails", x => x.MailId);
                    table.ForeignKey(
                        name: "FK_Mails_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Mails_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Messages",
                columns: table => new
                {
                    MessageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Text = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Messages", x => x.MessageId);
                    table.ForeignKey(
                        name: "FK_Messages_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Messages_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Projects",
                columns: table => new
                {
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: false),
                    ServiceTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectTypeId = table.Column<int>(type: "int", nullable: false),
                    ProjectStateId = table.Column<int>(type: "int", nullable: false),
                    Budget = table.Column<decimal>(type: "decimal(18,2)", nullable: false),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Projects", x => x.ProjectId);
                    table.ForeignKey(
                        name: "FK_Projects_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ProjectState_ProjectStateId",
                        column: x => x.ProjectStateId,
                        principalTable: "ProjectState",
                        principalColumn: "ProjectStateId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_ServiceTypes_ServiceTypeId",
                        column: x => x.ServiceTypeId,
                        principalTable: "ServiceTypes",
                        principalColumn: "ServiceTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Projects_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Assignments",
                columns: table => new
                {
                    AssignmentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    AssignmentTypeId = table.Column<int>(type: "int", nullable: false),
                    AssignmentName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    AssignmentDescription = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsCompleted = table.Column<bool>(type: "bit", nullable: false),
                    NotVisible = table.Column<bool>(type: "bit", nullable: false),
                    IsStarted = table.Column<bool>(type: "bit", nullable: false),
                    IsSkipped = table.Column<bool>(type: "bit", nullable: false),
                    CompletedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    StartedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    SkippedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    OriginalDueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true),
                    CreatedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ModifiedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    DeletedBy = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    CreatedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    ModifiedDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    DeletedDate = table.Column<DateTime>(type: "datetime2", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Assignments", x => x.AssignmentId);
                    table.ForeignKey(
                        name: "FK_Assignments_AssignmentsTypes_AssignmentTypeId",
                        column: x => x.AssignmentTypeId,
                        principalTable: "AssignmentsTypes",
                        principalColumn: "AssignmentTypeId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Assignments_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.NoAction);
                });

            migrationBuilder.CreateTable(
                name: "Documents",
                columns: table => new
                {
                    DocumentId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Documents", x => x.DocumentId);
                    table.ForeignKey(
                        name: "FK_Documents_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Events",
                columns: table => new
                {
                    EventId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Name = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    StartDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    EndDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false),
                    ClientId = table.Column<int>(type: "int", nullable: true),
                    UserId = table.Column<int>(type: "int", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Events", x => x.EventId);
                    table.ForeignKey(
                        name: "FK_Events_Clients_ClientId",
                        column: x => x.ClientId,
                        principalTable: "Clients",
                        principalColumn: "ClientId");
                    table.ForeignKey(
                        name: "FK_Events_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                    table.ForeignKey(
                        name: "FK_Events_Users_UserId",
                        column: x => x.UserId,
                        principalTable: "Users",
                        principalColumn: "UserId");
                });

            migrationBuilder.CreateTable(
                name: "Images",
                columns: table => new
                {
                    ImageId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Images", x => x.ImageId);
                    table.ForeignKey(
                        name: "FK_Images_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Notifications",
                columns: table => new
                {
                    NotificationId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Message = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    Date = table.Column<DateTime>(type: "datetime2", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Notifications", x => x.NotificationId);
                    table.ForeignKey(
                        name: "FK_Notifications_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Reports",
                columns: table => new
                {
                    ReportId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    Description = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    ProjectId = table.Column<int>(type: "int", nullable: false)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Reports", x => x.ReportId);
                    table.ForeignKey(
                        name: "FK_Reports_Projects_ProjectId",
                        column: x => x.ProjectId,
                        principalTable: "Projects",
                        principalColumn: "ProjectId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.CreateTable(
                name: "Hub",
                columns: table => new
                {
                    HubId = table.Column<int>(type: "int", nullable: false)
                        .Annotation("SqlServer:Identity", "1, 1"),
                    AssignmentId = table.Column<int>(type: "int", nullable: false),
                    HubDate = table.Column<DateTime>(type: "datetime2", nullable: false),
                    IsCommitment = table.Column<bool>(type: "bit", nullable: false),
                    DueDate = table.Column<DateTime>(type: "datetime2", nullable: true),
                    Note = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    UserId = table.Column<int>(type: "int", nullable: false),
                    UserName = table.Column<string>(type: "nvarchar(max)", nullable: false),
                    IsAttachment = table.Column<bool>(type: "bit", nullable: false),
                    FileName = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    FileDescription = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    ContentType = table.Column<string>(type: "nvarchar(max)", nullable: true),
                    AttachmentData = table.Column<byte[]>(type: "varbinary(max)", nullable: true),
                    IsDeleted = table.Column<bool>(type: "bit", nullable: true)
                },
                constraints: table =>
                {
                    table.PrimaryKey("PK_Hub", x => x.HubId);
                    table.ForeignKey(
                        name: "FK_Hub_Assignments_AssignmentId",
                        column: x => x.AssignmentId,
                        principalTable: "Assignments",
                        principalColumn: "AssignmentId",
                        onDelete: ReferentialAction.Cascade);
                });

            migrationBuilder.InsertData(
                table: "BudgetStates",
                columns: new[] { "BudgetStateId", "BudgetStateDescription" },
                values: new object[,]
                {
                    { 1, "Revisión" },
                    { 2, "Finalizado" },
                    { 3, "Aprobado" },
                    { 4, "Pagado" }
                });

            migrationBuilder.InsertData(
                table: "ClientRoles",
                columns: new[] { "ClientRoleId", "Description" },
                values: new object[] { 1, "Cliente" });

            migrationBuilder.InsertData(
                table: "ClientStates",
                columns: new[] { "ClientStateId", "Description" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "PaymentMethods",
                columns: new[] { "PaymentMethodId", "MethodName" },
                values: new object[,]
                {
                    { 1, "Efectivo" },
                    { 2, "Transferencia" },
                    { 3, "Débito" }
                });

            migrationBuilder.InsertData(
                table: "ProjectState",
                columns: new[] { "ProjectStateId", "Description" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" },
                    { 3, "En progreso" },
                    { 4, "Completado" },
                    { 5, "Pendiente" }
                });

            migrationBuilder.InsertData(
                table: "ProjectTypes",
                columns: new[] { "ProjectTypeId", "ProfessionalFee", "ProjectTypeDescription", "ProjectTypeName", "RangeMax", "RangeMin" },
                values: new object[,]
                {
                    { 1, 200m, "ProjectTypeDesc1", "ProjectTypeName1", 10, 1 },
                    { 2, 300m, "ProjectTypeDesc2", "ProjectTypeName2", 20, 10 }
                });

            migrationBuilder.InsertData(
                table: "Provinces",
                columns: new[] { "ProvinceId", "Description" },
                values: new object[,]
                {
                    { 1, "Buenos Aires" },
                    { 2, "Catamarca" },
                    { 3, "Chaco" },
                    { 4, "Chubut" },
                    { 5, "Córdoba" },
                    { 6, "Corrientes" },
                    { 7, "Entre Ríos" },
                    { 8, "Formosa" },
                    { 9, "Jujuy" },
                    { 10, "La Pampa" },
                    { 11, "La Rioja" },
                    { 12, "Mendoza" },
                    { 13, "Misiones" },
                    { 14, "Neuquén" },
                    { 15, "Río Negro" },
                    { 16, "Salta" },
                    { 17, "San Juan" },
                    { 18, "San Luis" },
                    { 19, "Santa Cruz" },
                    { 20, "Santa Fe" },
                    { 21, "Santiago del Estero" },
                    { 22, "Tierra del Fuego" },
                    { 23, "Tucumán" }
                });

            migrationBuilder.InsertData(
                table: "ServiceTypes",
                columns: new[] { "ServiceTypeId", "IsPrivate", "ServiceTypeDescription", "ServiceTypeImage", "ServiceTypeName" },
                values: new object[,]
                {
                    { 1, null, "Se trabajará en el completamiento del anteproyecto, desarrollando el material necesario para la ejecución en obra.", null, "Proyecto con detalle" },
                    { 2, null, "Control de obra Planificación de obra (secuencia lógica de ejecución de cada actividad o rubro) Programación de obra (Estimación de tiempo para ejecutar cada actividad y rendimiento)", null, "Conducción Técnica" },
                    { 3, null, "Se trabajará con la IDEA DE PROYECTO, atendiendo a la situación particular del cliente según la información brindada por el mismo (necesidades, deseos, recursos disponibles, lote, orientaciones, implantación, programa, usuario) Se escucha del cliente, se capta y procesa la información, estudian y analizan todas estas variables, brindando asesoramiento profesional y personalizado, determinando las mejores alernativas para llevar a cabo el encargo, según cada caso en particular.", null, "Anteproyecto" },
                    { 4, null, "Se trabajará con la .", null, "Proyecto sin detalle" },
                    { 5, null, "Se trabajará con la ", null, "Proyecto y Ejecucion" }
                });

            migrationBuilder.InsertData(
                table: "UserRoles",
                columns: new[] { "UserRoleId", "Description" },
                values: new object[,]
                {
                    { 1, "Admin" },
                    { 2, "Usuario" },
                    { 3, "Soporte" },
                    { 4, "Técnico" },
                    { 5, "Visitante" }
                });

            migrationBuilder.InsertData(
                table: "UserStates",
                columns: new[] { "UserStateId", "Description" },
                values: new object[,]
                {
                    { 1, "Activo" },
                    { 2, "Inactivo" }
                });

            migrationBuilder.InsertData(
                table: "AssignmentsTypes",
                columns: new[] { "AssignmentTypeId", "AssignmentTypeDescription", "AssignmentTypeName", "Order", "ServiceTypeId" },
                values: new object[,]
                {
                    { 1, "Elaboración de planos para Anteproyecto", "Elaboración de Planos", 1, 1 },
                    { 2, "Presentación de documentación para Anteproyecto", "Presentación de Documentación", 2, 1 },
                    { 3, "Revisión de costos para Anteproyecto", "Revisión de Costos", 3, 1 },
                    { 4, "Diseño conceptual para Anteproyecto", "Diseño Conceptual", 4, 1 },
                    { 5, "Evaluación ambiental para Anteproyecto", "Evaluación Ambiental", 5, 1 },
                    { 6, "Planificación de recursos para Proyecto Sin Detalle", "Planificación de Recursos", 1, 2 },
                    { 7, "Diseño preliminar para Proyecto Sin Detalle", "Diseño Preliminar", 2, 2 },
                    { 8, "Adquisición de materiales para Proyecto Sin Detalle", "Adquisición de Materiales", 3, 2 },
                    { 9, "Supervisión de construcción para Proyecto Sin Detalle", "Supervisión de Construcción", 4, 2 },
                    { 10, "Control de calidad para Proyecto Sin Detalle", "Control de Calidad", 5, 2 },
                    { 11, "Diseño detallado para Proyecto Con Detalle", "Diseño Detallado", 1, 3 },
                    { 12, "Planificación de recursos para Proyecto Con Detalle", "Planificación de Recursos", 2, 3 },
                    { 13, "Adquisición de materiales para Proyecto Con Detalle", "Adquisición de Materiales", 3, 3 },
                    { 14, "Supervisión de construcción para Proyecto Con Detalle", "Supervisión de Construcción", 4, 3 },
                    { 15, "Control de calidad para Proyecto Con Detalle", "Control de Calidad", 5, 3 },
                    { 16, "Planificación de ejecución para Ejecución", "Planificación de Ejecución", 1, 4 },
                    { 17, "Adquisición de recursos para Ejecución", "Adquisición de Recursos", 2, 4 },
                    { 18, "Ejecución de trabajos para Ejecución", "Ejecución de Trabajos", 3, 4 },
                    { 19, "Seguimiento de progreso para Ejecución", "Seguimiento de Progreso", 4, 4 },
                    { 20, "Control de calidad para Ejecución", "Control de Calidad", 5, 4 },
                    { 21, "Planificación de obra para Obra", "Planificación de Obra", 1, 5 },
                    { 22, "Adquisición de materiales para Obra", "Adquisición de Materiales", 2, 5 },
                    { 23, "Construcción de infraestructura para Obra", "Construcción de Infraestructura", 3, 5 },
                    { 24, "Supervisión de construcción para Obra", "Supervisión de Construcción", 4, 5 },
                    { 25, "Entrega y puesta en marcha para Obra", "Entrega y Puesta en Marcha", 5, 5 }
                });

            migrationBuilder.InsertData(
                table: "Localities",
                columns: new[] { "LocalityId", "Description", "ProvinceId" },
                values: new object[,]
                {
                    { 1, "Buenos Aires", 1 },
                    { 2, "La Plata", 1 },
                    { 3, "Mar del Plata", 1 },
                    { 4, "Bahía Blanca", 1 },
                    { 5, "San Isidro", 1 },
                    { 6, "Pilar", 1 },
                    { 7, "Quilmes", 1 },
                    { 8, "Morón", 1 },
                    { 9, "Tandil", 1 },
                    { 10, "Lomas de Zamora", 1 },
                    { 11, "San Fernando del Valle de Catamarca", 2 },
                    { 12, "Andalgalá", 2 },
                    { 13, "Belén", 2 },
                    { 14, "Santa María", 2 },
                    { 15, "Recreo", 2 },
                    { 16, "Fiambalá", 2 },
                    { 17, "Tinogasta", 2 },
                    { 18, "Saujil", 2 },
                    { 19, "Aconquija", 2 },
                    { 20, "Los Altos", 2 },
                    { 21, "Resistencia", 3 },
                    { 22, "Barranqueras", 3 },
                    { 23, "Fontana", 3 },
                    { 24, "Presidencia Roque Sáenz Peña", 3 },
                    { 25, "Villa Ángela", 3 },
                    { 26, "Charata", 3 },
                    { 27, "General San Martín", 3 },
                    { 28, "Juan José Castelli", 3 },
                    { 29, "Quitilipi", 3 },
                    { 30, "Machagai", 3 },
                    { 31, "Rawson", 4 },
                    { 32, "Comodoro Rivadavia", 4 },
                    { 33, "Puerto Madryn", 4 },
                    { 34, "Trelew", 4 },
                    { 35, "Esquel", 4 },
                    { 36, "Rada Tilly", 4 },
                    { 37, "Gaiman", 4 },
                    { 38, "Sarmiento", 4 },
                    { 39, "Dolavon", 4 },
                    { 40, "Gobernador Costa", 4 },
                    { 41, "Córdoba", 5 },
                    { 42, "Villa Carlos Paz", 5 },
                    { 43, "Río Cuarto", 5 },
                    { 44, "Alta Gracia", 5 },
                    { 45, "San Francisco", 5 },
                    { 46, "Villa María", 5 },
                    { 47, "Jesús María", 5 },
                    { 48, "Bell Ville", 5 },
                    { 49, "Cosquín", 5 },
                    { 50, "La Falda", 5 },
                    { 51, "Corrientes", 6 },
                    { 52, "Goya", 6 },
                    { 53, "Mercedes", 6 },
                    { 54, "Curuzú Cuatiá", 6 },
                    { 55, "Bella Vista", 6 },
                    { 56, "Esquina", 6 },
                    { 57, "Ituzaingó", 6 },
                    { 58, "Santo Tomé", 6 },
                    { 59, "Monte Caseros", 6 },
                    { 60, "Paso de los Libres", 6 },
                    { 61, "Paraná", 7 },
                    { 62, "Concordia", 7 },
                    { 63, "Gualeguaychú", 7 },
                    { 64, "Gualeguay", 7 },
                    { 65, "Chajarí", 7 },
                    { 66, "Villaguay", 7 },
                    { 67, "Colón", 7 },
                    { 68, "Victoria", 7 },
                    { 69, "Diamante", 7 },
                    { 70, "La Paz", 7 },
                    { 71, "Formosa", 8 },
                    { 72, "Clorinda", 8 },
                    { 73, "Pirané", 8 },
                    { 74, "El Colorado", 8 },
                    { 75, "Las Lomitas", 8 },
                    { 76, "Riacho He Hé", 8 },
                    { 77, "Laguna Yema", 8 },
                    { 78, "Ibarreta", 8 },
                    { 79, "General Güemes", 8 },
                    { 80, "San Martín 2", 8 },
                    { 81, "San Salvador de Jujuy", 9 },
                    { 82, "Palpalá", 9 },
                    { 83, "San Pedro", 9 },
                    { 84, "Libertador General San Martín", 9 },
                    { 85, "Perico", 9 },
                    { 86, "El Carmen", 9 },
                    { 87, "Humahuaca", 9 },
                    { 88, "La Quiaca", 9 },
                    { 89, "Tilcara", 9 },
                    { 90, "Abra Pampa", 9 },
                    { 91, "Santa Rosa", 10 },
                    { 92, "General Pico", 10 },
                    { 93, "Toay", 10 },
                    { 94, "Realicó", 10 },
                    { 95, "Eduardo Castex", 10 },
                    { 96, "General Acha", 10 },
                    { 97, "25 de Mayo", 10 },
                    { 98, "General Manuel J. Campos", 10 },
                    { 99, "Catriló", 10 },
                    { 100, "Macachín", 10 },
                    { 101, "La Rioja", 11 },
                    { 102, "Chilecito", 11 },
                    { 103, "Chamical", 11 },
                    { 104, "Famatina", 11 },
                    { 105, "Chepes", 11 },
                    { 106, "Arauco", 11 },
                    { 107, "Olta", 11 },
                    { 108, "Villa Unión", 11 },
                    { 109, "Villa Castelli", 11 },
                    { 110, "Sanagasta", 11 },
                    { 111, "Mendoza", 12 },
                    { 112, "San Rafael", 12 },
                    { 113, "Godoy Cruz", 12 },
                    { 114, "Luján de Cuyo", 12 },
                    { 115, "Las Heras", 12 },
                    { 116, "Maipú", 12 },
                    { 117, "San Martín", 12 },
                    { 118, "Malargüe", 12 },
                    { 119, "Tunuyán", 12 },
                    { 120, "General Alvear", 12 },
                    { 121, "Posadas", 13 },
                    { 122, "Eldorado", 13 },
                    { 123, "Puerto Iguazú", 13 },
                    { 124, "Oberá", 13 },
                    { 125, "Apostoles", 13 },
                    { 126, "San Vicente", 13 },
                    { 127, "Alem", 13 },
                    { 128, "Jardín América", 13 },
                    { 129, "Montecarlo", 13 },
                    { 130, "Puerto Rico", 13 },
                    { 131, "Neuquén", 14 },
                    { 132, "San Martín de los Andes", 14 },
                    { 133, "Cutral Có", 14 },
                    { 134, "Plottier", 14 },
                    { 135, "Zapala", 14 },
                    { 136, "Centenario", 14 },
                    { 137, "Villa La Angostura", 14 },
                    { 138, "Chos Malal", 14 },
                    { 139, "Senillosa", 14 },
                    { 140, "Rincón de los Sauces", 14 },
                    { 141, "Viedma", 15 },
                    { 142, "San Carlos de Bariloche", 15 },
                    { 143, "General Roca", 15 },
                    { 144, "Cipolletti", 15 },
                    { 145, "Allen", 15 },
                    { 146, "El Bolsón", 15 },
                    { 147, "Ingeniero Jacobacci", 15 },
                    { 148, "Villa Regina", 15 },
                    { 150, "Choele Choel", 15 },
                    { 151, "Cinco Saltos", 15 },
                    { 152, "Salta", 16 },
                    { 153, "San Ramón de la Nueva Orán", 16 },
                    { 154, "General Güemes", 16 },
                    { 155, "Tartagal", 16 },
                    { 156, "Cafayate", 16 },
                    { 157, "San Pedro de Jujuy", 16 },
                    { 158, "Metán", 16 },
                    { 159, "El Carril", 16 },
                    { 160, "Rosario de la Frontera", 16 },
                    { 161, "Chicoana", 16 },
                    { 162, "San Juan", 17 },
                    { 163, "Rawson", 17 },
                    { 164, "Chimbas", 17 },
                    { 165, "Pocito", 17 },
                    { 166, "Rivadavia", 17 },
                    { 167, "Santa Lucía", 17 },
                    { 168, "Caucete", 17 },
                    { 169, "Albardón", 17 },
                    { 170, "Jáchal", 17 },
                    { 171, "25 de Mayo", 17 },
                    { 172, "San Luis", 18 },
                    { 173, "Villa Mercedes", 18 },
                    { 174, "San Francisco del Monte de Oro", 18 },
                    { 175, "La Toma", 18 },
                    { 176, "Justo Daract", 18 },
                    { 177, "Merlo", 18 },
                    { 178, "Santa Rosa del Conlara", 18 },
                    { 179, "Naschel", 18 },
                    { 180, "Quines", 18 },
                    { 181, "Concarán", 18 },
                    { 182, "Río Gallegos", 19 },
                    { 183, "Caleta Olivia", 19 },
                    { 184, "El Calafate", 19 },
                    { 185, "Puerto Deseado", 19 },
                    { 186, "Río Turbio", 19 },
                    { 187, "28 de Noviembre", 19 },
                    { 188, "Pico Truncado", 19 },
                    { 189, "Las Heras", 19 },
                    { 190, "Perito Moreno", 19 },
                    { 191, "Gobernador Gregores", 19 },
                    { 192, "Santa Fe", 20 },
                    { 193, "Rosario", 20 },
                    { 194, "Venado Tuerto", 20 },
                    { 195, "Rafaela", 20 },
                    { 196, "Reconquista", 20 },
                    { 197, "Santiago del Estero", 21 },
                    { 198, "La Banda", 21 },
                    { 199, "Termas de Río Hondo", 21 },
                    { 200, "Añatuya", 21 },
                    { 201, "Fernández", 21 },
                    { 202, "Clodomira", 21 },
                    { 203, "Frías", 21 },
                    { 204, "Loreto", 21 },
                    { 205, "Suncho Corral", 21 },
                    { 206, "Beltrán", 21 },
                    { 207, "Ushuaia", 22 },
                    { 208, "Río Grande", 22 },
                    { 209, "Tolhuin", 22 },
                    { 210, "Puerto Almanza", 22 },
                    { 211, "San Julián", 22 },
                    { 212, "Puerto Williams", 22 },
                    { 213, "Puerto Toro", 22 },
                    { 214, "Puerto Yartou", 22 },
                    { 215, "Caleta María", 22 },
                    { 216, "Puerto Roballo", 22 },
                    { 217, "San Miguel de Tucumán", 23 },
                    { 218, "Yerba Buena", 23 },
                    { 219, "Banda del Río Salí", 23 },
                    { 220, "Concepción", 23 },
                    { 221, "Aguilares", 23 },
                    { 222, "Tafí Viejo", 23 },
                    { 223, "Famaillá", 23 },
                    { 224, "Tafí del Valle", 23 },
                    { 225, "Monteros", 23 },
                    { 226, "Lules", 23 }
                });

            migrationBuilder.InsertData(
                table: "Users",
                columns: new[] { "UserId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DocumentNumber", "IsDeleted", "LastName", "Mail", "ModifiedBy", "ModifiedDate", "Name", "Password", "Telephone", "UserPreferenceId", "UserRoleId", "UserStateId" },
                values: new object[,]
                {
                    { 1, null, null, null, null, "30236541", false, "Admin", "admin@admin.com", null, null, "Admin", "1234", "4795263", null, 1, 1 },
                    { 2, null, null, null, null, "47768238", false, "Martin", "dariomartin@gmail.com", null, null, "Dario", "1234", "3998877665", null, 2, 1 },
                    { 3, null, null, null, null, "22349641", false, "Fulgenzi", "melissafulgenzi@gmail.com", null, null, "Melissa", "1234", "3889998877", null, 2, 1 },
                    { 4, null, null, null, null, "44000670", false, "D´Gaudio", "germandgaudio@gmail.com", null, null, "German", "1234", "3776665544", null, 2, 1 }
                });

            migrationBuilder.InsertData(
                table: "Addresses",
                columns: new[] { "AddressId", "AdditionalInstructions", "AddressLine", "Department", "Floor", "LocalityId", "Neighborhood", "Numbering", "PostalCode", "ProvinceId" },
                values: new object[,]
                {
                    { 1, null, "Boyero", "1", "1", 3, "Chateau Carreras", 528, "5000", 5 },
                    { 2, null, "Cerrito", "1", "1", 3, "Arguello", 173, "5000", 5 },
                    { 3, null, "Chancay", "1", "1", 2, "Observatorio", 1401, "5003", 5 },
                    { 4, null, "San Martín", "1", "1", 5, "San Vicente", 867, "5000", 7 },
                    { 5, null, "9 de Julio", "1", "1", 4, "San Martín", 422, "5010", 8 },
                    { 6, null, "25 de Mayo", "1", "1", 3, "9 de Julio", 8, "5800", 3 },
                    { 7, null, "Rosario", "1", "1", 4, "Bella Vista", 914, "5125", 2 },
                    { 8, null, "Colon", "1", "1", 3, "Quintana", 777, "4052", 1 },
                    { 9, null, "Salta", "1", "1", 2, "Belgrano", 1522, "3582", 1 },
                    { 10, null, "Jujuy", "1", "1", 1, "Palermo", 4006, "5008", 9 }
                });

            migrationBuilder.InsertData(
                table: "Clients",
                columns: new[] { "ClientId", "AddressId", "ClientRoleId", "ClientStateId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "DocumentNumber", "IsDeleted", "LastName", "Mail", "ModifiedBy", "ModifiedDate", "Name", "Password", "PreferencesId", "Telephone" },
                values: new object[,]
                {
                    { 1, 1, 1, 1, null, null, null, null, "38474256", false, "Mateos", "marcosmateos@gmail.com", null, null, "Marcos", "1234", 1, "3551122334" },
                    { 2, 2, 1, 1, null, null, null, null, "47768238", false, "Gómez", "juangomez@gmail.com", null, null, "Juan", "1234", 1, "3998877665" },
                    { 3, 3, 1, 1, null, null, null, null, "22349641", false, "Sánchez", "luisasanchez@gmail.com", null, null, "Luisa", "1234", 1, "3889998877" },
                    { 4, 4, 1, 1, null, null, null, null, "44000670", false, "Pérez", "andresperez@gmail.com", null, null, "Andrés", "1234", 1, "3776665544" },
                    { 5, 5, 1, 1, null, null, null, null, "15487263", false, "López", "carolinalopez@gmail.com", null, null, "Carolina", "1234", 1, "3444455556" },
                    { 6, 6, 1, 1, null, null, null, null, "29684212", false, "Rodríguez", "marianarodriguez@gmail.com", null, null, "Mariana", "1234", 1, "3222233334" },
                    { 7, 7, 1, 1, null, null, null, null, "40699925", false, "Hernández", "javierhernandez@gmail.com", null, null, "Javier", "1234", 1, "3111122223" },
                    { 8, 8, 1, 1, null, null, null, null, "18008722", false, "García", "valentinagarcia@gmail.com", null, null, "Valentina", "1234", 1, "3777788899" },
                    { 9, 9, 1, 1, null, null, null, null, "29557139", false, "Martínez", "camilomartinez@gmail.com", null, null, "Camilo", "1234", 1, "3666677778" },
                    { 10, 10, 1, 1, null, null, null, null, "45020321", false, "Torres", "danielatorres@gmail.com", null, null, "Daniela", "1234", 1, "3888888999" }
                });

            migrationBuilder.InsertData(
                table: "Projects",
                columns: new[] { "ProjectId", "Budget", "ClientId", "CreatedBy", "CreatedDate", "DeletedBy", "DeletedDate", "IsDeleted", "ModifiedBy", "ModifiedDate", "Name", "ProjectStateId", "ProjectTypeId", "ServiceTypeId", "UserId" },
                values: new object[,]
                {
                    { 1, 0m, 4, null, null, null, null, false, null, null, "Casa en desnivel", 4, 2, 3, 4 },
                    { 2, 0m, 7, null, null, null, null, false, null, null, "Remodelación de oficina", 1, 5, 1, 3 },
                    { 3, 0m, 2, null, null, null, null, false, null, null, "Construcción de edificio residencial", 5, 4, 2, 2 },
                    { 4, 0m, 5, null, null, null, null, false, null, null, "Renovación de cocina", 2, 1, 1, 4 },
                    { 5, 0m, 3, null, null, null, null, false, null, null, "Ampliación de casa", 3, 3, 3, 3 },
                    { 6, 0m, 9, null, null, null, null, false, null, null, "Diseño de jardín", 4, 2, 1, 2 },
                    { 7, 0m, 1, null, null, null, null, false, null, null, "Proyecto de infraestructura vial", 5, 5, 2, 4 },
                    { 8, 0m, 6, null, null, null, null, false, null, null, "Construcción de centro comercial", 4, 4, 3, 2 },
                    { 9, 0m, 8, null, null, null, null, false, null, null, "Remodelación de baño", 3, 3, 1, 3 },
                    { 10, 0m, 10, null, null, null, null, false, null, null, "Casa en la playa", 1, 1, 2, 4 },
                    { 11, 0m, 2, null, null, null, null, false, null, null, "Proyecto de desarrollo de software", 2, 2, 3, 2 },
                    { 12, 0m, 3, null, null, null, null, false, null, null, "Construcción de hotel", 4, 4, 2, 3 },
                    { 13, 0m, 5, null, null, null, null, false, null, null, "Renovación de fachada", 5, 5, 1, 4 },
                    { 14, 0m, 9, null, null, null, null, false, null, null, "Construcción de parque temático", 3, 3, 3, 3 },
                    { 15, 0m, 1, null, null, null, null, false, null, null, "Remodelación de local comercial", 1, 1, 1, 2 }
                });

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_LocalityId",
                table: "Addresses",
                column: "LocalityId");

            migrationBuilder.CreateIndex(
                name: "IX_Addresses_ProvinceId",
                table: "Addresses",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_AssignmentTypeId",
                table: "Assignments",
                column: "AssignmentTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Assignments_ProjectId",
                table: "Assignments",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_AssignmentsTypes_ServiceTypeId",
                table: "AssignmentsTypes",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientPreferences_ClientId",
                table: "ClientPreferences",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_ClientRegisters_ClientId",
                table: "ClientRegisters",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_AddressId",
                table: "Clients",
                column: "AddressId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientRoleId",
                table: "Clients",
                column: "ClientRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Clients_ClientStateId",
                table: "Clients",
                column: "ClientStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Documents_ProjectId",
                table: "Documents",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ClientId",
                table: "Events",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_ProjectId",
                table: "Events",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Events_UserId",
                table: "Events",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Hub_AssignmentId",
                table: "Hub",
                column: "AssignmentId");

            migrationBuilder.CreateIndex(
                name: "IX_Images_ProjectId",
                table: "Images",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Localities_ProvinceId",
                table: "Localities",
                column: "ProvinceId");

            migrationBuilder.CreateIndex(
                name: "IX_Mails_ClientId",
                table: "Mails",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Mails_UserId",
                table: "Mails",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_ClientId",
                table: "Messages",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Messages_UserId",
                table: "Messages",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Notifications_ProjectId",
                table: "Notifications",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ClientId",
                table: "Projects",
                column: "ClientId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectStateId",
                table: "Projects",
                column: "ProjectStateId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ProjectTypeId",
                table: "Projects",
                column: "ProjectTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_ServiceTypeId",
                table: "Projects",
                column: "ServiceTypeId");

            migrationBuilder.CreateIndex(
                name: "IX_Projects_UserId",
                table: "Projects",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Reports_ProjectId",
                table: "Reports",
                column: "ProjectId");

            migrationBuilder.CreateIndex(
                name: "IX_UserRegisters_UserId",
                table: "UserRegisters",
                column: "UserId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserPreferenceId",
                table: "Users",
                column: "UserPreferenceId",
                unique: true,
                filter: "[UserPreferenceId] IS NOT NULL");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserRoleId",
                table: "Users",
                column: "UserRoleId");

            migrationBuilder.CreateIndex(
                name: "IX_Users_UserStateId",
                table: "Users",
                column: "UserStateId");
        }

        /// <inheritdoc />
        protected override void Down(MigrationBuilder migrationBuilder)
        {
            migrationBuilder.DropTable(
                name: "Budgets");

            migrationBuilder.DropTable(
                name: "BudgetStates");

            migrationBuilder.DropTable(
                name: "ClientPreferences");

            migrationBuilder.DropTable(
                name: "ClientRegisters");

            migrationBuilder.DropTable(
                name: "Documents");

            migrationBuilder.DropTable(
                name: "Events");

            migrationBuilder.DropTable(
                name: "HistoricalProjects");

            migrationBuilder.DropTable(
                name: "Hub");

            migrationBuilder.DropTable(
                name: "Images");

            migrationBuilder.DropTable(
                name: "Mails");

            migrationBuilder.DropTable(
                name: "Messages");

            migrationBuilder.DropTable(
                name: "Notifications");

            migrationBuilder.DropTable(
                name: "PaymentMethods");

            migrationBuilder.DropTable(
                name: "Payments");

            migrationBuilder.DropTable(
                name: "Reports");

            migrationBuilder.DropTable(
                name: "UserRegisters");

            migrationBuilder.DropTable(
                name: "Assignments");

            migrationBuilder.DropTable(
                name: "AssignmentsTypes");

            migrationBuilder.DropTable(
                name: "Projects");

            migrationBuilder.DropTable(
                name: "Clients");

            migrationBuilder.DropTable(
                name: "ProjectState");

            migrationBuilder.DropTable(
                name: "ProjectTypes");

            migrationBuilder.DropTable(
                name: "ServiceTypes");

            migrationBuilder.DropTable(
                name: "Users");

            migrationBuilder.DropTable(
                name: "Addresses");

            migrationBuilder.DropTable(
                name: "ClientRoles");

            migrationBuilder.DropTable(
                name: "ClientStates");

            migrationBuilder.DropTable(
                name: "UserPreferences");

            migrationBuilder.DropTable(
                name: "UserRoles");

            migrationBuilder.DropTable(
                name: "UserStates");

            migrationBuilder.DropTable(
                name: "Localities");

            migrationBuilder.DropTable(
                name: "Provinces");
        }
    }
}

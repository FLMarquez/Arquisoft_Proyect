using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.Data.Repositories.Assignment;
using Cervantes.Arquisoft.Data.Repositories.Project;
using Cervantes.Arquisoft.Data.Services;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Services;
using ClosedXML.Excel;
using Microsoft.AspNetCore.Mvc;
using System.Data;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class ProjectController : Controller
    {
        private readonly IProjectRepository projectRepository;
        private readonly IUserService userService;
        private readonly IClientRepository clientRepository;
        private readonly IUserRepository userRepository;
        private readonly IProjectTypeRepository projectTypeRepository;
        private readonly IProjectStateRepository projectStateRepository;
        private readonly IServiceTypeRepository serviceTypeRepository;
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IHistoricalProjectRepository historicalProjectRepository;



        public ProjectController(IProjectRepository projectRepository, IUserService userService, IClientRepository clientRepository,
                                 IUserRepository userRepository, IProjectTypeRepository projectTypeRepository, IProjectStateRepository projectStateRepository,
                                 IServiceTypeRepository serviceTypeRepository, IAssignmentRepository assignmentRepository, IHistoricalProjectRepository historicalProjectRepository)
        {
            this.projectRepository = projectRepository;
            this.userService = userService;
            this.clientRepository = clientRepository;
            this.userRepository = userRepository;
            this.projectTypeRepository = projectTypeRepository;
            this.projectStateRepository = projectStateRepository;
            this.serviceTypeRepository = serviceTypeRepository;
            this.assignmentRepository = assignmentRepository;
            this.historicalProjectRepository = historicalProjectRepository;
        }

        #region Read

        public async Task<IActionResult> Index()
        {
            var projectDto = await projectRepository.GetAllProjectWithDetails();


            var projectViewModels = await Task.WhenAll(projectDto.Select(async projectDto => new ProjectViewModel
            {
                Id = projectDto.ProjectId,
                Name = projectDto.ProjectName,
                UserId = projectDto.UserId,
                UserName = projectDto.UserName,
                UserLastName = projectDto.UserLastName,
                ClientId = projectDto.ClientId,
                ClientName = projectDto.ClientName,
                ClientLastName = projectDto.ClientLastName,
                ProjectTypeId = projectDto.ProjectTypeId,
                ProjectTypeName = projectDto.ProjectTypeName,
                ProjectStateId = projectDto.ProjectStateId,
            }));

            return View(projectViewModels);
        }

        public async Task<IActionResult> List()
        {
            var projectDto = await projectRepository.GetAll();

            IEnumerable<ProjectViewModel> projectViewModels = projectDto.Select(projectDto => new ProjectViewModel
            {
                Id = projectDto.ProjectId,
                Name = projectDto.Name,
                UserId = projectDto.UserId,
                ClientId = projectDto.ClientId,
                ProjectTypeId = projectDto.ProjectTypeId,
            });

            return View(projectViewModels);
        }

        #endregion
        #region Create

        public async Task<IActionResult> Create()
        {
            var serviceTypeList = await serviceTypeRepository.GetAll();
            var projectTypeList = await projectTypeRepository.GetAll();
            var clientList = await clientRepository.GetAll();
            var userList = await userRepository.GetAll();
            var projectStateList = await projectStateRepository.GetAll();

            var model = new ProjectViewModel();
            model.ServiceTypeList = serviceTypeList ?? Enumerable.Empty<ServiceTypeDto>();
            model.ProjectTypeList = projectTypeList ?? Enumerable.Empty<ProjectTypeDTO>();
            model.ClientList = clientList ?? Enumerable.Empty<ClientDto>();
            model.UserList = userList ?? Enumerable.Empty<UserDto>();
            model.ProjectStateList = projectStateList ?? Enumerable.Empty<ProjectStateDto>();

            ModelState.Clear();
            return View(model);

        }

        [HttpPost]
        public async Task<IActionResult> Create(ProjectViewModel model)
        {
            ModelState.Remove("ClientList");
            ModelState.Remove("UserList");
            ModelState.Remove("ProjectTypeList");
            ModelState.Remove("ServiceTypeList");
            ModelState.Remove("ProjectStateList");

            if (ModelState.IsValid)
            {
                ProjectDto projectDto = new ProjectDto
                {
                    Name = model.Name,
                    UserId = model.UserValue,
                    ClientId = model.ClientValue,
                    ServiceTypeId = model.ServiceTypeValue,
                    ProjectTypeId = model.ProjectTypeValue,
                    ProjectStateId = model.ProjectStateValue,
                    Budget = model.Budget

                };

                await projectRepository.Create(projectDto);
                var handleProject = new HandleProjectState(projectRepository, assignmentRepository, historicalProjectRepository);
                await handleProject.HandleProjectActive(projectDto.ProjectId);
                return RedirectToAction("Index");
            }

            return View(model);
        }

        #endregion
        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            ModelState.Clear();
            var project = await projectRepository.GetById(id);

            if (project == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            var model = new ProjectViewModel
            {
                Id = project.ProjectId,
                Name = project.Name,
                UserId = project.UserId,
                ClientId = project.ClientId,
                ProjectTypeId = project.ProjectTypeId,
                ProjectStateId = project.ProjectStateId ?? 0,
                Budget = project.Budget
            };

            var serviceTypeList = await serviceTypeRepository.GetAll();
            var projectTypeList = await projectTypeRepository.GetAll();
            var clientList = await clientRepository.GetAll();
            var userList = await userRepository.GetAll();
            var projectStateList = await projectStateRepository.GetAll();

            model.ClientValue = project.ClientId;
            model.UserValue = project.UserId;
            model.ProjectTypeValue = project.ProjectTypeId;
            model.ProjectStateValue = project.ProjectStateId ?? 0;
            model.ServiceTypeValue = project.ServiceTypeId;


            model.ServiceTypeList = serviceTypeList ?? Enumerable.Empty<ServiceTypeDto>();
            model.ProjectTypeList = projectTypeList ?? Enumerable.Empty<ProjectTypeDTO>();
            model.ClientList = clientList ?? Enumerable.Empty<ClientDto>();
            model.UserList = userList ?? Enumerable.Empty<UserDto>();
            model.ProjectStateList = projectStateList ?? Enumerable.Empty<ProjectStateDto>();


            return View(model);

        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProjectViewModel model)
        {
            ModelState.Remove("ClientList");
            ModelState.Remove("UserList");
            ModelState.Remove("ProjectTypeList");
            ModelState.Remove("ServiceTypeList");
            ModelState.Remove("ProjectStateList");

            if (ModelState.IsValid)
            {
                ProjectDto projectDto = new ProjectDto
                {
                    ProjectId = model.Id,
                    Name = model.Name,
                    ClientId = model.ClientValue,
                    UserId = model.UserValue,
                    ServiceTypeId = model.ServiceTypeValue,
                    ProjectTypeId = model.ProjectTypeValue,
                    ProjectStateId = model.ProjectStateValue,
                    Budget = model.Budget
                };

                await projectRepository.Update(projectDto);
                return RedirectToAction("Index");
            }
            return View(model);

        }

        #endregion
        #region Delete

        public async Task<ActionResult> Delete(int id)
        {
            var projectDto = await projectRepository.GetById(id);

            if (projectDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var projectViewModel = new ProjectViewModel
            {
                Name = projectDto.Name,
                UserId = projectDto.UserId,
                ClientId = projectDto.ClientId,
                ProjectTypeId = projectDto.ProjectTypeId,
                ProjectStateId = projectDto.ProjectStateId ?? 0,
            };

            return View(projectViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(int id)
        {
            var projectDto = await projectRepository.GetById(id);

            if (projectDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var handleProject = new HandleProjectState(projectRepository, assignmentRepository, historicalProjectRepository);
            await handleProject.HandleProjectInactive(projectDto.ProjectId);
            return RedirectToAction("Index");
        }

        #endregion

        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(string name)
        {
            bool alreadyExistCheck = await projectRepository.Exist(name);

            if (alreadyExistCheck)
            {
                return Json($"El nombre de proyecto {name} ya existe");
            }

            return Json(true);
        }

        #region Export

        [HttpGet]
        public async Task<FileResult> ExportToExcel()
        {
            var projectsWithDetails = await projectRepository.GetAllProjectWithDetails();
            var nombreArchivo = $"Listado de Proyectos con Detalles - {DateTime.Today.ToString("dd-MM-yyyy")}.xlsx";
            return GenerarExcel(nombreArchivo, projectsWithDetails);
        }

        private FileResult GenerarExcel(string nombreArchivo, IEnumerable<ProjectWithDetailDTO> projectsWithDetails)
        {
            DataTable dataTable = new DataTable("Proyectos con Detalles");
            dataTable.Columns.AddRange(new DataColumn[] {
                new DataColumn("Id de Proyecto"),
                new DataColumn("Nombre del Proyecto"),
                new DataColumn("Estado del Proyecto"),
                new DataColumn("Nombre Cliente"),
                new DataColumn("Apellido Cliente"),
                new DataColumn("Nombre Usuario"),
                new DataColumn("Apellido Usuario"),
                new DataColumn("Tipo de Proyecto")
            });

            foreach (var project in projectsWithDetails)
            {
                dataTable.Rows.Add(project.ProjectId, project.ProjectName, project.Description, project.ClientName, project.ClientLastName,
                    project.UserName, project.UserLastName, project.ProjectTypeName);
            }

            using (XLWorkbook wb = new XLWorkbook())
            {
                var ws = wb.Worksheets.Add(dataTable);

                // Ajustar el ancho de las columnas automáticamente
                ws.Columns().AdjustToContents();

                using (MemoryStream stream = new MemoryStream())
                {
                    wb.SaveAs(stream);
                    return File(stream.ToArray(),
                        "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
                        nombreArchivo);
                }
            }
        }
        #endregion

    }
}


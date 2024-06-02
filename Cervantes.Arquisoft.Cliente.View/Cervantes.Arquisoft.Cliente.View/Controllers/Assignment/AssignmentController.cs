using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.Data.Repositories.Assignment;
using Cervantes.Arquisoft.Data.Repositories.Project;
using Cervantes.Arquisoft.Usuario.Data;
using Cervantes.Arquisoft.View.Mappers;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Models.Assignment;
using Cervantes.Arquisoft.View.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class AssignmentController : Controller
    {
        private readonly ArquisoftDbContext _dbContext;
        private readonly IAssignmentRepository assignmentRepository;
        private readonly IProjectRepository projectRepository;
        private readonly ICurrentUserService currentUserService;
        private readonly IHubRepository HubRepository;
        private readonly IUserRepository UserRepository;
        private readonly IHistoricalProjectRepository historicalProjectRepository;



        public AssignmentController(IAssignmentRepository assignmentRepository, IProjectRepository projectRepository, ICurrentUserService currentUserService,
                                    IHubRepository hubRepository, IUserRepository userRepository, ArquisoftDbContext dbContext, IHistoricalProjectRepository historicalProjectRepository)
        {
            this.assignmentRepository = assignmentRepository;
            this.projectRepository = projectRepository;
            this.currentUserService = currentUserService;
            HubRepository = hubRepository;
            UserRepository = userRepository;
            _dbContext = dbContext;
            this.historicalProjectRepository = historicalProjectRepository;
        }

        #region Read
        public async Task<IActionResult> Index(int id)
        {
            var AssignmentDto = await assignmentRepository.GetAllByProjectId(id);
            var ProjectName = await projectRepository.GetProjectNameById(id);
            var HubList = await HubRepository.GetAllByProjectId(id);
            IEnumerable<AssignmentViewModel> AssignmentViewModels = AssignmentDto.Select(AssignmentDto => new AssignmentViewModel
            {
                AssignmentId = AssignmentDto.AssignmentId,
                ProjectId = AssignmentDto.ProjectId,
                AssignmentTypeId = AssignmentDto.AssignmentTypeId,
                AssignmentName = AssignmentDto.AssignmentName,
                AssignmentDescription = AssignmentDto.AssignmentDescription,
                IsCompleted = AssignmentDto.IsCompleted,
                NotVisible = AssignmentDto.NotVisible,
                IsStarted = AssignmentDto.IsStarted,
                IsSkipped = AssignmentDto.IsSkipped,
                StartedDate = AssignmentDto.StartedDate,
                CompletedDate = AssignmentDto.CompletedDate,
                SkippedDate = AssignmentDto.SkippedDate,
                OriginalDueDate = AssignmentDto.OriginalDueDate,
                HubList = HubList.Where(h => h.AssignmentId == AssignmentDto.AssignmentId),
                LastDueDate = HubList.Where(h => h.AssignmentId == AssignmentDto.AssignmentId && h.DueDate != null)
                    .OrderByDescending(h => h.DueDate)
                    .Select(h => h.DueDate)
                    .FirstOrDefault(),

            });


            return View(AssignmentViewModels);
        }
        [HttpGet]
        public async Task<IActionResult> Graph(int id)
        {
            var AssignmentDto = await assignmentRepository.GetAllByProjectId(id);

            IEnumerable<AssignmentViewModel> AssignmentViewModels = AssignmentDto.Select(AssignmentDto => new AssignmentViewModel
            {
                AssignmentId = AssignmentDto.AssignmentId,
                ProjectId = AssignmentDto.ProjectId,
                AssignmentTypeId = AssignmentDto.AssignmentTypeId,
                AssignmentName = AssignmentDto.AssignmentName,
                AssignmentDescription = AssignmentDto.AssignmentDescription,
                IsCompleted = AssignmentDto.IsCompleted,
                NotVisible = AssignmentDto.NotVisible,
                IsStarted = AssignmentDto.IsStarted,
                IsSkipped = AssignmentDto.IsSkipped,
                CompletedDate = AssignmentDto.CompletedDate,
                OriginalDueDate = AssignmentDto.OriginalDueDate,
                SkippedDate = AssignmentDto.SkippedDate,
                StartedDate = AssignmentDto.StartedDate,
            });
            return View(AssignmentViewModels);
        }

        #endregion


        #region Edit
        [HttpPost]
        public async Task<ActionResult> Start([FromBody] AssignmentViewModel assignment)
        {
            var dto = await assignmentRepository.GetById(assignment.AssignmentId);
            var HubList = await HubRepository.GetAllHubByAssigmentId(assignment.AssignmentId);
            var user = currentUserService.GetCurrentUser();
            if (user == null || string.IsNullOrEmpty(user.CurrentUserId) || string.IsNullOrEmpty(user.CurrentUserLastName))
            {
                // Manejar la situación donde user o sus propiedades son null o vacías
                return BadRequest("No se pudo obtener el usuario actual o algunas de sus propiedades son nulas o vacías.");
            }
            if (HubList.Count() == 0)
            {
                await HubRepository.CreateFirst(assignment.OriginalDueDate.Value, assignment.AssignmentId, Int16.Parse(user.CurrentUserId), user.CurrentUserLastName);
                HubList = await HubRepository.GetAllHubByAssigmentId(assignment.AssignmentId);
            }


            if (dto == null)
            {
                return RedirectToAction("NotFound", this);
            }
            dto.OriginalDueDate = assignment.OriginalDueDate;
            dto.IsStarted = true;
            dto.StartedDate = DateTime.Now;

            await assignmentRepository.Update(dto);
            var handleProject = new HandleProjectState(projectRepository, assignmentRepository, historicalProjectRepository);
            await handleProject.HandleProjectStarted(assignment.ProjectId);
            var assignmentViewModel = AssignmentMapper.FromDtoToViewModel(dto);

            return Json(new { redirectUrl = Url.Action("Index", "Assignment", new { id = dto.ProjectId }) });

        }


        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var assignment = await assignmentRepository.GetById(id);
            var model = AssignmentMapper.FromDtoToViewModel(assignment);

            var HubList = await HubRepository.GetAllHubByAssigmentId(assignment.AssignmentId);
            var userList = await UserRepository.GetAll();
            var user = currentUserService.GetCurrentUser();

            model.CurrentUser = user != null ? user.CurrentUserId : "1";
            model.UserList = userList ?? Enumerable.Empty<UserDto>();
            model.HubList = HubList;

            model.OriginalDueDate = assignment.OriginalDueDate;

            var lastHubWithDueDate = HubList.Where(hub => hub.DueDate != null)
                                             .OrderByDescending(hub => hub.DueDate)
                                             .FirstOrDefault();

            model.LastDueDate = lastHubWithDueDate?.DueDate;
            model.StartedDate = assignment.StartedDate;

            if (model is null)
            {
                return RedirectToAction("NotFound", this);
            }

            return View(model);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AssignmentViewModel AssignmentViewModel)
        {

            var lastAssignmnetDto = await assignmentRepository.GetById(AssignmentViewModel.AssignmentId);
            AssignmentViewModel.AssignmentTypeId = AssignmentViewModel.AssignmentTypeId;
            var assignmentDto = AssignmentMapper.FromViewModelToDto(AssignmentViewModel);


            await assignmentRepository.UpdateTitleDesc(assignmentDto);
            return RedirectToAction("Index", "Assignment", new { id = assignmentDto.ProjectId });

        }
        #endregion

        #region Hub

        [HttpPost]
        public async Task<ActionResult> NewHub([FromForm] HubViewModel hub, IFormFile fileInput)
        {
            try
            {

                switch (hub.ItemSelect)
                {
                    case 1:

                        hub.IsCommitment = true;
                        hub.IsAttachment = false;
                        break;
                    case 2:

                        hub.IsCommitment = false;
                        hub.IsAttachment = true;
                        break;
                    case 3:
                        hub.IsCommitment = true;
                        hub.IsAttachment = true;
                        break;
                    default:
                        break;
                }

                var hubEntity = new HubDto
                {
                    AssignmentId = hub.AssignmentId,
                    HubDate = DateTime.Now,
                    IsCommitment = hub.IsCommitment,
                    IsAttachment = hub.IsAttachment

                };

                if (hub.IsCommitment)
                {
                    hubEntity.DueDate = hub.DueDate;
                    hubEntity.Note = hub.Note;
                    hubEntity.UserId = (int)hub.UserId;
                    hubEntity.UserName = hub.UserName;
                }

                if (hub.IsAttachment && fileInput != null && fileInput.Length > 0)
                {
                    using (var memoryStream = new MemoryStream())
                    {
                        await fileInput.CopyToAsync(memoryStream);
                        hubEntity.AttachmentData = memoryStream.ToArray();
                    }
                    hubEntity.ContentType = fileInput.ContentType;
                    hubEntity.FileName = fileInput.FileName;
                    hubEntity.FileDescription = hub.FileDescription;
                    hubEntity.UserId = (int)hub.UserId;
                    hubEntity.UserName = hub.UserName;
                    hubEntity.Note = "Solo adjunto";
                }

                await HubRepository.CreateWithAttachment(hubEntity);

                var jsonResult = new
                {
                    assignmentId = hub.AssignmentId,
                    redirectUrl = Url.Action("Edit", "Assignment", new { id = hub.AssignmentId })
                };


                return Json(jsonResult);
            }
            catch (Exception ex)
            {
                return StatusCode(500, $"Error al guardar en la base de datos: {ex.Message}");
            }
        }
        #endregion


        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int hubId, string reason)
        {
            await HubRepository.DeleteWithReason(hubId, reason);
            return Json(new { success = true, message = "Elemento eliminado correctamente." });
        }


        [HttpPost]
        public async Task<IActionResult> DeleteId(int id)
        {
            var AssignmentDto = await assignmentRepository.GetById(id);
            if (AssignmentDto == null)
            {
                return RedirectToAction("NotFound", this);
            }
            await assignmentRepository.Delete(id);
            return RedirectToAction("Index");
        }

        #endregion



        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(string name)
        {
            var alreadyExistCheck = await assignmentRepository.Exist(name);
            if (alreadyExistCheck)
            {
                return Json($"El tipo de tarea {name} ya existe");
            }
            return Json(true);
        }


        [HttpPost]
        public async Task<IActionResult> ToggleComplete([FromBody] AssignmentViewModel model)
        {
            AssignmentDTO currentStatus = await assignmentRepository.GetAssignmentStatus(model.AssignmentId);
            if (currentStatus.IsSkipped)
            {
                await assignmentRepository.UpdateSkippedStatus(model.AssignmentId);
            }
            AssignmentDTO newStatus = await assignmentRepository.UpdateCompletionStatus(model.AssignmentId);
            var handleProject = new HandleProjectState(projectRepository, assignmentRepository, historicalProjectRepository);
            await handleProject.HandleProjectCompletion(model.ProjectId);
            return Json(new { redirectUrl = Url.Action("Edit", "Assignment", new { id = model.AssignmentId }) });
        }

        [HttpPost]
        public async Task<IActionResult> ToggleSkipped([FromBody] AssignmentViewModel model)
        {
            // Obtener el estado actual de la tarea
            AssignmentDTO currentStatus = await assignmentRepository.GetAssignmentStatus(model.AssignmentId);

            // Si la tarea está completa, cambiar su estado a no completa
            if (currentStatus.IsCompleted)
            {
                await assignmentRepository.UpdateCompletionStatus(model.AssignmentId);
            }

            // Cambiar el estado de la tarea a omitida
            AssignmentDTO newStatus = await assignmentRepository.UpdateSkippedStatus(model.AssignmentId);

            return Json(new { redirectUrl = Url.Action("Edit", "Assignment", new { id = model.AssignmentId }) });
        }

        [HttpPost]
        public async Task<IActionResult> ToggleVisible([FromBody] AssignmentViewModel model)
        {
            AssignmentDTO newStatus = await assignmentRepository.UpdateVisibledStatus(model.AssignmentId);
            return Json(new { redirectUrl = Url.Action("Edit", "Assignment", new { id = model.AssignmentId }) });
        }

        [HttpGet]
        public async Task<IActionResult> DownloadFile(int hubId)
        {
            (byte[] fileBytes, string fileName, string contentType) = await HubRepository.GetAttachmentData(hubId);
            if (fileBytes == null)
            {
                return NotFound();
            }
            return File(fileBytes, contentType ?? "application/octet-stream", fileName ?? "nombre_archivo");
        }


    }
}
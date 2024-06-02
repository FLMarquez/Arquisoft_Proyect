using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class ProjectTypeController : Controller
    {
        private readonly IProjectTypeRepository projectTypeRepository;

        public ProjectTypeController(IProjectTypeRepository projectTypeRepository)
        {
            this.projectTypeRepository = projectTypeRepository;
        }

        #region Read
        public async Task<IActionResult> Index()
        {
            var projectTypeDto = await projectTypeRepository.GetAll();

            IEnumerable<ProjectTypeViewModel> projectTypeViewModels = projectTypeDto.Select(projectTypeDto => new ProjectTypeViewModel
            {
                ProjectTypeId = projectTypeDto.ProjectTypeId,
                ProjectTypeName = projectTypeDto.ProjectTypeName,
                ProjectTypeDescription = projectTypeDto.ProjectTypeDescription,
                RangeMax = projectTypeDto.RangeMax,
                RangeMin = projectTypeDto.RangeMin,
                ProfessionalFee = projectTypeDto.ProfessionalFee


            });

            return View(projectTypeViewModels);
        }

        #endregion
        #region Create

        public async Task<IActionResult> Create()
        {
            var projecTypeModel = new ProjectTypeViewModel();

            return View(projecTypeModel);
        }



        [HttpPost]
        public async Task<IActionResult> Create(ProjectTypeViewModel projectTypeViewModel)
        {
            // Calcular la diferencia entre RangeMax y RangeMin antes de la validación del modelo
            projectTypeViewModel.CalculateCompareRange();

            // Verificar si el tipo de proyecto ya existe
            var alreadyExist = await projectTypeRepository.Exist(projectTypeViewModel.ProjectTypeName);

            if (alreadyExist)
            {
                ModelState.AddModelError("ProjectTypeName", $"El tipo de proyecto {projectTypeViewModel.ProjectTypeName} ya existe.");
            }
            else
            {
                // Si no existe, puedes permitir la edición de campos adicionales
                if (ModelState.IsValid)
                {
                    projectTypeViewModel.CalculateCompareRange();  // Agrega esta línea para calcular el rango antes de la validación


                    var projectTypeDto = new ProjectTypeDTO
                    {
                        ProjectTypeId = projectTypeViewModel.ProjectTypeId,
                        ProjectTypeName = projectTypeViewModel.ProjectTypeName,
                        ProjectTypeDescription = projectTypeViewModel.ProjectTypeDescription,
                        RangeMax = projectTypeViewModel.RangeMax,
                        RangeMin = projectTypeViewModel.RangeMin,
                        ProfessionalFee = projectTypeViewModel.ProfessionalFee
                    };

                    await projectTypeRepository.Create(projectTypeDto);
                    return RedirectToAction("Index");

                }
            }

            return View(projectTypeViewModel);
        }

        #endregion
        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var projectTypeDto = await projectTypeRepository.GetById(id);

            var projectTypeViewModel = new ProjectTypeViewModel
            {
                ProjectTypeId = projectTypeDto.ProjectTypeId,
                ProjectTypeName = projectTypeDto.ProjectTypeName,
                ProjectTypeDescription = projectTypeDto.ProjectTypeDescription,
                RangeMax = projectTypeDto.RangeMax,
                RangeMin = projectTypeDto.RangeMin,
                ProfessionalFee = projectTypeDto.ProfessionalFee

            };

            if (projectTypeViewModel is null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(projectTypeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ProjectTypeViewModel projectTypeViewModel)
        {

            projectTypeViewModel.CalculateCompareRange();  // Agrega esta línea para calcular el rango antes de la validación


            if (ModelState.IsValid)
            {


                var projectTypeDto = new ProjectTypeDTO
                {
                    ProjectTypeId = projectTypeViewModel.ProjectTypeId,
                    ProjectTypeName = projectTypeViewModel.ProjectTypeName,
                    ProjectTypeDescription = projectTypeViewModel.ProjectTypeDescription,
                    RangeMax = projectTypeViewModel.RangeMax,
                    RangeMin = projectTypeViewModel.RangeMin,
                    ProfessionalFee = projectTypeViewModel.ProfessionalFee
                };



                await projectTypeRepository.Update(projectTypeDto);
                return RedirectToAction("Index");

            }

            return View(projectTypeViewModel);
        }

        #endregion
        #region Delete

        public async Task<ActionResult> Delete(int id)
        {

            var projectTypeDto = await projectTypeRepository.GetById(id);

            if (projectTypeDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var projectTypeViewModel = new ProjectTypeViewModel
            {
                ProjectTypeId = projectTypeDto.ProjectTypeId,
                ProjectTypeName = projectTypeDto.ProjectTypeName,
                ProjectTypeDescription = projectTypeDto.ProjectTypeDescription,
                RangeMax = projectTypeDto.RangeMax,
                RangeMin = projectTypeDto.RangeMin,
                ProfessionalFee = projectTypeDto.ProfessionalFee
            };

            return View(projectTypeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(int projectTypeId)
        {
            var projectTypeDto = await projectTypeRepository.GetById(projectTypeId);

            if (projectTypeDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            await projectTypeRepository.Delete(projectTypeId);
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
            var alreadyExistCheck = await projectTypeRepository.Exist(name);

            if (alreadyExistCheck)
            {
                return Json($"El tipo de proyecto {name} ya existe");
            }

            return Json(true);
        }


    }
}
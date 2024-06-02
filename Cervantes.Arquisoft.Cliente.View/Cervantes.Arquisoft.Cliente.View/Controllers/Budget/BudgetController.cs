using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class BudgetController : Controller
    {
        private readonly IBudgetRepository budgetRepository;
        // private readonly IServiceTypeRepository serviceTypeRepository;
        //private readonly IProjectTypeRepository projectTypeRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IClientRepository clientRepository;
        //private readonly IUserRepository userRepository;
        private readonly IBudgetStateRepository budgetStateRepository;

        public BudgetController(IBudgetRepository budgetRepository)
        {
            this.budgetRepository = budgetRepository;
        }

        #region Read
        public async Task<IActionResult> Index()
        {
            var budgetDto = await budgetRepository.GetAll();

            IEnumerable<BudgetViewModel> budgetViewModels = budgetDto.Select(budgetDto => new BudgetViewModel
            {
                BudgetId = budgetDto.BudgetId,
                ProjectId = budgetDto.ProjectId,
                BudgetDesciption = budgetDto.BudgetDescription,
                BudgetStateId = budgetDto.BudgetStateId,
            });

            return View(budgetViewModels);
        }

        #endregion
        #region Create

        public async Task<IActionResult> Create()
        {
            var budgetModel = new BudgetViewModel();

            return View(budgetModel);
        }



        [HttpPost]
        public async Task<IActionResult> Create(BudgetViewModel budgetViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(budgetViewModel);
            }

            var budgetDto = new BudgetDTO
            {
                BudgetId = budgetViewModel.BudgetId,
                ProjectId = budgetViewModel.ProjectId,
                BudgetDescription = budgetViewModel.BudgetDesciption,
                BudgetStateId = 1,
                DueDate = DateTime.Now.AddDays(14),
                ProjectSquareMeters = budgetViewModel.ProjectSquareMeters,
                CostPerSquareMeters = budgetViewModel.CostPerSquareMeters,
            };
            //var alreadyExist = await budgetRepository.Exist(budgetDto.Project.Name);

            //if (alreadyExist)
            //{
            //    ModelState.AddModelError(budgetDto.Project.Name, $"El persupuesto para el proyecto {budgetDto.Project.Name} ya existe.");
            //    return View(budgetViewModel);
            //}

            await budgetRepository.Create(budgetDto);
            return RedirectToAction("Index");
        }

        #endregion
        //#region Edit

        //[HttpGet]
        //public async Task<ActionResult> Edit(int id)
        //{
        //    var projectTypeDto = await projectTypeRepository.GetById(id);

        //    var projectTypeViewModel = new ServiceTypeViewModel
        //    {
        //        Id = projectTypeDto.ServiceTypeId,
        //        ServiceTypeName = projectTypeDto.ServiceTypeName,
        //        ServiceTypeDescription = projectTypeDto.ServiceTypeDescription,
        //    };

        //    if (projectTypeViewModel is null)
        //    {
        //        return RedirectToAction("NotFound", "Home");
        //    }

        //    return View(projectTypeViewModel);
        //}

        //[HttpPost]
        //public async Task<ActionResult> Edit(ServiceTypeViewModel projectTypeViewModel)
        //{
        //    var projectTypeDto = new ServiceTypeDto
        //    {
        //        ServiceTypeId = projectTypeViewModel.Id,
        //        ServiceTypeName = projectTypeViewModel.ServiceTypeName,
        //        ServiceTypeDescription = projectTypeViewModel.ServiceTypeDescription,
        //    };

        //    var clienteExiste = await projectTypeRepository.Exist(projectTypeViewModel.ServiceTypeName);

        //    if (clienteExiste)
        //    {
        //        return RedirectToAction("NotFound", "Home");
        //    }

        //    await projectTypeRepository.Update(projectTypeDto);
        //    return RedirectToAction("Index");
        //}

        //#endregion
        //#region Delete

        //public async Task<ActionResult> Delete(int id)
        //{

        //    var projectTypeDto = await projectTypeRepository.GetById(id);

        //    if (projectTypeDto == null)
        //    {
        //        return RedirectToAction("NotFound", "Home");
        //    }

        //    var projectTypeViewModel = new ServiceTypeViewModel
        //    {
        //        Id = projectTypeDto.ServiceTypeId,
        //        ServiceTypeName = projectTypeDto.ServiceTypeName,
        //        ServiceTypeDescription = projectTypeDto.ServiceTypeDescription,
        //    };

        //    return View(projectTypeViewModel);
        //}

        //[HttpPost]
        //public async Task<IActionResult> DeleteId(int id)
        //{
        //    var projectTypeDto = await projectTypeRepository.GetById(id);

        //    if (projectTypeDto == null)
        //    {
        //        return RedirectToAction("NotFound", "Home");
        //    }
        //    await projectTypeRepository.Delete(id);
        //    return RedirectToAction("Index");
        //}

        //#endregion

        //public IActionResult NotFound()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(string name)
        {
            var alreadyExistCheck = await budgetRepository.Exist(name);

            if (alreadyExistCheck)
            {
                return Json($"El presupuesto para el proyecto {name} ya existe");
            }

            return Json(true);
        }

    }
}

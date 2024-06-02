using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.Data.Services;
using Cervantes.Arquisoft.View.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class ServiceTypeController : Controller
    {
        private readonly IServiceTypeRepository serviceTypeRepository;

        public ServiceTypeController(IServiceTypeRepository serviceTypeRepository)
        {
            this.serviceTypeRepository = serviceTypeRepository;
        }

        #region Read
        public async Task<IActionResult> Index()
        {
            var serviceTypeDto = await serviceTypeRepository.GetAll();

            IEnumerable<ServiceTypeViewModel> serviceTypeViewModels = serviceTypeDto.Select(serviceTypeDto => new ServiceTypeViewModel
            {
                Id = serviceTypeDto.ServiceTypeId,
                ServiceTypeName = serviceTypeDto.ServiceTypeName,
                ServiceTypeDescription = serviceTypeDto.ServiceTypeDescription,


            });

            return View(serviceTypeViewModels);
        }

        #endregion
        #region Create

        public async Task<IActionResult> Create()
        {
            var serviceTypeModel = new ServiceTypeViewModel();

            return View(serviceTypeModel);
        }



        [HttpPost]
        public async Task<IActionResult> Create(ServiceTypeViewModel serviceTypeViewModel)
        {
            if (!ModelState.IsValid)
            {
                return View(serviceTypeViewModel);
            }

            var serviceTypeDto = new ServiceTypeDto
            {
                ServiceTypeId = serviceTypeViewModel.Id,
                ServiceTypeName = serviceTypeViewModel.ServiceTypeName,
                ServiceTypeDescription = serviceTypeViewModel.ServiceTypeDescription,

            };
            var alreadyExist = await serviceTypeRepository.Exist(serviceTypeDto.ServiceTypeName);

            if (alreadyExist)
            {
                ModelState.AddModelError(serviceTypeDto.ServiceTypeName, $"El tipo de proyecto {serviceTypeDto.ServiceTypeName} ya existe.");
                return View(serviceTypeViewModel);
            }

            await serviceTypeRepository.Create(serviceTypeDto);
            return RedirectToAction("Index");
        }

        #endregion
        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var serviceTypeDto = await serviceTypeRepository.GetById(id);

            var serviceTypeViewModel = new ServiceTypeViewModel
            {
                Id = serviceTypeDto.ServiceTypeId,
                ServiceTypeName = serviceTypeDto.ServiceTypeName,
                ServiceTypeDescription = serviceTypeDto.ServiceTypeDescription,
            };

            if (serviceTypeViewModel is null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(serviceTypeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(ServiceTypeViewModel serviceTypeViewModel)
        {
            var serviceTypeDto = new ServiceTypeDto
            {
                ServiceTypeId = serviceTypeViewModel.Id,
                ServiceTypeName = serviceTypeViewModel.ServiceTypeName,
                ServiceTypeDescription = serviceTypeViewModel.ServiceTypeDescription,
            };

            var clienteExiste = await serviceTypeRepository.Exist(serviceTypeViewModel.ServiceTypeName);

            if (clienteExiste)
            {
                return RedirectToAction("NotFound", "Home");
            }

            await serviceTypeRepository.Update(serviceTypeDto);
            return RedirectToAction("Index");
        }

        #endregion
        #region Delete

        public async Task<ActionResult> Delete(int id)
        {

            var serviceTypeDto = await serviceTypeRepository.GetById(id);

            if (serviceTypeDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var serviceTypeViewModel = new ServiceTypeViewModel
            {
                Id = serviceTypeDto.ServiceTypeId,
                ServiceTypeName = serviceTypeDto.ServiceTypeName,
                ServiceTypeDescription = serviceTypeDto.ServiceTypeDescription,
            };

            return View(serviceTypeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(int id)
        {
            var serviceTypeDto = await serviceTypeRepository.GetById(id);

            if (serviceTypeDto == null)
            {
                return RedirectToAction("NotFound", "Home");
            }
            await serviceTypeRepository.Delete(id);
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
            var alreadyExistCheck = await serviceTypeRepository.Exist(name);

            if (alreadyExistCheck)
            {
                return Json($"El tipo de proyecto {name} ya existe");
            }

            return Json(true);
        }


    }
}

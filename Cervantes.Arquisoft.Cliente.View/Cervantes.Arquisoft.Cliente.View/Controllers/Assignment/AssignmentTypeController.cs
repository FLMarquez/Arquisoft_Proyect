using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories.Assignment;
using Cervantes.Arquisoft.View.Mappers;
using Cervantes.Arquisoft.View.Models;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class AssignmentTypeController : Controller
    {
        private readonly IAssignmentTypeRepository AssignmentTypeRepository;
        private readonly IServiceTypeRepository ServiceTypeRepository;

        public AssignmentTypeController(IAssignmentTypeRepository AssignmentTypeRepository, IServiceTypeRepository ServiceTypeRepository)
        {
            this.AssignmentTypeRepository = AssignmentTypeRepository;
            this.ServiceTypeRepository = ServiceTypeRepository;
        }

        #region Read
        public async Task<IActionResult> Index(int id)
        {
            var model = new AssignmentTypeViewModel();
            var ServiceName = await ServiceTypeRepository.GetServiceTypeNameById(id);

            model.ServiceTypeName = ServiceName;
            model.ServiceTypeId = id;
            model.AssignmentTypeList = await AssignmentTypeRepository.GetAllByServiceId(id);
            //var model = new AssignmentTypeViewModel();
            //model.AssignmentTypeList = AssignmentTypeDtoList;
            //model.AssignmentTypeName = ServiceName;

            return View(model);
        }

        #endregion
        #region Create

        public async Task<IActionResult> Create(int id)
        {
            var assignmentTypeViewModel = new AssignmentTypeViewModel();
            assignmentTypeViewModel.ServiceTypeId = id;
            assignmentTypeViewModel.ServiceTypeName = await ServiceTypeRepository.GetServiceTypeNameById(id);
            return View(assignmentTypeViewModel);
        }



        [HttpPost]
        public async Task<IActionResult> Create(AssignmentTypeViewModel AssignmentTypeViewModel)
        {
            ModelState.Remove("AssignmentTypeList");

            if (!ModelState.IsValid)
            {
                return View(AssignmentTypeViewModel);
            }

            var AssignmentTypeDto = AssignmentTypeMapper.FromViewModelToDto(AssignmentTypeViewModel);
            var ServiceId = AssignmentTypeDto.ServiceTypeId;

            var alreadyExist = await AssignmentTypeRepository.Exist(AssignmentTypeDto.AssignmentTypeName);

            if (alreadyExist)
            {
                ModelState.AddModelError(AssignmentTypeDto.AssignmentTypeName, $"El tipo de tarea {AssignmentTypeDto.AssignmentTypeName} ya existe.");
                return View(AssignmentTypeViewModel);
            }

            await AssignmentTypeRepository.Create(AssignmentTypeDto);
            return RedirectToAction("Index", "AssignmentType", new { id = ServiceId });
        }

        #endregion
        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var AssignmentTypeDto = await AssignmentTypeRepository.GetById(id);

            var AssignmentTypeViewModel = AssignmentTypeMapper.FromDtoToViewModel(AssignmentTypeDto);

            AssignmentTypeViewModel.ServiceTypeName =
                await ServiceTypeRepository.GetServiceTypeNameById(AssignmentTypeDto.ServiceTypeId);

            if (AssignmentTypeViewModel is null)
            {
                return RedirectToAction("NotFound", this);
            }

            return View(AssignmentTypeViewModel);
        }

        [HttpPost]
        public async Task<ActionResult> Edit(AssignmentTypeViewModel AssignmentTypeViewModel)
        {
            var AssignmentTypeDto = AssignmentTypeMapper.FromViewModelToDto(AssignmentTypeViewModel);
            var ServiceId = AssignmentTypeDto.ServiceTypeId;
            //var clienteExiste = await AssignmentTypeRepository.Exist(AssignmentTypeViewModel.AssignmentTypeName);

            //if (clienteExiste)
            //{
            //    return RedirectToAction("NotFound", this);
            //}

            await AssignmentTypeRepository.Update(AssignmentTypeDto);
            return RedirectToAction("Index", "AssignmentType", new { id = ServiceId });
        }

        #endregion
        #region Delete

        public async Task<ActionResult> Delete(int id)
        {

            var AssignmentTypeDto = await AssignmentTypeRepository.GetById(id);

            if (AssignmentTypeDto == null)
            {
                return RedirectToAction("NotFound", this);
            }

            var AssignmentTypeViewModel = AssignmentTypeMapper.FromDtoToViewModel(AssignmentTypeDto);

            return View(AssignmentTypeViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(int AssignmentTypeId)
        {
            var AssignmentTypeDto = await AssignmentTypeRepository.GetById(AssignmentTypeId);
            var ServiceId = AssignmentTypeDto.ServiceTypeId;

            if (AssignmentTypeDto == null)
            {
                return RedirectToAction("NotFound", this);
            }
            await AssignmentTypeRepository.Delete(AssignmentTypeId);
            return RedirectToAction("Index", "AssignmentType", new { id = ServiceId });
        }

        #endregion

        //public IActionResult NotFound()
        //{
        //    return View();
        //}

        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(string name)
        {
            var alreadyExistCheck = await AssignmentTypeRepository.Exist(name);

            if (alreadyExistCheck)
            {
                return Json($"El tipo de tarea {name} ya existe");
            }

            return Json(true);
        }


        [HttpPost]
        public async Task<IActionResult> Sorter([FromBody] int[] ids)
        {
            int serviceType = 0; // Declarar la variable ServiceType como nullable int

            // Captura el valor de 'X-IdService' desde los encabezados
            if (Request.Headers.TryGetValue("X-IdService", out var idServiceHeaderValue))
            {
                if (int.TryParse(idServiceHeaderValue, out var idService))
                {
                    // Asigna el valor de idService a la variable ServiceType
                    serviceType = idService;
                }
            }

            var AssignmentTypeDtoList = await AssignmentTypeRepository.GetAllByServiceId(serviceType);
            var idsAssignmentType = AssignmentTypeDtoList.Select(x => x.AssignmentTypeId);

            var AssignmentTypeDtoSorted = ids.Select((value, index) => new AssignmentTypeDTO() { AssignmentTypeId = value, Order = index + 1 }).AsEnumerable();

            await AssignmentTypeRepository.Sorter(AssignmentTypeDtoSorted);

            return Ok();
        }

    }
}

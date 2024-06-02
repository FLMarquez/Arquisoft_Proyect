using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Application.DTOs.Budget;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.View.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.CodeAnalysis;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class PaymentController : Controller
    {
        private readonly IPaymentRepository paymentRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IPaymentMethodRepository paymentMethodRepository;
        private readonly IClientRepository clientRepository;
        private readonly IProjectTypeRepository projectTypeRepository;
        private int _idProject;
        public PaymentController(IPaymentRepository paymentRepository, IProjectRepository projectRepository, IPaymentMethodRepository paymentMethodRepository, IClientRepository clientRepository, IProjectTypeRepository projectTypeRepository)
        {
            this.paymentRepository = paymentRepository;
            this.projectRepository = projectRepository;
            this.paymentMethodRepository = paymentMethodRepository;
            this.clientRepository = clientRepository;
            this.projectTypeRepository = projectTypeRepository;
        }

        #region Read
        public async Task<IActionResult> Index(int id)
        {
            var paymentDto = await paymentRepository.GetPaymentByProjectId(id);
            var projectDto = await projectRepository.GetById(id);
            var methodsDto = await paymentMethodRepository.GetAll();
            var clientDto = await clientRepository.GetById(projectDto.ClientId);
            var projectType = await projectTypeRepository.GetById(projectDto.ProjectTypeId);

            decimal totalAmount = paymentDto.Where(x => x.IsDeleted == false || x.IsDeleted == null).Sum(x => x.Amount);
            decimal totalBalance =
                (projectDto != null && projectDto.Budget != null ? projectDto.Budget : 0) +
                (projectType != null && projectType.ProfessionalFee != null ? projectType.ProfessionalFee : 0) -
                (paymentDto != null ? paymentDto.Where(x => x.IsDeleted == false || x.IsDeleted == null).Sum(x => x.Amount != null ? x.Amount : 0) : 0);

            decimal currentAmount;
            decimal currentBalance = 0;

            if (projectDto != null && projectDto.Budget != null)
            {
                currentBalance += projectDto.Budget;
            }

            if (projectType != null && projectType.ProfessionalFee != null)
            {
                currentBalance += projectType.ProfessionalFee;
            }
            decimal balance = 0;

            if (projectDto != null && projectDto.Budget != null)
            {
                balance += projectDto.Budget;
            }

            if (projectType != null && projectType.ProfessionalFee != null)
            {
                balance += projectType.ProfessionalFee;
            }

            if (paymentDto == null)
                return NotFound();

            List<PaymentViewModel> paymentViewModels = new List<PaymentViewModel>();

            foreach (var p in paymentDto)
            {
                // Accede a las propiedades de p y realiza las operaciones necesarias
                if (p.IsDeleted == false || p.IsDeleted == null)
                {
                    currentBalance -= p.Amount;
                }

                // Crea un nuevo PaymentViewModel y agrégalo a la lista
                var paymentViewModel = new PaymentViewModel
                {
                    PaymentId = p.PaymentId,
                    PaymentMethodId = p.PaymentMethodId,
                    Amount = p.Amount,
                    PaymentDate = p.PaymentDate,
                    ProjectId = p.ProjectId,
                    ProjectName = projectDto.Name,
                    MethodName = methodsDto.FirstOrDefault(m => m.PaymentMethodId == p.PaymentMethodId)?.MethodName,
                    Balance = currentBalance,
                    IsDeleted = p.IsDeleted ?? false,
                    DeletedReason = p.DeletedReason
                };

                paymentViewModels.Add(paymentViewModel);
            }



            var model = new PaymentMethodViewModelList
            {
                ProjectId = projectDto.ProjectId,
                ProjectName = projectDto.Name,
                ProjectBudget = ((projectDto != null && projectDto.Budget != null) ? projectDto.Budget : 0) + ((projectType != null && projectType.ProfessionalFee != null) ? projectType.ProfessionalFee : 0),
                PaymentList = paymentViewModels,
                TotalBalance = totalBalance,
                TotalAmount = totalAmount,
                ClientName = clientDto.LastName + ", " + clientDto.Name
            };

            return View(model);
        }



        #endregion

        #region Create
        public async Task<IActionResult> Create(int id)
        {
            _idProject = id;

            var ultimoPaymentId = await paymentRepository.GetLastId();
            if (ultimoPaymentId == null)
            {
                ultimoPaymentId = 1;
            }
            int lastestPaymentId = ultimoPaymentId;

            var model = new PaymentViewModel();
            model.PaymentMethodList = await paymentMethodRepository.GetAll() ?? Enumerable.Empty<PaymentMethodDTO>();
            model.PaymentId = lastestPaymentId;
            model.ProjectId = _idProject;

            ModelState.Clear();
            return View(model);
        }


        [HttpPost]
        public async Task<IActionResult> Create(PaymentViewModel model)
        {

            ModelState.Remove("PaymentMethodList");

            if (ModelState.IsValid)
            {
                var paymentDTO = new PaymentDTO
                {
                    PaymentId = model.PaymentId,
                    PaymentMethodId = (int)model.PaymentMethodValue,
                    ProjectId = model.ProjectId,
                    PaymentDate = DateTime.Now,
                    Amount = model.Amount,
                };

                await paymentRepository.Create(paymentDTO);
                return RedirectToAction("Index", "Payment", new { id = model.ProjectId });
            }
            model.PaymentMethodList = await paymentMethodRepository.GetAll() ?? Enumerable.Empty<PaymentMethodDTO>();
            return View(model);
        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {
            var PaymentDTO = await paymentRepository.GetById(id);

            var PaymentViewModel = new PaymentViewModel
            {
                PaymentId = PaymentDTO.PaymentId,
                PaymentDate = PaymentDTO.PaymentDate = DateTime.Now,
                Amount = PaymentDTO.Amount,
            };

            if (PaymentViewModel is null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            return View(PaymentViewModel);
        }


        #endregion

        #region Delete

        #region Delete
        [HttpGet]
        public async Task<IActionResult> Delete(int paymentId, string reason)
        {
            await paymentRepository.DeleteWithReason(paymentId, reason);
            return Json(new { success = true, message = "Elemento eliminado correctamente." });
        }


        #endregion

        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(int id)
        {
            var alreadyExistCheck = await paymentRepository.Exist(id);

            if (alreadyExistCheck)
            {
                return Json($"El número de Cobro {id} ya existe");
            }

            return Json(true);
        }

        #endregion

    }
}


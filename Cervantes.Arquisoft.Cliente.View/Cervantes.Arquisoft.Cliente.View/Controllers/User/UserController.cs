using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class UserController : Controller
    {
        private readonly IUserRepository userRepository;
        //TODO: Is CurrentUserService Used?
        private readonly ICurrentUserService currentUserService;
        private readonly IUserRoleRepository userRoleRepository;
        private readonly IStadisticsRepository stadisticsRepository;
        private readonly IDataProjectRepository dataProjectRepository;

        public UserController(IUserRepository userRepository,
                                ICurrentUserService currentUserService,
                                IUserRoleRepository userRoleRepository,
                                IStadisticsRepository stadisticsRepository,
                                IDataProjectRepository dataProjectRepository)
        {
            this.userRepository = userRepository;
            this.currentUserService = currentUserService;
            this.userRoleRepository = userRoleRepository;
            this.stadisticsRepository = stadisticsRepository;
            this.dataProjectRepository = dataProjectRepository;
        }





        #region Dashboard
        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var viewModel = new DashboardUserViewModel();

            viewModel.UsuariosHistoricosPorEstado = stadisticsRepository.GetCantidadUsuariosPorEstado();
            viewModel.UsuariosActivosPorEstados = stadisticsRepository.GetCantidadUsuariosActivosPorEstado();
            viewModel.ProyectosPorTipo = stadisticsRepository.GetCantidadProyectosPorEstado();
            viewModel.ClientesHistoricosPorEstado = stadisticsRepository.GetCantidadClientesPorEstado();
            viewModel.ClientesActivosPorEstado = stadisticsRepository.GetCantidadClientesActivosPorEstado();
            viewModel.NombreUltimoCliente = stadisticsRepository.GetNombreUltimoCliente();
            viewModel.NombreUltimoUsuario = stadisticsRepository.GetNombreUltimoUsuario();
            viewModel.NombreUltimoProyecto = stadisticsRepository.GetNombreUltimoProyecto();
            viewModel.PorcentajeProyectosPorTipo = stadisticsRepository.CalcularPorcentajeProyectosPorTipo();

            viewModel.DataProjectStateList = await dataProjectRepository.GetProjectStateData();
            viewModel.DataProjectTypeList = await dataProjectRepository.GetProjectTypeData();
            viewModel.Amount_MethodList = await dataProjectRepository.GetAmount_Method();
            viewModel.ProjectType_AmountList = await dataProjectRepository.GetProjectType_Amount();
            viewModel.Amount_TimeList = await dataProjectRepository.GetAmount_Time();


            return View(viewModel);
        }
        #endregion

        #region Read
        public async Task<IActionResult> List()
        {
            var userDto = await userRepository.GetAll();
            //TODO: Change userDto paramater to x in linq?
            IEnumerable<UserViewModel> userViewModels = userDto.Select(userDto => new UserViewModel
            {
                Id = userDto.UserId,
                Name = userDto.Name,
                LastName = userDto.LastName,
                Password = userDto.Password,
                DocumentNumber = userDto.DocumentNumber,
                Mail = userDto.Mail,
                Telephone = userDto.Telephone,
                UserRoleId = userDto.UserRoleId
                //Date_time_last = userDTO.Date_time_last.ToString(),

            });

            return View(userViewModels);
        }

        #endregion
        #region Create

        public async Task<IActionResult> Create()
        {

            var userRoleList = await userRoleRepository.GetAll();
            var model = new CreateUserViewModel();
            model.UserRoleList = userRoleList.Select(x => new SelectListItem(x.Description, x.UserRoleId.ToString()));
            return View(model);
        }



        [HttpPost]
        public async Task<IActionResult> Create(CreateUserViewModel userViewModel)
        {
            ModelState.Remove("UserRoleList");

            if (!ModelState.IsValid)
            {
                var userRoleList = await userRoleRepository.GetAll();
                userViewModel.UserRoleList = userRoleList.Select(x => new SelectListItem(x.Description, x.UserRoleId.ToString()));


                return View(userViewModel);
            }

            var userDto = new UserDto
            {
                UserId = userViewModel.Id,
                Name = userViewModel.Name,
                LastName = userViewModel.LastName,
                Password = userViewModel.Password,
                DocumentNumber = userViewModel.DocumentNumber,
                Mail = userViewModel.Mail,
                Telephone = userViewModel.Telephone,
                UserRoleId = userViewModel.UserRoleId,


            };
            var alreadyExist = await userRepository.Exist(int.Parse(userDto.DocumentNumber));

            if (alreadyExist)
            {
                ModelState.AddModelError(nameof(userDto.DocumentNumber), $"El DNI {userDto.DocumentNumber} ya existe.");
                return View(userViewModel);
            }

            await userRepository.Create(userDto);
            return RedirectToAction("List");
        }

        #endregion
        #region Edit

        [HttpGet]
        public async Task<ActionResult> Edit(int id)
        {

            var userDto = await userRepository.GetById(id);

            var userViewModel = new CreateUserViewModel
            {                //TODO: Make mapper function.

                Id = userDto.UserId,
                Name = userDto.Name,
                LastName = userDto.LastName,
                //Password = userDTO.Password,
                //TODO: Es redundante, ya es un string.
                DocumentNumber = userDto.DocumentNumber.ToString(),
                Mail = userDto.Mail,
                Telephone = userDto.Telephone,
                UserRoleId = userDto.UserRoleId
                    ,

            };

            if (userViewModel is null)
            {
                //TODO: Fix NotFound 
                return RedirectToAction("NotFound", "Home");
            }
            var userRoleList = await userRoleRepository.GetAll();
            userViewModel.UserRoleList = userRoleList.Select(x => new SelectListItem(x.Description, x.UserRoleId.ToString()));
            return View(userViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> Edit(CreateUserViewModel userViewModel)
        {
            ModelState.Remove("UserRoleList");


            var userDto = new UserDto
            {                //TODO: Make mapper function.

                UserId = userViewModel.Id,
                Name = userViewModel.Name,
                LastName = userViewModel.LastName,
                //Password = userViewModel.Password,
                DocumentNumber = userViewModel.DocumentNumber,
                Mail = userViewModel.Mail,
                Telephone = userViewModel.Telephone,
                UserRoleId = userViewModel.UserRoleId,

            };

            var usuarioExiste = await userRepository.Exist(userViewModel.Id);

            if (usuarioExiste)
            {
                var userRoleList = await userRoleRepository.GetAll();
                userViewModel.UserRoleList = userRoleList.Select(x => new SelectListItem(x.Description, x.UserRoleId.ToString()));
                //TODO: Fix NotFound 
                return RedirectToAction("NotFound", "Home");
            }

            await userRepository.Update(userDto);
            return RedirectToAction("List");
        }

        #endregion
        #region Delete

        public async Task<ActionResult> Delete(int id)
        {
            var userDto = await userRepository.GetById(id);

            if (userDto == null)
            {
                //TODO: Fix NotFound 
                return RedirectToAction("NotFound", "Home");
            }

            var userViewModel = new UserViewModel
            {                //TODO: Make mapper function.
                Name = userDto.Name,
                LastName = userDto.LastName,
                DocumentNumber = userDto.DocumentNumber,
                Mail = userDto.Mail,
                Telephone = userDto.Telephone,

            };

            return View(userViewModel);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(int id)
        {

            var userDto = await userRepository.GetById(id);

            if (userDto == null)
            {
                //TODO: Fix NotFound
                return RedirectToAction("NotFound", "Home");
            }
            await userRepository.Delete(id);
            return RedirectToAction("List");
        }

        #endregion

        #region RoleChange
        [HttpGet]
        public async Task<ActionResult> RoleChange(int id)
        {

            var userDto = await userRepository.GetById(id);

            var userViewModel = new CreateUserViewModel
            {
                Id = userDto.UserId,
                Name = userDto.Name,
                LastName = userDto.LastName,
                //Password = userDTO.Password,
                DocumentNumber = userDto.DocumentNumber.ToString(),
                Mail = userDto.Mail,
                Telephone = userDto.Telephone,
                UserRoleId = userDto.UserRoleId
                    ,

            };

            if (userViewModel is null)
            {
                //TODO: Fix NotFound 
                return RedirectToAction("NotFound", "Home");
            }
            var userRoleList = await userRoleRepository.GetAll();
            userViewModel.UserRoleList = userRoleList.Select(x => new SelectListItem(x.Description, x.UserRoleId.ToString()));
            return View(userViewModel);

        }

        [HttpPost]
        public async Task<ActionResult> RoleChange2(CreateUserViewModel userViewModel)
        {
            ModelState.Remove("UserRoleList");


            var userDto = await userRepository.GetById(userViewModel.Id);
            userDto.UserRoleId = userViewModel.UserRoleId;

            await userRepository.Update(userDto);
            return RedirectToAction("List");
        }

        #endregion
        public IActionResult NotFound()
        {
            return View();
        }

        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(int documentNumber)
        {
            var alreadyExistCheck = await userRepository.Exist(documentNumber);

            if (alreadyExistCheck)
            {
                return Json($"El DNI {documentNumber} ya existe");
            }

            return Json(true);
        }



    }

}
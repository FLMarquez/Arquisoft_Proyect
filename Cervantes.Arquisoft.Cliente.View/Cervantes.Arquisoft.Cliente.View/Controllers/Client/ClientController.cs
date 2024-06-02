using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.Data.Repositories.Assignment;
using Cervantes.Arquisoft.View.Mappers;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Models.Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class ClientController : Controller
    {
        private readonly IClientRepository clientRepository;
        private readonly ICurrentClientService currentClientService;
        private readonly IProvinceRepository provinceRepository;
        private readonly ILocalityRepository localityRepository;
        private readonly IStadisticsRepository statisticsRepository;
        private readonly IProjectRepository projectRepository;
        private readonly IClientDashboardRepository clientDashboardRepository;
        private readonly IAssignmentRepository assigmentRepository;
        private readonly IHubRepository hubRepository;
        private readonly IUserRepository userRepository;

        public ClientController(IClientRepository clientRepository, ICurrentClientService currentClientService,
            IProvinceRepository provinceRepository, IProjectRepository projectRepository,
            ILocalityRepository localityRepository, IStadisticsRepository statisticsRepository, IClientDashboardRepository clientDashboardRepository, IAssignmentRepository assigmentRepository, IHubRepository hubRepository, IUserRepository userRepository)
        {
            this.clientRepository = clientRepository;
            this.currentClientService = currentClientService;
            this.provinceRepository = provinceRepository;
            this.localityRepository = localityRepository;
            this.statisticsRepository = statisticsRepository;
            this.projectRepository = projectRepository;
            this.clientDashboardRepository = clientDashboardRepository;
            this.assigmentRepository = assigmentRepository;
            this.hubRepository = hubRepository;
            this.userRepository = userRepository;
        }

        #region Dashboard

        [HttpGet]
        public async Task<IActionResult> Index(IEnumerable<ClientDashboardDTO> clientDashboardList)
        {
            var currentClient = currentClientService.GetCurrentClient();
            if (currentClient == null)
            {
                // Manejar el caso cuando no hay un cliente actual
                return RedirectToAction("Index", "Home");
            }

            var clientId = int.Parse(currentClient.CurrentClientId);



            var model = new DashboardClientViewModel();
            model.SelectedProjectId = 1;
            model.Client = await clientRepository.GetById(clientId);
            model.ProjectList = await projectRepository.GetProjectsByClientId(clientId) ?? Enumerable.Empty<ProjectDto>();
            model.AssignmentList = (await assigmentRepository.GetAllByClientId(clientId))?
                .Where(a => !a.NotVisible)
                .ToList() ?? new List<AssignmentDTO>();
            model.HubList = await hubRepository.GetAllByClientId(clientId) ?? Enumerable.Empty<HubDto>();

            return View(model);
        }

        #endregion

        #region Read

        [HttpGet]
        public async Task<IActionResult> List()
        {
            TempData.Clear();

            var clientDto = await clientRepository.GetAll();

            var clientViewModels = ClientMapper.FromDtoToViewModel(clientDto);

            return View(clientViewModels);



        }

        #endregion

        #region Create

        [HttpGet]
        public async Task<IActionResult> Create()
        {
            var provinceList = await provinceRepository.GetAll();
            var localitiesList = await localityRepository.GetAll();

            var model = new ClientViewModel();
            model.Address = new AddressViewModel();
            model.Address.ProvinceList = provinceList ?? Enumerable.Empty<ProvinceDto>();
            model.Address.LocalitiesList = localitiesList ?? Enumerable.Empty<LocalityDto>();


            ModelState.Clear();

            return View(model);
        }

        [HttpPost]
        public IActionResult Create(ClientViewModel model)
        {
            ModelState.Remove("Address.ProvinceList");
            ModelState.Remove("Address.LocalitiesList");
            if (ModelState.IsValid)
            {
                ClientDto clientDto = new ClientDto();
                clientDto.AddressNavigation = AddressViewModel.FromViewModelToAddressDto(model.Address);
                clientDto = ClientMapper.FromViewModelToDto(model);
                clientRepository.Create(clientDto);
                return RedirectToAction("List", "Client");

            }

            return View(model);

        }

        #endregion

        #region Edit

        [HttpGet]
        public async Task<IActionResult> Edit(int id)
        {
            ModelState.Clear();
            var client = await clientRepository.GetById(id);

            if (client == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var model = ClientMapper.FromDtoToViewModel(client);
            var provinceList = await provinceRepository.GetAll();
            var localitiesList = await localityRepository.GetAll();

            model.Address.ProvinceList = provinceList ?? Enumerable.Empty<ProvinceDto>();
            model.Address.LocalitiesList = localitiesList ?? Enumerable.Empty<LocalityDto>();

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(ClientViewModel model)
        {
            ModelState.Remove("Address.ProvinceList");
            ModelState.Remove("Address.LocalitiesList");
            if (ModelState.IsValid)
            {
                ClientDto clientDto = new ClientDto();
                clientDto.AddressNavigation = AddressViewModel.FromViewModelToAddressDto(model.Address);
                clientDto = ClientMapper.FromViewModelToDto(model);
                await clientRepository.Update(clientDto);
                return RedirectToAction("List");
            }

            return View(model);
        }

        #endregion

        #region Delete

        public async Task<IActionResult> Delete(int id)
        {
            var client = await clientRepository.GetById(id);

            if (client == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            var model = ClientMapper.FromDtoToViewModel(client);

            return View(model);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteId(int id)
        {
            var client = await clientRepository.GetById(id);

            if (client == null)
            {
                return RedirectToAction("NotFound", "Home");
            }

            await clientRepository.Delete(id);
            return RedirectToAction("List");
        }

        #endregion


        [HttpGet]
        public async Task<IActionResult> AlreadyExistCheck(int documentNumber)
        {
            var alreadyExistCheck = await clientRepository.Exist(documentNumber);

            if (alreadyExistCheck)
            {
                Console.WriteLine("Resultado de AlreadyExistCheck: Existe");

                return Json($"El DNI {documentNumber} ya existe");
            }


            Console.WriteLine("Resultado de AlreadyExistCheck: NoExiste");
            return Json(true);
        }
    }
}
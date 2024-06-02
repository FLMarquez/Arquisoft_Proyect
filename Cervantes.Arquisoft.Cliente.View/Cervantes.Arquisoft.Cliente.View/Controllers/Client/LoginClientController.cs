using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class LoginClientController : Controller
    {
        private readonly ILoginClientRepository loginClientRepository;
        private readonly ICurrentClientService currentClientService;
        private readonly IClientRepository clientRepository;

        public LoginClientController(ILoginClientRepository loginClientRepository, ICurrentClientService currentClientService, IClientRepository clientRepository)
        {
            this.loginClientRepository = loginClientRepository;
            this.currentClientService = currentClientService;
            this.clientRepository = clientRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginClientViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var client = new ClientDto()
                {
                    Mail = model.Mail,
                    Password = model.Password
                };

                int result = await loginClientRepository.Exist(client);

                if (result == 0)
                {
                    ModelState.AddModelError(string.Empty, "El usuario o la contraseña son incorrectos");
                    return View(model); // Retorna la vista con el modelo actual y el mensaje de error
                }
                else
                {
                    client = await clientRepository.GetById(result);

                    currentClientService.SetCurrentClient(client);

                    return RedirectToAction("Index", "Client");
                }
            }
            return View(model);

        }



        public IActionResult Logout()
        {
            currentClientService.SetCurrentClient(null);


            return RedirectToAction("Index", "Home");
        }


        public IActionResult RecoverPass()
        {
            return View("RecoverPass");
        }
        [HttpPost]
        public async Task<IActionResult> RecoverPass(RecoverPassViewModel model)
        {
            if (ModelState.IsValid)
            {
                var client = new ClientDto()
                {
                    Mail = model.Mail,
                    DocumentNumber = model.DocumentNumber,
                    Telephone = model.Telephone
                };

                var passwordResetSuccess = await loginClientRepository.RestorePassword(client);

                if (passwordResetSuccess)
                {
                    ViewBag.SuccessMessage = "Contraseña recuperada con éxito. A partir de ahora, su contraseña es su DNI. "; // Cambiar esto por una mejor práctica de seguridad
                    return View("RecoverPass"); // Muestra la contraseña al usuario
                }
                else
                {
                    ModelState.AddModelError("", "No se encontró un usuario con las condiciones especificadas.");
                }
            }

            // Si el modelo no es válido o el password no pudo ser reseteado, mostrar la vista con los mensajes de error
            return View(model);
        }




    }
}

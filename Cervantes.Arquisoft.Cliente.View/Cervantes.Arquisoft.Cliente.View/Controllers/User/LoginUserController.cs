using Cervantes.Arquisoft.Application.DTOs;
using Cervantes.Arquisoft.Data.Interfaces;
using Cervantes.Arquisoft.Data.Repositories;
using Cervantes.Arquisoft.View.Models;
using Cervantes.Arquisoft.View.Services;
using Microsoft.AspNetCore.Mvc;

namespace Cervantes.Arquisoft.View.Controllers
{
    public class LoginUserController : Controller
    {
        private readonly ILoginUserRepository loginUserRepository;
        private readonly ICurrentUserService currentUserService;
        private readonly IUserRepository userRepository;

        public LoginUserController(ILoginUserRepository userLoginRepository, ICurrentUserService currentUserService, IUserRepository userRepository)
        {
            loginUserRepository = userLoginRepository;
            this.currentUserService = currentUserService;
            this.userRepository = userRepository;
        }

        public IActionResult Index()
        {
            return View();
        }
        [HttpPost]
        public async Task<IActionResult> Index(LoginUserViewModel model)
        {
            if (!ModelState.IsValid)
            {
                return View(model);
            }

            if (ModelState.IsValid)
            {
                var user = new UserDto()
                {
                    Mail = model.Mail,
                    Password = model.Password
                };

                int result = await loginUserRepository.Exist(user);

                if (result == 0)
                {
                    ModelState.AddModelError(string.Empty, "El usuario o la contraseña son incorrectos");
                    return View(model); // Retorna la vista con el modelo actual y el mensaje de error
                }
                else
                {
                    user = await userRepository.GetById(result);

                    currentUserService.SetCurrentUser(user);

                    return RedirectToAction("Index", "User");
                }
            }
            return View(model);

        }



        public IActionResult Logout()
        {
            currentUserService.SetCurrentUser(null);


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
                var user = new UserDto()
                {
                    Mail = model.Mail,
                    DocumentNumber = model.DocumentNumber,
                    Telephone = model.Telephone
                };

                var passwordResetSuccess = await loginUserRepository.RestorePassword(user);

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

            // Si el modelo no es válido o la contraseña no pudo ser recuperada, mostrar la vista con los mensajes de error
            return View(model);
        }




    }
}

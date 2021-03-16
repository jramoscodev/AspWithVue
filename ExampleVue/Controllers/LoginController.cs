using CommonDomain.ViewModels;
using ServiceLayer.LoginServices;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace ExampleVue.Controllers
{
    public class LoginController : Controller
    {
        private readonly ILoginServices _loginServices;

        public LoginController()
        {
            /*
             TODO: injeccion de dependencias manual aqui aplicamos el principio de Liskov y Dependency inversion principle
            esto proviene de la metodologia SOLID, notar que se hacer el llamado a la interface y se instancia con la 
            implementacion de esta            
             */
            _loginServices = new LoginServicesImpl();
        }


        // GET: login
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        [ValidateInput(false)]
        [ValidateAntiForgeryToken]
        public ActionResult Index(LoginViewModel model)
        {
            if(ModelState.IsValid) // valida el model segun las reglas establecidas
            {
               var result = _loginServices.Login(model); //se le pasa el modelo al servicio
                if(!result) // si el resultado es false se retorna erro hacia la vista
                {
                    // esto sirver para agregar un nuevo mensaje de error, este puede agregarse a una propiedad especifica
                    ModelState.AddModelError("Password", "Mensaje de error desde el Controlador para el campo Password");
                    ModelState.AddModelError(string.Empty, "Usuario o Contraseña inválidas - este es un mensaje generico de error");
                    return View(model);
                }
                return RedirectToAction("Index", "Home");
            }

            return View(model);
        }
        
    }
}
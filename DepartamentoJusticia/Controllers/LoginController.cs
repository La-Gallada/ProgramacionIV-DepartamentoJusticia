using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class LoginController : Controller
    {
        // GET: LoginController
        Service service;
        public LoginController() { service = new Service(); }

        public ActionResult Index()
        {
            HttpContext.Session.Clear();
            return View();
        }
        // POST: LoginController (validar inicio de sesion)
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Index(string nombreUsuario, string contrasenia)
        {
            try
            {
                var usuarioLogueado = service.login(nombreUsuario, contrasenia);

                service.registrarBitacora(nombreUsuario, "Exitoso");

                HttpContext.Session.SetString("Username", usuarioLogueado.NombreUsuario);
                HttpContext.Session.SetString("NombreCompleto", usuarioLogueado.NombreCompleto);
                HttpContext.Session.SetString("Cargo", usuarioLogueado.Cargo);

                return RedirectToAction("Index", "Inicio");
            }
            catch (Exception ex)
            {
                service.registrarBitacora(nombreUsuario, "Fallido");

                ViewBag.ErrorMsg = ex.Message;
                return View();
            }
        }
        // GET: LoginController/CerrarSesion
        public ActionResult CerrarSesion()
        {
            HttpContext.Session.Clear();
            return RedirectToAction("Index", "Login");
        }
    }
}
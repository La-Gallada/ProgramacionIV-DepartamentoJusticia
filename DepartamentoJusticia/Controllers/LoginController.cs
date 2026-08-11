using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class LoginController : Controller
{
    private readonly Service service;

    public LoginController(Service service)
    {
        this.service = service;
    }

    [HttpGet]
    public IActionResult Index()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Index(string nombreUsuario, string contrasenia)
    {
        if (service.ValidarUsuario(nombreUsuario, contrasenia) == null)
        {
            service.RegistrarBitacora(nombreUsuario, "Fallido");
            ModelState.AddModelError("", "Las credenciales son invalidas o el usuario no esta activo.");
            return View();
        }

        service.RegistrarBitacora(nombreUsuario, "Exitoso");
        return RedirectToAction("Index", "Usuarios");
    }
}

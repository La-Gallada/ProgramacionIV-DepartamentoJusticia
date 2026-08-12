using DepartamentoJusticia.Models;
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
        Usuario? usuario = service.ValidarUsuario(nombreUsuario, contrasenia);

        if (usuario == null)
        {
            service.RegistrarBitacora(nombreUsuario, "Fallido");
            ModelState.AddModelError("", "Las credenciales son invalidas o el usuario no esta activo.");
            return View();
        }

        service.RegistrarBitacora(nombreUsuario, "Exitoso");
        HttpContext.Session.SetString("Username", usuario.NombreUsuario);
        return RedirectToAction("Index", "Inicio");
    }

    public IActionResult Logout()
    {
        HttpContext.Session.Clear();
        return RedirectToAction("Index", "Login");
    }
}

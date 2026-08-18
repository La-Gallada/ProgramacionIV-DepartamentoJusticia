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
        HttpContext.Session.Clear();
        return View();
    }

    [HttpPost]
    public IActionResult Index(string nombreUsuario, string contrasenia)
    {
        Usuario? usuario = service.ValidarUsuario(nombreUsuario, contrasenia);

        if (usuario == null)
        {
            service.RegistrarBitacora(nombreUsuario, "Fallido");
            ModelState.AddModelError("", "Las credenciales son inválidas o el usuario no está activo.");
            return View();
        }

        service.RegistrarBitacora(nombreUsuario, "Exitoso");

        HttpContext.Session.SetString("Username", usuario.NombreUsuario);
        HttpContext.Session.SetString("NombreCompleto", usuario.NombreCompleto);
        HttpContext.Session.SetString("Cargo", usuario.Cargo);

        return RedirectToAction("Index", "Inicio");
    }

    [HttpGet]
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return Redirect("/Login");
    }

    [HttpGet]
    public IActionResult Logout()
    {
        return CerrarSesion();
    }
}

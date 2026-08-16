using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class LoginController : Controller
{
    [HttpGet]
    public IActionResult Index()
    {
        HttpContext.Session.Clear();
        return View();
    }

    [HttpPost]
    public IActionResult Index(string nombreUsuario, string contrasena)
    {
        TempData["Error"] = "La validacion de credenciales todavia no esta implementada.";
        return RedirectToAction(nameof(Index));
    }

    [HttpGet]
    public IActionResult CerrarSesion()
    {
        HttpContext.Session.Clear();
        return RedirectToAction(nameof(Index));
    }
}

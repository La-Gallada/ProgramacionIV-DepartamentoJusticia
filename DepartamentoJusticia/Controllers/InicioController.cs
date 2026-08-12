using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class InicioController : ControladorBase
{
    public IActionResult Index()
    {
        return View();
    }
}

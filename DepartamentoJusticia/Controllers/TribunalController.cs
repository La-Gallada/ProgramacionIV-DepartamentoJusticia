using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class InicioController : Controller
{
    public IActionResult Index()
    {
        return View();
    }
}

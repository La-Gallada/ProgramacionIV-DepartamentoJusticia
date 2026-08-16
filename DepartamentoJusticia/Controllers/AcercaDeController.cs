using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class AcercaDeController : ControladorBase
{
    public ActionResult Index()
    {
        return View();
    }
}

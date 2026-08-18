using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class AcercaDeController : ControladorBase
{
    public IActionResult Index()
    {
        
        ViewBag.Universidad = "Universidad Latina de Costa Rica";
        ViewBag.Curso = "Programación IV (BIS10)";
        ViewBag.Profesora = "Adriana Stephanie Rubio Escobar";
        ViewBag.Version = "1.0";

        ViewBag.Integrantes = new List<string[]>
        {
            new[] { "Christopher Phillips Arroyo", "" },
            new[] { "Allison Valeria Sancho Vega", "" },
            new[] { "Juan Gabriel Sandi Lopez", "" },
            new[] { "Maryeri Gómez Hernández", "" }
        };

        return View();
    }
}

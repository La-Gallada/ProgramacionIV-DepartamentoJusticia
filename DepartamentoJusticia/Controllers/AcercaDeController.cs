using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class AcercaDeController : ControladorBase
{
    public IActionResult Index()
    {
        
        ViewBag.Universidad = "Universidad Latina de Costa Rica";
        ViewBag.Curso = "Programacion IV";
        ViewBag.Profesora = "Adriana Stephanie Rubio Escobar";
        ViewBag.Version = "1.0";

        ViewBag.Integrantes = new List<string[]>
        {
            new[] { "Val Sancho Vega", "Frontend, diseno del sistema, Sospechosos y Audiencias" },
            new[] { "Juan Gabriel Sandí", "Agentes Federales y Casos Judiciales" },
            new[] { "Maryeri Gomez Hernandez", "Evidencias, Operativos y Tribunales" },
            new[] { "Christopher Phillips Arroyo", "Seguridad, Usuarios y Bitacora" }
        };

        return View();
    }
}
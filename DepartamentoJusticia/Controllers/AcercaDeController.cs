using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class AcercaDeController : ControladorBase
{
    public IActionResult Index()
    {
        // EQUIPO: completar estos datos antes de la entrega.
        ViewBag.Universidad = "[Nombre de la universidad]";
        ViewBag.Curso = "Programacion IV";
        ViewBag.Profesora = "[Nombre de la profesora]";
        ViewBag.Version = "1.0";

        ViewBag.Integrantes = new List<string[]>
        {
            new[] { "[Nombre de Val]", "Frontend, diseno del sistema, Sospechosos y Audiencias" },
            new[] { "[Nombre de Juancho]", "Agentes Federales y Casos Judiciales" },
            new[] { "[Nombre de Mar]", "Evidencias, Operativos y Tribunales" },
            new[] { "[Nombre de Chris]", "Seguridad, Usuarios y Bitacora" }
        };

        return View();
    }
}
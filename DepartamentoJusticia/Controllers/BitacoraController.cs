using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class BitacoraController : Controller
{
    private readonly Service service;

    public BitacoraController(Service service)
    {
        this.service = service;
    }

    public IActionResult Index(string nombreUsuario, string resultado)
    {
        ViewBag.NombreUsuario = nombreUsuario;
        ViewBag.Resultado = resultado;

        List<Bitacora> listaBitacora = service.BuscarBitacora(nombreUsuario, resultado);
        return View(listaBitacora);
    }
}

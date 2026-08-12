using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class BitacoraController : ControladorBase
{
    private readonly Service service;

    public BitacoraController(Service service)
    {
        this.service = service;
    }

    public IActionResult Index(string nombreUsuario, string resultado, DateTime? fecha)
    {
        ViewBag.NombreUsuario = nombreUsuario;
        ViewBag.Resultado = resultado;
        ViewBag.Fecha = fecha?.ToString("yyyy-MM-dd");

        List<Bitacora> listaBitacora = service.BuscarBitacora(nombreUsuario, resultado, fecha);
        return View(listaBitacora);
    }
}

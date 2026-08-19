using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class BitacoraController : ControladorBase
    {
        // GET: BitacoraController
        Service service;
        public BitacoraController() { service = new Service(); }

        public ActionResult Index(string nombreUsuario, string resultado, DateTime? fecha)
        {
            try
            {
                ViewBag.NombreUsuario = nombreUsuario;
                ViewBag.Resultado = resultado;
                ViewBag.Fecha = fecha?.ToString("yyyy-MM-dd");

                if (!string.IsNullOrEmpty(nombreUsuario))
                    return View(service.buscarBitacoraPorUsuario(nombreUsuario));
                else if (!string.IsNullOrEmpty(resultado))
                    return View(service.buscarBitacoraPorResultado(resultado));
                else if (fecha != null)
                    return View(service.buscarBitacoraPorFecha(fecha.Value));
                else
                    return View(service.mostrarBitacora());
            }
            catch
            {
                return View(service.mostrarBitacora());
            }
        }
    }
}

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

        public ActionResult Index()
        {
            var bitacoras = service.mostrarBitacora();
            return View(bitacoras);
        }
        // POST: BitacoraController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string nombreUsuario, string resultado)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombreUsuario))
                    return View(service.buscarBitacoraPorUsuario(nombreUsuario));
                else if (!string.IsNullOrEmpty(resultado))
                    return View(service.buscarBitacoraPorResultado(resultado));
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
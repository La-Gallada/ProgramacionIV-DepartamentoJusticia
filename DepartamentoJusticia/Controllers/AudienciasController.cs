using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class AudienciasController : ControladorBase
    {
        // GET: AudienciasController
        Service service;
        public AudienciasController() { service = new Service(); }

        public ActionResult Index()
        {
            ViewBag.Tribunales = service.mostrarNombresDeTribunal();
            var audiencias = service.mostrarAudiencias();
            return View(audiencias);
        }
        // POST: AudienciasController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string nombreTribunal, string tipoAudiencia, string estado)
        {
            ViewBag.Tribunales = service.mostrarNombresDeTribunal();
            try
            {
                if (!string.IsNullOrEmpty(nombreTribunal))
                    return View(service.buscarAudienciasPorTribunal(nombreTribunal));
                else if (!string.IsNullOrEmpty(tipoAudiencia))
                    return View(service.buscarAudienciasPorTipo(tipoAudiencia));
                else if (!string.IsNullOrEmpty(estado))
                    return View(service.buscarAudienciasPorEstado(estado));
                else
                    return View(service.mostrarAudiencias());
            }
            catch
            {
                return View(service.mostrarAudiencias());
            }
        }
        // GET: AudienciasController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: AudienciasController/Create
        public ActionResult Create()
        {
            ViewBag.Tribunales = service.mostrarNombresDeTribunal();
            ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
            return View(new Audiencia());
        }
        // POST: AudienciasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Audiencia audiencita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarAudiencia(audiencita);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(audiencita);
                }
            }
            catch
            {
                ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(audiencita);
            }
        }
        // GET: AudienciasController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                var audienciaBuscada = service.buscarAudiencia(id);
                return View(audienciaBuscada);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: AudienciasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Audiencia audiencita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarAudiencia(audiencita);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(audiencita);
                }
            }
            catch
            {
                ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(audiencita);
            }
        }
        // GET: AudienciasController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var audienciaEliminada = service.buscarAudiencia(id);
                service.eliminarAudiencia(audienciaEliminada);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
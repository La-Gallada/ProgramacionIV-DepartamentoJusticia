using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class SospechososController : ControladorBase
    {
        // GET: SospechososController
        Service service;
        public SospechososController() { service = new Service(); }

        public ActionResult Index()
        {
            var sospechosos = service.mostrarSospechosos();
            return View(sospechosos);
        }
        // POST: SospechososController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string nombreCompleto, string estadoLegal, string nivelRiesgo)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombreCompleto))
                    return View(service.buscarSospechososPorNombre(nombreCompleto));
                else if (!string.IsNullOrEmpty(estadoLegal))
                    return View(service.buscarSospechososPorEstadoLegal(estadoLegal));
                else if (!string.IsNullOrEmpty(nivelRiesgo))
                    return View(service.buscarSospechososPorRiesgo(nivelRiesgo));
                else
                    return View(service.mostrarSospechosos());
            }
            catch
            {
                return View(service.mostrarSospechosos());
            }
        }
        // GET: SospechososController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: SospechososController/Create
        public ActionResult Create()
        {
            ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
            return View(new Sospechoso());
        }
        // POST: SospechososController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sospechoso sospechosito)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    sospechosito.NivelRiesgo = sospechosito.CalcularNivelRiesgo();
                    service.agregarSospechoso(sospechosito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(sospechosito);
                }
            }
            catch
            {
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(sospechosito);
            }
        }
        // GET: SospechososController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                var sospechosoBuscado = service.buscarSospechoso(id);
                return View(sospechosoBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: SospechososController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sospechoso sospechosito)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    sospechosito.NivelRiesgo = sospechosito.CalcularNivelRiesgo();
                    service.actualizarSospechoso(sospechosito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(sospechosito);
                }
            }
            catch
            {
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(sospechosito);
            }
        }
        // GET: SospechososController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var sospechosoEliminado = service.buscarSospechoso(id);
                service.eliminarSospechoso(sospechosoEliminado);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
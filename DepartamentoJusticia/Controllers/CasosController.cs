using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers
{
    public class CasosController : ControladorBase
    {
        Service service;

        public CasosController() { service = new Service(); }

        // GET: CasosController
        public ActionResult Index()
        {
            var casos = service.mostrarCasos();
            return View(casos);
        }
        // POST: CasosController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string numeroCaso, string tipoDelito, string prioridad)
        {
            try
            {
                if (!string.IsNullOrEmpty(numeroCaso))
                    return View(service.buscarCasosPorNumero(numeroCaso));
                else if (!string.IsNullOrEmpty(tipoDelito))
                    return View(service.buscarCasosPorTipoDelito(tipoDelito));
                else if (!string.IsNullOrEmpty(prioridad))
                    return View(service.buscarCasosPorPrioridad(prioridad));
                else
                    return View(service.mostrarCasos());
            }
            catch
            {
                return View(service.mostrarCasos());
            }
        }

        // GET: CasosController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }

        // GET: CasosController/Create
        public ActionResult Create()
        {
            ViewBag.Agentes = service.mostrarAgentesActivos();
            return View(new CasoJudicial());
        }

        // POST: CasosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CasoJudicial casito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    casito.Prioridad = casito.CalcularPrioridad();
                    service.agregarCaso(casito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Agentes = service.mostrarAgentesActivos();
                    return View();
                }
            }
            catch
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                return View();
            }
        }

        // GET: CasosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                var casoBuscado = service.buscarCaso(id);
                return View(casoBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: CasosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CasoJudicial casito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    casito.Prioridad = casito.CalcularPrioridad();
                    service.actualizarCaso(casito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Agentes = service.mostrarAgentesActivos();
                    return View();
                }
            }
            catch
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                return View();
            }
        }

        // GET: CasosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var casoEliminado = service.buscarCaso(id);
                service.eliminarCaso(casoEliminado);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}

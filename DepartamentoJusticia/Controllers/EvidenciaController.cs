using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class EvidenciaController : ControladorBase
    {
        // GET: EvidenciaController
        Service service;
        public EvidenciaController() { service = new Service(); }

        public ActionResult Index()
        {
            var evidencias = service.mostrarEvidencias();
            return View(evidencias);
        }
        // POST: EvidenciaController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string codigo, string tipoEvidencia, DateTime? fechaRecoleccion)
        {
            try
            {
                if (!string.IsNullOrEmpty(codigo))
                    return View(service.buscarEvidenciasPorCodigo(codigo));
                else if (!string.IsNullOrEmpty(tipoEvidencia))
                    return View(service.buscarEvidenciasPorTipo(tipoEvidencia));
                else if (fechaRecoleccion != null)
                    return View(service.buscarEvidenciasPorFecha(fechaRecoleccion.Value));
                else
                    return View(service.mostrarEvidencias());
            }
            catch
            {
                return View(service.mostrarEvidencias());
            }
        }
        // GET: EvidenciaController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: EvidenciaController/Create
        public ActionResult Create()
        {
            ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
            return View(new Evidencia());
        }
        // POST: EvidenciaController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Evidencia evidencita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarEvidencia(evidencita);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
                    return View(evidencita);
                }
            }
            catch
            {
                ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
                return View(evidencita);
            }
        }
        // GET: EvidenciaController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
                var evidenciaBuscada = service.buscarEvidencia(id);
                return View(evidenciaBuscada);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: EvidenciaController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Evidencia evidencita)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarEvidencia(evidencita);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
                    return View(evidencita);
                }
            }
            catch
            {
                ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
                return View(evidencita);
            }
        }
        // GET: EvidenciaController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var evidenciaEliminada = service.buscarEvidencia(id);
                service.eliminarEvidencia(evidenciaEliminada);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
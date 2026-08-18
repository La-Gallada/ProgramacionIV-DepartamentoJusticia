using Microsoft.AspNetCore.Mvc;
using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
namespace DepartamentoJusticia.Controllers;

public class EvidenciaController : ControladorBase
{
    Service service;

    public EvidenciaController() { service = new Service(); }

    // GET: EvidenciaController
    public ActionResult Index(string codigo, string tipoEvidencia, DateTime? fechaRecoleccion)
    {
        ViewBag.Codigo = codigo;
        ViewBag.TipoEvidencia = tipoEvidencia;
        ViewBag.FechaRecoleccion = fechaRecoleccion?.ToString("yyyy-MM-dd");

        var evidencias = service.buscarEvidencias(codigo, tipoEvidencia, fechaRecoleccion);
        return View(evidencias);
    }

    // GET: EvidenciaController/Create
    public ActionResult Create()
    {
        ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
        return View();
    }

    // POST: EvidenciaController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Evidencia evidencita)
    {
        try
        {
            if (!string.IsNullOrWhiteSpace(evidencita.NumeroCaso) &&
                !service.mostrarCasoJudicial().Any(c => c.NumeroCaso == evidencita.NumeroCaso))
            {
                ModelState.AddModelError("NumeroCaso", "Debe seleccionar un caso judicial registrado.");
            }

            if (ModelState.IsValid)
            {
                service.agregarEvidencia(evidencita);
                return RedirectToAction("Index");
            }
            ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
            return View(evidencita);
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
            var evidenciaBuscada = service.buscarEvidencia(id);
            ViewBag.CasosJudiciales = service.mostrarCasoJudicial();

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
            if (!string.IsNullOrWhiteSpace(evidencita.NumeroCaso) &&
                !service.mostrarCasoJudicial().Any(c => c.NumeroCaso == evidencita.NumeroCaso))
            {
                ModelState.AddModelError("NumeroCaso", "Debe seleccionar un caso judicial registrado.");
            }

            if (ModelState.IsValid)
            {
                service.actualizarEvidencia(evidencita);
                return RedirectToAction("Index");
            }

            ViewBag.CasosJudiciales = service.mostrarCasoJudicial();
            return View(evidencita);
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
            var evidenciaBuscada = service.buscarEvidencia(id);
            return View(evidenciaBuscada);
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }

    // POST: EvidenciaController/Delete/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Delete(int id, string confirmar)
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



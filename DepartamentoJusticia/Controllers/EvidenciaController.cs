using Microsoft.AspNetCore.Mvc;
using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
namespace DepartamentoJusticia.Controllers;

public class EvidenciaController : Controller
{
    Service service;

    public EvidenciaController() { service = new Service(); }

    // GET: EvidenciaController
    public ActionResult Index()
    {
        var evidencias = service.mostrarEvidencias();
        return View(evidencias);
    }

    // GET: EvidenciaController/Details/5
    public ActionResult Details(int id)
    {
        return View();
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
            if (ModelState.IsValid)
            {
                service.agregarEvidencia(evidencita);
                return RedirectToAction("Index");
            }
            else return View();
        }
        catch
        {
            return View();
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
            if (ModelState.IsValid)
                service.actualizarEvidencia(evidencita);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
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



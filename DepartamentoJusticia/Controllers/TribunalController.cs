using Microsoft.AspNetCore.Mvc;
using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
namespace DepartamentoJusticia.Controllers;

public class TribunalController : Controller
{
    Service service;

    public TribunalController() { service = new Service(); }

    // GET: TribunalController
    public ActionResult Index()
    {
        var tribunales = service.mostrarTribunales();
        return View(tribunales);
    }

    // GET: TribunalController/Details/5
    public ActionResult Details(int id)
    {
        return View();
    }

    // GET: TribunalController/Create
    public ActionResult Create()
    {
        return View();
    }

    // POST: TribunalController/Create
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Create(Tribunal tribunalito)
    {
        try
        {
            if (ModelState.IsValid)
            {
                service.agregarTribunal(tribunalito);
                return RedirectToAction("Index");
            }
            else return View();
        }
        catch
        {
            return View();
        }
    }

    // GET: TribunalController/Edit/5
    public ActionResult Edit(int id)
    {
        try
        {
            var tribunalBuscado = service.buscarTribunal(id);
            return View(tribunalBuscado);
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }

    // POST: TribunalController/Edit/5
    [HttpPost]
    [ValidateAntiForgeryToken]
    public ActionResult Edit(Tribunal tribunalito)
    {
        try
        {
            if (ModelState.IsValid)
                service.actualizarTribunal(tribunalito);
            return RedirectToAction("Index");
        }
        catch
        {
            return View();
        }
    }

    // GET: TribunalController/Delete/5
    public ActionResult Delete(int id)
    {
        try
        {
            var tribunalEliminado = service.buscarTribunal(id);
            service.eliminarTribunal(tribunalEliminado);
            return RedirectToAction("Index");
        }
        catch (Exception)
        {
            return RedirectToAction("Index");
        }
    }

}
}

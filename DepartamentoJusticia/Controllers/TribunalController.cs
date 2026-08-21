using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class TribunalController : ControladorBase
    {
        // GET: TribunalController
        Service service;
        public TribunalController() { service = new Service(); }

        public ActionResult Index(string nombre, string ciudad, string juezAsignado, string estado)
        {
            try
            {
                ViewBag.Nombre = nombre;
                ViewBag.Ciudad = ciudad;
                ViewBag.JuezAsignado = juezAsignado;
                ViewBag.Estado = estado;

                if (!string.IsNullOrEmpty(nombre))
                    return View(service.buscarTribunalesPorNombre(nombre));
                else if (!string.IsNullOrEmpty(ciudad))
                    return View(service.buscarTribunalesPorCiudad(ciudad));
                else if (!string.IsNullOrEmpty(juezAsignado))
                    return View(service.buscarTribunalesPorJuez(juezAsignado));
                else if (!string.IsNullOrEmpty(estado))
                    return View(service.buscarTribunalesPorEstado(estado));
                else
                    return View(service.mostrarTribunales());
            }
            catch
            {
                return View(service.mostrarTribunales());
            }
        }
        // GET: TribunalController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: TribunalController/Create
        public ActionResult Create()
        {
            return View(new Tribunal());
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
                else return View(tribunalito);
            }
            catch
            {
                return View(tribunalito);
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
                {
                    service.actualizarTribunal(tribunalito);
                    return RedirectToAction("Index");
                }
                else return View(tribunalito);
            }
            catch
            {
                return View(tribunalito);
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

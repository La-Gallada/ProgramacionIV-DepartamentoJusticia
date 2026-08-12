using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers
{
    public class OperativosController : Controller
    {
        Service service;

        public OperativosController() { service = new Service(); }

        // GET: OperativosController
        public ActionResult Index()
        {
            var operativos = service.mostrarOperativos();
            return View(operativos);
        }

        // GET: OperativosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: OperativosController/Create
        public ActionResult Create()
        {
            ViewBag.Agentes = service.mostrarAgentesActivos();
            ViewBag.Casos = service.mostrarCasos();
            return View(new Operativo());
        }

        // POST: OperativosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Operativo operativito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.agregarOperativo(operativito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Agentes = service.mostrarAgentesActivos();
                    ViewBag.Casos = service.mostrarCasos();
                    return View();
                }
            }
            catch
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                ViewBag.Casos = service.mostrarCasos();
                return View();
            }
        }

        // GET: OperativosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                ViewBag.Casos = service.mostrarCasos();
                var operativoBuscado = service.buscarOperativo(id);
                return View(operativoBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }

        // POST: OperativosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Operativo operativito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    service.actualizarOperativo(operativito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Agentes = service.mostrarAgentesActivos();
                    ViewBag.Casos = service.mostrarCasos();
                    return View();
                }
            }
            catch
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                ViewBag.Casos = service.mostrarCasos();
                return View();
            }
        }

        // GET: OperativosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var operativoEliminado = service.buscarOperativo(id);
                service.eliminarOperativo(operativoEliminado);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers
{
    public class AgentesController : Controller
    {
        // GET: AgenteController
        Service service;

        public AgentesController() { service = new Service(); }

        
        public ActionResult Index()
        {
            var agentes = service.mostrarAgentes();
            return View(agentes);
        }

        // GET: AgenteController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: AgenteController/Create
        public ActionResult Create()
        {
            return View(new Agente());
        }

        // POST: AgenteController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Agente agentito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    agentito.SalarioTotal = agentito.CalcularSalarioTotal();
                    service.agregarAgente(agentito);
                    return RedirectToAction("Index");
                }
                else return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: AgenteController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var agenteBuscado = service.buscarAgente(id);
                return View(agenteBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

        // POST: AgenteController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Agente agentito)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    agentito.SalarioTotal = agentito.CalcularSalarioTotal();
                    service.actualizarAgente(agentito);
                    return RedirectToAction("Index");
                }
                else return View();
            }
            catch
            {
                return View();
            }

        }

        // GET: AgenteController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var agenteEliminado = service.buscarAgente(id);
                service.eliminarAgente(agenteEliminado);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }

        }

       
    }
}

using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class OperativosController : ControladorBase
    {
        Service service;
        public OperativosController() { service = new Service(); }

        private void CargarListas()
        {
            ViewBag.Agentes = service.mostrarAgentesActivos();
            ViewBag.Casos = service.mostrarCasos();
        }
        // GET: OperativosController
        public ActionResult Index()
        {
            var operativos = service.mostrarOperativos();
            return View(operativos);
        }
        // POST: OperativosController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string ciudad, DateTime? fecha, string tipoOperativo, string resultado)
        {
            try
            {
                if (!string.IsNullOrEmpty(ciudad))
                    return View(service.buscarOperativosPorCiudad(ciudad));
                else if (fecha != null)
                    return View(service.buscarOperativosPorFecha(fecha.Value));
                else if (!string.IsNullOrEmpty(tipoOperativo))
                    return View(service.buscarOperativosPorTipo(tipoOperativo));
                else if (!string.IsNullOrEmpty(resultado))
                    return View(service.buscarOperativosPorResultado(resultado));
                else
                    return View(service.mostrarOperativos());
            }
            catch
            {
                return View(service.mostrarOperativos());
            }
        }
        // GET: OperativosController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }
        // GET: OperativosController/Create
        public ActionResult Create()
        {
            CargarListas();
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
                    if (!service.existeAgentePorNombre(operativito.NombreAgente1) ||
                        !service.existeAgentePorNombre(operativito.NombreAgente2) ||
                        !service.existeAgentePorNombre(operativito.NombreAgente3))
                    {
                        ModelState.AddModelError("", "Debe seleccionar agentes activos registrados.");
                        CargarListas();
                        return View(operativito);
                    }

                    // Se buscan los tres agentes para obtener sus salarios
                    var agente1 = service.buscarAgentePorNombre(operativito.NombreAgente1);
                    var agente2 = service.buscarAgentePorNombre(operativito.NombreAgente2);
                    var agente3 = service.buscarAgentePorNombre(operativito.NombreAgente3);

                    operativito.CostoOperativo = operativito.CalcularCostoOperativo(
                        agente1.SalarioTotal, agente2.SalarioTotal, agente3.SalarioTotal);

                    service.agregarOperativo(operativito);
                    return RedirectToAction("Index");
                }
                else
                {
                    CargarListas();
                    return View(operativito);
                }
            }
            catch
            {
                CargarListas();
                return View(operativito);
            }
        }
        // GET: OperativosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                CargarListas();
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
                    if (!service.existeAgentePorNombre(operativito.NombreAgente1) ||
                        !service.existeAgentePorNombre(operativito.NombreAgente2) ||
                        !service.existeAgentePorNombre(operativito.NombreAgente3))
                    {
                        ModelState.AddModelError("", "Debe seleccionar agentes activos registrados.");
                        CargarListas();
                        return View(operativito);
                    }

                    // Se buscan los tres agentes para obtener sus salarios
                    var agente1 = service.buscarAgentePorNombre(operativito.NombreAgente1);
                    var agente2 = service.buscarAgentePorNombre(operativito.NombreAgente2);
                    var agente3 = service.buscarAgentePorNombre(operativito.NombreAgente3);

                    operativito.CostoOperativo = operativito.CalcularCostoOperativo(
                        agente1.SalarioTotal, agente2.SalarioTotal, agente3.SalarioTotal);

                    service.actualizarOperativo(operativito);
                    return RedirectToAction("Index");
                }
                else
                {
                    CargarListas();
                    return View(operativito);
                }
            }
            catch
            {
                CargarListas();
                return View(operativito);
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

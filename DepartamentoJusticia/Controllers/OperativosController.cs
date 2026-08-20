using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class OperativosController : ControladorBase
    {
        // GET: OperativosController
        Service service;
        public OperativosController() { service = new Service(); }

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
            return RedirectToAction("Index");
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
                    if (!service.existeAgentePorNombre(operativito.NombreAgente1) || !service.existeAgentePorNombre(operativito.NombreAgente2) || !service.existeAgentePorNombre(operativito.NombreAgente3))
                    {
                        ModelState.AddModelError("", "Debe seleccionar agentes activos registrados");
                        ViewBag.Agentes = service.mostrarAgentesActivos();
                        ViewBag.Casos = service.mostrarCasos();
                        return View(operativito);
                    }

                    if (operativito.NombreAgente1 == operativito.NombreAgente2 || operativito.NombreAgente1 == operativito.NombreAgente3 || operativito.NombreAgente2 == operativito.NombreAgente3)
                    {
                        ModelState.AddModelError("", "Los tres agentes deben ser diferentes");
                        ViewBag.Agentes = service.mostrarAgentesActivos();
                        ViewBag.Casos = service.mostrarCasos();
                        return View(operativito);
                    }

                    // Se buscan los tres agentes para obtener sus salarios
                    var agente1 = service.obtenerAgenteParaCalculo(operativito.NombreAgente1);
                    var agente2 = service.obtenerAgenteParaCalculo(operativito.NombreAgente2);
                    var agente3 = service.obtenerAgenteParaCalculo(operativito.NombreAgente3);

                    operativito.CostoOperativo = operativito.CalcularCostoOperativo(agente1.SalarioTotal, agente2.SalarioTotal, agente3.SalarioTotal);

                    service.agregarOperativo(operativito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Agentes = service.mostrarAgentesActivos();
                    ViewBag.Casos = service.mostrarCasos();
                    return View(operativito);
                }
            }
            catch
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                ViewBag.Casos = service.mostrarCasos();
                return View(operativito);
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
                    if (!service.existeAgentePorNombre(operativito.NombreAgente1) || !service.existeAgentePorNombre(operativito.NombreAgente2) || !service.existeAgentePorNombre(operativito.NombreAgente3))
                    {
                        ModelState.AddModelError("", "Debe seleccionar agentes activos registrados");
                        ViewBag.Agentes = service.mostrarAgentesActivos();
                        ViewBag.Casos = service.mostrarCasos();
                        return View(operativito);
                    }

                    if (operativito.NombreAgente1 == operativito.NombreAgente2 || operativito.NombreAgente1 == operativito.NombreAgente3 || operativito.NombreAgente2 == operativito.NombreAgente3)
                    {
                        ModelState.AddModelError("", "Los tres agentes deben ser diferentes");
                        ViewBag.Agentes = service.mostrarAgentesActivos();
                        ViewBag.Casos = service.mostrarCasos();
                        return View(operativito);
                    }

                    // Se buscan los tres agentes para obtener sus salarios
                    var agente1 = service.obtenerAgenteParaCalculo(operativito.NombreAgente1);
                    var agente2 = service.obtenerAgenteParaCalculo(operativito.NombreAgente2);
                    var agente3 = service.obtenerAgenteParaCalculo(operativito.NombreAgente3);

                    operativito.CostoOperativo = operativito.CalcularCostoOperativo(agente1.SalarioTotal, agente2.SalarioTotal, agente3.SalarioTotal);

                    service.actualizarOperativo(operativito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Agentes = service.mostrarAgentesActivos();
                    ViewBag.Casos = service.mostrarCasos();
                    return View(operativito);
                }
            }
            catch
            {
                ViewBag.Agentes = service.mostrarAgentesActivos();
                ViewBag.Casos = service.mostrarCasos();
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
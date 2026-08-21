using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
<<<<<<< HEAD
using DepartamentoJusticia.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

/// <summary>Gestion de las audiencias relacionadas con casos judiciales y tribunales.</summary>
public class AudienciasController : ControladorBase
{
    private readonly Service servicio;

    public AudienciasController(Service servicio)
    {
        this.servicio = servicio;
    }

    #region Mostrar y buscar

    [HttpGet]
    public IActionResult Index(BusquedaAudienciaViewModel filtros)
    {
        filtros ??= new BusquedaAudienciaViewModel();
        filtros.Tribunales = this.servicio.ObtenerNombresDeTribunal();
        filtros.Resultados = filtros.HayFiltros
            ? this.servicio.BuscarAudiencias(filtros.NombreTribunal, filtros.TipoAudiencia, filtros.Estado)
            : this.servicio.ObtenerAudiencias();

        if (filtros.HayFiltros && filtros.Resultados.Count == 0)
        {
            TempData["Aviso"] = "No se encontraron audiencias con los criterios indicados.";
        }

        return View(filtros);
    }

    [HttpGet]
    public IActionResult Detalles(int id)
    {
        Audiencia? audiencia = this.servicio.ObtenerAudiencia(id);

        if (audiencia == null)
        {
            TempData["Error"] = "La audiencia solicitada no existe.";
            return RedirectToAction(nameof(Index));
        }

        return View("Detalles", audiencia);
    }

    [HttpGet]
    public IActionResult Details(int id)
    {
        return Detalles(id);
    }

    #endregion

    #region Agregar

    [HttpGet]
    public IActionResult Crear()
    {
        return View("Crear", CrearModeloFormulario());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return Crear();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(AudienciaViewModel modelo)
    {
        ValidarAudiencia(modelo.Audiencia);

        if (!ModelState.IsValid)
        {
            CargarListasFormulario(modelo);
            return View("Crear", modelo);
        }

        if (!this.servicio.AgregarAudiencia(modelo.Audiencia))
        {
            TempData["Error"] = "No fue posible registrar la audiencia.";
            CargarListasFormulario(modelo);
            return View("Crear", modelo);
        }

        TempData["Exito"] = "La audiencia se registro correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(AudienciaViewModel modelo)
    {
        return Crear(modelo);
    }

    #endregion

    #region Actualizar

    [HttpGet]
    public IActionResult Editar(int id)
    {
        Audiencia? audiencia = this.servicio.ObtenerAudiencia(id);

        if (audiencia == null)
        {
            TempData["Error"] = "La audiencia solicitada no existe.";
            return RedirectToAction(nameof(Index));
        }

        AudienciaViewModel modelo = CrearModeloFormulario();
        modelo.Audiencia = audiencia;
        return View("Editar", modelo);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return Editar(id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(AudienciaViewModel modelo)
    {
        ValidarAudiencia(modelo.Audiencia);

        if (!ModelState.IsValid)
        {
            CargarListasFormulario(modelo);
            return View("Editar", modelo);
        }

        if (!this.servicio.ActualizarAudiencia(modelo.Audiencia))
        {
            TempData["Error"] = "No fue posible actualizar la audiencia.";
            CargarListasFormulario(modelo);
            return View("Editar", modelo);
        }

        TempData["Exito"] = "Los datos de la audiencia se actualizaron correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(AudienciaViewModel modelo)
    {
        return Editar(modelo);
    }

    #endregion

    #region Eliminar

    [HttpGet]
    public IActionResult Eliminar(int id)
    {
        Audiencia? audiencia = this.servicio.ObtenerAudiencia(id);

        if (audiencia == null)
        {
            TempData["Error"] = "La audiencia solicitada no existe.";
            return RedirectToAction(nameof(Index));
        }

        return View("Eliminar", audiencia);
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        return Eliminar(id);
    }

    [HttpPost]
    [ActionName("Eliminar")]
    [ValidateAntiForgeryToken]
    public IActionResult ConfirmarEliminar(int id)
    {
        if (!this.servicio.EliminarAudiencia(id))
        {
            TempData["Error"] = "No fue posible eliminar la audiencia.";
            return RedirectToAction(nameof(Index));
        }

        TempData["Exito"] = "La audiencia se elimino correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ActionName("Delete")]
    [ValidateAntiForgeryToken]
    public IActionResult DeleteConfirmed(int id)
    {
        return ConfirmarEliminar(id);
    }

    #endregion

    #region Metodos auxiliares

    private AudienciaViewModel CrearModeloFormulario()
    {
        AudienciaViewModel modelo = new();
        CargarListasFormulario(modelo);
        return modelo;
    }

    private void CargarListasFormulario(AudienciaViewModel modelo)
    {
        modelo.Tribunales = this.servicio.ObtenerNombresDeTribunal();
        modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
    }

    private void ValidarAudiencia(Audiencia audiencia)
    {
        if (audiencia.Fecha == DateTime.MinValue)
        {
            ModelState.AddModelError("Audiencia.Fecha", "La fecha es obligatoria.");
        }

        if (string.IsNullOrWhiteSpace(audiencia.TipoAudiencia))
        {
            ModelState.AddModelError("Audiencia.TipoAudiencia", "Debe seleccionar el tipo de audiencia.");
        }

        if (string.IsNullOrWhiteSpace(audiencia.NombreTribunal))
        {
            ModelState.AddModelError("Audiencia.NombreTribunal", "Debe seleccionar el tribunal asignado.");
        }
        else if (audiencia.NombreTribunal.Length > 120)
        {
            ModelState.AddModelError("Audiencia.NombreTribunal", "El tribunal no puede superar los 120 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(audiencia.NumeroCaso))
        {
            ModelState.AddModelError("Audiencia.NumeroCaso", "Debe seleccionar el caso judicial.");
        }

        if (!string.IsNullOrEmpty(audiencia.Observaciones) && audiencia.Observaciones.Length > 500)
        {
            ModelState.AddModelError("Audiencia.Observaciones", "Las observaciones no pueden superar los 500 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(audiencia.Estado))
        {
            ModelState.AddModelError("Audiencia.Estado", "Debe seleccionar el estado de la audiencia.");
        }
    }

    #endregion
}
=======
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class AudienciasController : ControladorBase
    {
        // GET: AudienciasController
        Service service;
        public AudienciasController() { service = new Service(); }

        public ActionResult Index()
        {
            ViewBag.Tribunales = service.mostrarNombresDeTribunal();
            var audiencias = service.mostrarAudiencias();
            return View(audiencias);
        }
        // POST: AudienciasController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string nombreTribunal, string tipoAudiencia, string estado)
        {
            ViewBag.Tribunales = service.mostrarNombresDeTribunal();
            try
            {
                if (!string.IsNullOrEmpty(nombreTribunal))
                    return View(service.buscarAudienciasPorTribunal(nombreTribunal));
                else if (!string.IsNullOrEmpty(tipoAudiencia))
                    return View(service.buscarAudienciasPorTipo(tipoAudiencia));
                else if (!string.IsNullOrEmpty(estado))
                    return View(service.buscarAudienciasPorEstado(estado));
                else
                    return View(service.mostrarAudiencias());
            }
            catch
            {
                return View(service.mostrarAudiencias());
            }
        }
        // GET: AudienciasController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: AudienciasController/Create
        public ActionResult Create()
        {
            ViewBag.Tribunales = service.mostrarNombresDeTribunal();
            ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
            return View(new Audiencia());
        }
        // POST: AudienciasController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Audiencia audiencita)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    service.agregarAudiencia(audiencita);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(audiencita);
                }
            }
            catch
            {
                ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(audiencita);
            }
        }
        // GET: AudienciasController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                var audienciaBuscada = service.buscarAudiencia(id);
                return View(audienciaBuscada);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: AudienciasController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Audiencia audiencita)
        {
            try
            {
               
                if (ModelState.IsValid)
                {
                    service.actualizarAudiencia(audiencita);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(audiencita);
                }
            }
            catch
            {
                ViewBag.Tribunales = service.mostrarNombresDeTribunal();
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(audiencita);
            }
        }
        // GET: AudienciasController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var audienciaEliminada = service.buscarAudiencia(id);
                service.eliminarAudiencia(audienciaEliminada);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}
>>>>>>> refactor/homogeneizar-crud-profesora

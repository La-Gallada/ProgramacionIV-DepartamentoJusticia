using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
<<<<<<< HEAD
using DepartamentoJusticia.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

/// <summary>
/// Modulo de Sospechosos.
/// EQUIPO: este controlador es la plantilla de referencia. Para su modulo
/// copien esta estructura y cambien el modelo, el Service y los textos.
/// </summary>
public class SospechososController : ControladorBase
{
    private readonly Service servicio;

    public SospechososController(Service servicio)
    {
        this.servicio = servicio;
    }

    #region Mostrar y buscar

    [HttpGet]
    public IActionResult Index(BusquedaSospechosoViewModel filtros)
    {
        filtros ??= new BusquedaSospechosoViewModel();

        filtros.Resultados = filtros.HayFiltros
            ? this.servicio.BuscarSospechosos(filtros.Nombre, filtros.EstadoLegal, filtros.PeligrosidadMinima, filtros.PeligrosidadMaxima)
            : this.servicio.ObtenerSospechosos();

        if (filtros.HayFiltros && filtros.Resultados.Count == 0)
        {
            TempData["Aviso"] = "No se encontraron sospechosos con los criterios indicados.";
        }

        return View(filtros);
    }

    [HttpGet]
    public IActionResult Detalles(int id)
    {
        Sospechoso? sospechoso = this.servicio.ObtenerSospechoso(id);

        if (sospechoso == null)
        {
            TempData["Error"] = "El sospechoso solicitado no existe.";
            return RedirectToAction(nameof(Index));
        }

        return View("Detalles", sospechoso);
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
        SospechosoViewModel modelo = new()
        {
            CasosJudiciales = this.servicio.ObtenerNumerosDeCaso()
        };

        return View("Crear", modelo);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return Crear();
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(SospechosoViewModel modelo)
    {
        ValidarSospechoso(modelo.Sospechoso);

        if (!ModelState.IsValid)
        {
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View("Crear", modelo);
        }

        if (this.servicio.ExisteIdentificacionSospechoso(modelo.Sospechoso.Identificacion))
        {
            ModelState.AddModelError("Sospechoso.Identificacion", "Ya existe un sospechoso registrado con esa identificacion.");
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View("Crear", modelo);
        }

        if (!this.servicio.AgregarSospechoso(modelo.Sospechoso))
        {
            TempData["Error"] = "No fue posible registrar el sospechoso.";
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View("Crear", modelo);
        }

        TempData["Exito"] = $"El sospechoso {modelo.Sospechoso.NombreCompleto} se registro correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Create(SospechosoViewModel modelo)
    {
        return Crear(modelo);
    }

    #endregion

    #region Actualizar

    [HttpGet]
    public IActionResult Editar(int id)
    {
        Sospechoso? sospechoso = this.servicio.ObtenerSospechoso(id);

        if (sospechoso == null)
        {
            TempData["Error"] = "El sospechoso solicitado no existe.";
            return RedirectToAction(nameof(Index));
        }

        SospechosoViewModel modelo = new()
        {
            Sospechoso = sospechoso,
            CasosJudiciales = this.servicio.ObtenerNumerosDeCaso()
        };

        return View("Editar", modelo);
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        return Editar(id);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(SospechosoViewModel modelo)
    {
        ValidarSospechoso(modelo.Sospechoso);

        if (!ModelState.IsValid)
        {
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View("Editar", modelo);
        }

        if (this.servicio.ExisteIdentificacionSospechoso(modelo.Sospechoso.Identificacion, modelo.Sospechoso.Id))
        {
            ModelState.AddModelError("Sospechoso.Identificacion", "Ya existe otro sospechoso registrado con esa identificacion.");
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View("Editar", modelo);
        }

        if (!this.servicio.ActualizarSospechoso(modelo.Sospechoso))
        {
            TempData["Error"] = "No fue posible actualizar el sospechoso.";
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View("Editar", modelo);
        }

        TempData["Exito"] = "Los datos del sospechoso se actualizaron correctamente.";
        return RedirectToAction(nameof(Index));
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Edit(SospechosoViewModel modelo)
    {
        return Editar(modelo);
    }

    #endregion

    #region Eliminar

    [HttpGet]
    public IActionResult Eliminar(int id)
    {
        Sospechoso? sospechoso = this.servicio.ObtenerSospechoso(id);

        if (sospechoso == null)
        {
            TempData["Error"] = "El sospechoso solicitado no existe.";
            return RedirectToAction(nameof(Index));
        }

        return View("Eliminar", sospechoso);
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
        if (!this.servicio.EliminarSospechoso(id))
        {
            TempData["Error"] = "No fue posible eliminar el sospechoso.";
            return RedirectToAction(nameof(Index));
        }

        TempData["Exito"] = "El sospechoso se elimino correctamente.";
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

    private void ValidarSospechoso(Sospechoso sospechoso)
    {
        if (string.IsNullOrWhiteSpace(sospechoso.Identificacion))
        {
            ModelState.AddModelError("Sospechoso.Identificacion", "La identificacion es obligatoria.");
        }
        else if (sospechoso.Identificacion.Length > 30)
        {
            ModelState.AddModelError("Sospechoso.Identificacion", "La identificacion no puede superar los 30 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(sospechoso.NombreCompleto))
        {
            ModelState.AddModelError("Sospechoso.NombreCompleto", "El nombre completo es obligatorio.");
        }
        else if (sospechoso.NombreCompleto.Length > 120)
        {
            ModelState.AddModelError("Sospechoso.NombreCompleto", "El nombre no puede superar los 120 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(sospechoso.Nacionalidad))
        {
            ModelState.AddModelError("Sospechoso.Nacionalidad", "La nacionalidad es obligatoria.");
        }
        else if (sospechoso.Nacionalidad.Length > 60)
        {
            ModelState.AddModelError("Sospechoso.Nacionalidad", "La nacionalidad no puede superar los 60 caracteres.");
        }

        if (sospechoso.FechaNacimiento == DateTime.MinValue || sospechoso.FechaNacimiento.Date > DateTime.Today)
        {
            ModelState.AddModelError("Sospechoso.FechaNacimiento", "La fecha de nacimiento debe ser anterior o igual a hoy.");
        }

        if (sospechoso.NivelPeligrosidad < 1 || sospechoso.NivelPeligrosidad > 100)
        {
            ModelState.AddModelError("Sospechoso.NivelPeligrosidad", "El nivel de peligrosidad debe estar entre 1 y 100.");
        }

        if (string.IsNullOrWhiteSpace(sospechoso.EstadoLegal))
        {
            ModelState.AddModelError("Sospechoso.EstadoLegal", "Debe seleccionar el estado legal.");
        }

        if (string.IsNullOrWhiteSpace(sospechoso.NumeroCaso))
        {
            ModelState.AddModelError("Sospechoso.NumeroCaso", "Debe seleccionar el caso judicial vinculado.");
        }
    }
}
=======
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class SospechososController : ControladorBase
    {
        // GET: SospechososController
        Service service;
        public SospechososController() { service = new Service(); }

        public ActionResult Index()
        {
            var sospechosos = service.mostrarSospechosos();
            return View(sospechosos);
        }
        // POST: SospechososController (busqueda por criterios)
        [HttpPost]
        public ActionResult Index(string nombreCompleto, string estadoLegal, string nivelRiesgo)
        {
            try
            {
                if (!string.IsNullOrEmpty(nombreCompleto))
                    return View(service.buscarSospechososPorNombre(nombreCompleto));
                else if (!string.IsNullOrEmpty(estadoLegal))
                    return View(service.buscarSospechososPorEstadoLegal(estadoLegal));
                else if (!string.IsNullOrEmpty(nivelRiesgo))
                    return View(service.buscarSospechososPorRiesgo(nivelRiesgo));
                else
                    return View(service.mostrarSospechosos());
            }
            catch
            {
                return View(service.mostrarSospechosos());
            }
        }
        // GET: SospechososController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: SospechososController/Create
        public ActionResult Create()
        {
            ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
            return View(new Sospechoso());
        }
        // POST: SospechososController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Sospechoso sospechosito)
        {
            try
            {
              
                if (ModelState.IsValid)
                {
                    sospechosito.NivelRiesgo = sospechosito.CalcularNivelRiesgo();
                    service.agregarSospechoso(sospechosito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(sospechosito);
                }
            }
            catch
            {
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(sospechosito);
            }
        }
        // GET: SospechososController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                var sospechosoBuscado = service.buscarSospechoso(id);
                return View(sospechosoBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: SospechososController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Sospechoso sospechosito)
        {
            try
            {
                
                if (ModelState.IsValid)
                {
                    sospechosito.NivelRiesgo = sospechosito.CalcularNivelRiesgo();
                    service.actualizarSospechoso(sospechosito);
                    return RedirectToAction("Index");
                }
                else
                {
                    ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                    return View(sospechosito);
                }
            }
            catch
            {
                ViewBag.CasosJudiciales = service.mostrarNumerosDeCaso();
                return View(sospechosito);
            }
        }
        // GET: SospechososController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var sospechosoEliminado = service.buscarSospechoso(id);
                service.eliminarSospechoso(sospechosoEliminado);
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

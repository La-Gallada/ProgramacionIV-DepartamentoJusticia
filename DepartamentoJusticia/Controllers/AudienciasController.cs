using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using DepartamentoJusticia.ViewModels;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

/// <summary>Gestion de las audiencias relacionadas con casos judiciales y tribunales.</summary>
public class AudienciasController : Controller
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

        return View(audiencia);
    }

    #endregion

    #region Agregar

    [HttpGet]
    public IActionResult Crear()
    {
        return View(CrearModeloFormulario());
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(AudienciaViewModel modelo)
    {
        if (!ModelState.IsValid)
        {
            CargarListasFormulario(modelo);
            return View(modelo);
        }

        if (!this.servicio.AgregarAudiencia(modelo.Audiencia))
        {
            TempData["Error"] = "No fue posible registrar la audiencia.";
            CargarListasFormulario(modelo);
            return View(modelo);
        }

        TempData["Exito"] = "La audiencia se registro correctamente.";
        return RedirectToAction(nameof(Index));
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
        return View(modelo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(AudienciaViewModel modelo)
    {
        if (!ModelState.IsValid)
        {
            CargarListasFormulario(modelo);
            return View(modelo);
        }

        if (!this.servicio.ActualizarAudiencia(modelo.Audiencia))
        {
            TempData["Error"] = "No fue posible actualizar la audiencia.";
            CargarListasFormulario(modelo);
            return View(modelo);
        }

        TempData["Exito"] = "Los datos de la audiencia se actualizaron correctamente.";
        return RedirectToAction(nameof(Index));
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

        return View(audiencia);
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

    #endregion
}

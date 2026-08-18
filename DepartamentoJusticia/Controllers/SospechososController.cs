using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
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

        return View(sospechoso);
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

        return View(modelo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Crear(SospechosoViewModel modelo)
    {
        ValidarSospechoso(modelo.Sospechoso);

        if (!ModelState.IsValid)
        {
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View(modelo);
        }

        if (this.servicio.ExisteIdentificacionSospechoso(modelo.Sospechoso.Identificacion))
        {
            ModelState.AddModelError("Sospechoso.Identificacion", "Ya existe un sospechoso registrado con esa identificacion.");
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View(modelo);
        }

        if (!this.servicio.AgregarSospechoso(modelo.Sospechoso))
        {
            TempData["Error"] = "No fue posible registrar el sospechoso.";
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View(modelo);
        }

        TempData["Exito"] = $"El sospechoso {modelo.Sospechoso.NombreCompleto} se registro correctamente.";
        return RedirectToAction(nameof(Index));
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

        return View(modelo);
    }

    [HttpPost]
    [ValidateAntiForgeryToken]
    public IActionResult Editar(SospechosoViewModel modelo)
    {
        ValidarSospechoso(modelo.Sospechoso);

        if (!ModelState.IsValid)
        {
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View(modelo);
        }

        if (this.servicio.ExisteIdentificacionSospechoso(modelo.Sospechoso.Identificacion, modelo.Sospechoso.Id))
        {
            ModelState.AddModelError("Sospechoso.Identificacion", "Ya existe otro sospechoso registrado con esa identificacion.");
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View(modelo);
        }

        if (!this.servicio.ActualizarSospechoso(modelo.Sospechoso))
        {
            TempData["Error"] = "No fue posible actualizar el sospechoso.";
            modelo.CasosJudiciales = this.servicio.ObtenerNumerosDeCaso();
            return View(modelo);
        }

        TempData["Exito"] = "Los datos del sospechoso se actualizaron correctamente.";
        return RedirectToAction(nameof(Index));
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

        return View(sospechoso);
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

    #endregion

    #region Validaciones

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
        else if (sospechoso.EstadoLegal.Length > 30)
        {
            ModelState.AddModelError("Sospechoso.EstadoLegal", "El estado legal no puede superar los 30 caracteres.");
        }

        if (string.IsNullOrWhiteSpace(sospechoso.NumeroCaso))
        {
            ModelState.AddModelError("Sospechoso.NumeroCaso", "Debe seleccionar el caso judicial vinculado.");
        }
        else if (sospechoso.NumeroCaso.Length > 30)
        {
            ModelState.AddModelError("Sospechoso.NumeroCaso", "El numero de caso no puede superar los 30 caracteres.");
        }
    }

    #endregion
}

using DepartamentoJusticia.Models;

namespace DepartamentoJusticia.ViewModels;

/// <summary>
/// Modelo de la pantalla de listado y busqueda de sospechosos.
/// Los tres criterios del enunciado (nombre, estado legal y nivel de
/// peligrosidad) son combinables entre si.
/// </summary>
public class BusquedaSospechosoViewModel
{
    public string? Nombre { get; set; }
    public string? EstadoLegal { get; set; }
    public int? PeligrosidadMinima { get; set; }
    public int? PeligrosidadMaxima { get; set; }

    public List<Sospechoso> Resultados { get; set; } = new();

    public bool HayFiltros =>
        !string.IsNullOrWhiteSpace(Nombre)
        || !string.IsNullOrWhiteSpace(EstadoLegal)
        || PeligrosidadMinima.HasValue
        || PeligrosidadMaxima.HasValue;
}

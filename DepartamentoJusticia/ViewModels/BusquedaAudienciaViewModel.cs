using DepartamentoJusticia.Models;

namespace DepartamentoJusticia.ViewModels;

/// <summary>Modelo para el listado y la busqueda combinable de audiencias.</summary>
public class BusquedaAudienciaViewModel
{
    public string? NombreTribunal { get; set; }
    public string? TipoAudiencia { get; set; }
    public string? Estado { get; set; }

    public List<Audiencia> Resultados { get; set; } = new();
    public List<string> Tribunales { get; set; } = new();

    public bool HayFiltros =>
        !string.IsNullOrWhiteSpace(NombreTribunal)
        || !string.IsNullOrWhiteSpace(TipoAudiencia)
        || !string.IsNullOrWhiteSpace(Estado);
}

using DepartamentoJusticia.Models;

namespace DepartamentoJusticia.ViewModels;

/// <summary>Modelo para crear y editar audiencias, con los datos de los combos.</summary>
public class AudienciaViewModel
{
    public Audiencia Audiencia { get; set; } = new();
    public List<string> Tribunales { get; set; } = new();
    public List<string> CasosJudiciales { get; set; } = new();

    public static readonly string[] TiposAudiencia = { "Privada", "Pública" };

    public static readonly string[] Estados =
    {
        "Programada",
        "En Desarrollo",
        "Suspendida",
        "Celebrada"
    };
}

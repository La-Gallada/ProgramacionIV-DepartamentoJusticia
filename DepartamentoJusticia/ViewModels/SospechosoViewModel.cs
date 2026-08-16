using DepartamentoJusticia.Models;

namespace DepartamentoJusticia.ViewModels;

/// <summary>
/// Modelo para las pantallas de Crear y Editar un sospechoso.
/// Ademas del sospechoso lleva las listas que alimentan los combos.
/// </summary>
public class SospechosoViewModel
{
    public Sospechoso Sospechoso { get; set; } = new();

    /// <summary>Numeros de caso traidos de la base de datos.</summary>
    public List<string> CasosJudiciales { get; set; } = new();

    public static readonly string[] EstadosLegales =
    {
        "Sin Cargos",
        "Investigado",
        "Detenido",
        "Procesado",
        "Sentenciado"
    };
}

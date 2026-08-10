using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Operativo
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nombre del operativo")]
    public string NombreOperativo { get; set; } = string.Empty;

    [Display(Name = "Fecha de ejecución")]
    public DateTime FechaEjecucion { get; set; }

    [Required]
    public string Ciudad { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Tipo de operativo")]
    public string TipoOperativo { get; set; } = string.Empty;

    [Display(Name = "Agente 1")]
    public int Agente1Id { get; set; }

    public Agente Agente1 { get; set; } = null!;

    [Display(Name = "Agente 2")]
    public int Agente2Id { get; set; }

    public Agente Agente2 { get; set; } = null!;

    [Display(Name = "Agente 3")]
    public int Agente3Id { get; set; }

    public Agente Agente3 { get; set; } = null!;

    [Required]
    public string Resultado { get; set; } = string.Empty;

    [Display(Name = "Caso judicial")]
    public int CasoJudicialId { get; set; }

    public CasoJudicial CasoJudicial { get; set; } = null!;
}

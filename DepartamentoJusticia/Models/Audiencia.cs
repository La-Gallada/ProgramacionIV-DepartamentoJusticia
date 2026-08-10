using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Audiencia
{
    public int Id { get; set; }

    public DateTime Fecha { get; set; }

    public TimeSpan Hora { get; set; }

    [Required]
    [Display(Name = "Tipo de audiencia")]
    public string TipoAudiencia { get; set; } = string.Empty;

    [Display(Name = "Tribunal")]
    public int TribunalId { get; set; }

    public Tribunal Tribunal { get; set; } = null!;

    [Display(Name = "Caso judicial")]
    public int CasoJudicialId { get; set; }

    public CasoJudicial CasoJudicial { get; set; } = null!;

    [Required]
    public string Observaciones { get; set; } = string.Empty;

    [Required]
    public string Estado { get; set; } = string.Empty;
}

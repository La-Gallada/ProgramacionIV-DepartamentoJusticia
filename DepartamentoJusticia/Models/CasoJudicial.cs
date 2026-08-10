using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class CasoJudicial
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Número de caso")]
    public string NumeroCaso { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Nombre del caso")]
    public string NombreCaso { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Tipo de delito")]
    public string TipoDelito { get; set; } = string.Empty;

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Display(Name = "Fecha de apertura")]
    public DateTime FechaApertura { get; set; }

    [Required]
    public string Descripcion { get; set; } = string.Empty;

    [Display(Name = "Agente")]
    public int AgenteId { get; set; }

    public Agente Agente { get; set; } = null!;

    public ICollection<Sospechoso> Sospechosos { get; set; } = new List<Sospechoso>();

    public ICollection<Evidencia> Evidencias { get; set; } = new List<Evidencia>();

    public ICollection<Operativo> Operativos { get; set; } = new List<Operativo>();

    public ICollection<Audiencia> Audiencias { get; set; } = new List<Audiencia>();
}

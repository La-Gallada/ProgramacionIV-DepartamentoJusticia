using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Sospechoso
{
    public int Id { get; set; }

    [Required]
    public string Identificacion { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required]
    public string Nacionalidad { get; set; } = string.Empty;

    [Display(Name = "Fecha de nacimiento")]
    public DateTime FechaNacimiento { get; set; }

    [Range(1, 100)]
    [Display(Name = "Nivel de peligrosidad")]
    public int NivelPeligrosidad { get; set; }

    [Required]
    [Display(Name = "Estado legal")]
    public string EstadoLegal { get; set; } = string.Empty;

    [Display(Name = "Caso judicial")]
    public int CasoJudicialId { get; set; }

    public CasoJudicial CasoJudicial { get; set; } = null!;
}

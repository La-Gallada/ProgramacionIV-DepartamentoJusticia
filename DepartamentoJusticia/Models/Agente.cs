using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Agente
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Número de placa")]
    public string NumeroPlaca { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required]
    public string Especialidad { get; set; } = string.Empty;

    [Required]
    public string Rango { get; set; } = string.Empty;

    [Display(Name = "Fecha de ingreso")]
    public DateTime FechaIngreso { get; set; }

    [Display(Name = "Años de experiencia")]
    public int AniosExperiencia { get; set; }

    [Display(Name = "Salario base")]
    public decimal SalarioBase { get; set; }

    [Required]
    public string Estado { get; set; } = string.Empty;

    public ICollection<CasoJudicial> CasosJudiciales { get; set; } = new List<CasoJudicial>();
}

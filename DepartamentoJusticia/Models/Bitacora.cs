using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Bitacora
{
    public int Id { get; set; }

    [Display(Name = "Fecha y hora")]
    public DateTime FechaHora { get; set; }

    [Required]
    public string Usuario { get; set; } = string.Empty;

    [Required]
    public string Resultado { get; set; } = string.Empty;
}

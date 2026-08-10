using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Tribunal
{
    public int Id { get; set; }

    [Required]
    public string Nombre { get; set; } = string.Empty;

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Required]
    public string Ciudad { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Juez asignado")]
    public string JuezAsignado { get; set; } = string.Empty;

    [Display(Name = "Cantidad de salas")]
    public int CantidadSalas { get; set; }

    public ICollection<Audiencia> Audiencias { get; set; } = new List<Audiencia>();
}

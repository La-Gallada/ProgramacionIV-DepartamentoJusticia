using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Evidencia
{
    public int Id { get; set; }

    [Required]
    public string Codigo { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Tipo de evidencia")]
    public string TipoEvidencia { get; set; } = string.Empty;

    [Required]
    public string Descripcion { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Lugar de hallazgo")]
    public string LugarHallazgo { get; set; } = string.Empty;

    [Display(Name = "Fecha de recolección")]
    public DateTime FechaRecoleccion { get; set; }

    [Display(Name = "Caso judicial")]
    public int CasoJudicialId { get; set; }

    public CasoJudicial CasoJudicial { get; set; } = null!;
}

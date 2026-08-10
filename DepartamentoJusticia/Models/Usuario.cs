using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Usuario
{
    public int Id { get; set; }

    [Required]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get; set; } = string.Empty;

    [Required]
    public string Identificacion { get; set; } = string.Empty;

    [Required]
    public string Cargo { get; set; } = string.Empty;

    [Display(Name = "Fecha de registro")]
    public DateTime FechaRegistro { get; set; }

    [Required]
    public string Estado { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Nombre de usuario")]
    public string NombreUsuario { get; set; } = string.Empty;

    [Required]
    [Display(Name = "Contraseña")]
    public string Contrasena { get; set; } = string.Empty;
}

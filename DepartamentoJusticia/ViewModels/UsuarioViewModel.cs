using System.ComponentModel.DataAnnotations;
using DepartamentoJusticia.Models;

namespace DepartamentoJusticia.ViewModels;

public class UsuarioViewModel
{
    public Usuario Usuario { get; set; } = new();

    [Required]
    [Display(Name = "Contraseña")]
    public string Contrasena { get; set; } = string.Empty;

    [Required]
    [Compare(nameof(Contrasena), ErrorMessage = "La confirmación de contraseña no coincide.")]
    [Display(Name = "Confirmar contraseña")]
    public string ConfirmarContrasena { get; set; } = string.Empty;
}

using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Usuario
{
    private int id;
    private string nombreCompleto;
    private string identificacion;
    private string cargo;
    private DateTime fechaRegistro;
    private string estado;
    private string nombreUsuario;
    private string contrasenia;
    public Usuario(int id, string nombreCompleto, string identificacion, string cargo, DateTime fechaRegistro, string estado, string nombreUsuario, string contrasenia)
    {
        this.Id = id;
        this.NombreCompleto = nombreCompleto;
        this.Identificacion = identificacion;
        this.Cargo = cargo;
        this.FechaRegistro = fechaRegistro;
        this.Estado = estado;
        this.NombreUsuario = nombreUsuario;
        this.Contrasenia = contrasenia;
    }

    public Usuario()
    {
        this.Id = 0;
        this.NombreCompleto = "";
        this.Identificacion = "";
        this.Cargo = "";
        this.FechaRegistro = DateTime.Now;
        this.Estado = "";
        this.NombreUsuario = "";
        this.Contrasenia = "";
    }


    [Required]
    public int Id { get => id; set => id = value; }
    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

    [Required(ErrorMessage = "La identificación es obligatoria.")]
    public string Identificacion { get => identificacion; set => identificacion = value; }

    [Required(ErrorMessage = "El cargo es obligatorio.")]
    public string Cargo { get => cargo; set => cargo = value; }

    [Required(ErrorMessage = "La fecha de registro es obligatoria.")]
    public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    public string Estado { get => estado; set => estado = value; }

    [Required(ErrorMessage = "El nombre de usuario es obligatorio.")]
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }

    [Required(ErrorMessage = "La contraseña es obligatoria.")]
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
}

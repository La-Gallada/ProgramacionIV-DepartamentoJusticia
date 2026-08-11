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
        this.FechaRegistro = DateTime.MinValue;
        this.Estado = "";
        this.NombreUsuario = "";
        this.Contrasenia = "";
    }


    [Required]
    public int Id { get => id; set => id = value; }
    public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
    public string Identificacion { get => identificacion; set => identificacion = value; }
    public string Cargo { get => cargo; set => cargo = value; }
    public DateTime FechaRegistro { get => fechaRegistro; set => fechaRegistro = value; }
    public string Estado { get => estado; set => estado = value; }
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    public string Contrasenia { get => contrasenia; set => contrasenia = value; }
}

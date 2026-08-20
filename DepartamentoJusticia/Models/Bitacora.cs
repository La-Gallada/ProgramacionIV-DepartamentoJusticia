using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Bitacora
{
    private int id;
    private DateTime fecha;
    private TimeSpan hora;
    private string nombreUsuario;
    private string resultado;
    public Bitacora(int id, DateTime fecha, TimeSpan hora, string nombreUsuario, string resultado)
    {
        this.Id = id;
        this.Fecha = fecha;
        this.Hora = hora;
        this.NombreUsuario = nombreUsuario;
        this.Resultado = resultado;
    }
    public Bitacora()
    {
        this.Id = 0;
        this.Fecha = DateTime.Now;
        this.Hora = TimeSpan.Zero;
        this.NombreUsuario = "";
        this.Resultado = "";
    }

    [Required]
    public int Id { get => id; set => id = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public TimeSpan Hora { get => hora; set => hora = value; }
    public string NombreUsuario { get => nombreUsuario; set => nombreUsuario = value; }
    public string Resultado { get => resultado; set => resultado = value; }
}

using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Audiencia
{
    private int id;
    private DateTime fecha;
    private TimeSpan hora;
    private string tipoAudiencia;
    private string nombreTribunal;
    private string numeroCaso;
    private string observaciones;
    private string estado;

    public Audiencia(int id, DateTime fecha, TimeSpan hora, string tipoAudiencia, string nombreTribunal, string numeroCaso, string observaciones, string estado)
    {
        this.Id = id;
        this.Fecha = fecha;
        this.Hora = hora;
        this.TipoAudiencia = tipoAudiencia;
        this.NombreTribunal = nombreTribunal;
        this.NumeroCaso = numeroCaso;
        this.Observaciones = observaciones;
        this.Estado = estado;
    }
    public Audiencia()
    {
        this.Id = 0;
        this.Fecha = DateTime.MinValue;
        this.Hora = TimeSpan.Zero;
        this.TipoAudiencia = "";
        this.NombreTribunal = "";
        this.NumeroCaso = "";
        this.Observaciones = "";
        this.Estado = "";
    }

    [Required]
    public int Id { get => id; set => id = value; }
    public DateTime Fecha { get => fecha; set => fecha = value; }
    public TimeSpan Hora { get => hora; set => hora = value; }
    public string TipoAudiencia { get => tipoAudiencia; set => tipoAudiencia = value; }
    public string NombreTribunal { get => nombreTribunal; set => nombreTribunal = value; }
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }
    public string Observaciones { get => observaciones; set => observaciones = value; }
    public string Estado { get => estado; set => estado = value; }
}

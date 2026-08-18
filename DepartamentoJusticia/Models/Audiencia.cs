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

    public int Id { get => id; set => id = value; }

    [DataType(DataType.Date)]
    [Display(Name = "Fecha")]
    public DateTime Fecha { get => fecha; set => fecha = value; }

    [DataType(DataType.Time)]
    [Display(Name = "Hora")]
    public TimeSpan Hora { get => hora; set => hora = value; }

    [Display(Name = "Tipo de audiencia")]
    public string TipoAudiencia { get => tipoAudiencia; set => tipoAudiencia = value; }

    [Display(Name = "Tribunal asignado")]
    public string NombreTribunal { get => nombreTribunal; set => nombreTribunal = value; }

    [Display(Name = "Caso judicial vinculado")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }

    [Display(Name = "Observaciones")]
    public string Observaciones { get => observaciones; set => observaciones = value; }

    [Display(Name = "Estado")]
    public string Estado { get => estado; set => estado = value; }
}

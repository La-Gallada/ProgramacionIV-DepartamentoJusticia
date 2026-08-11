using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class CasoJudicial
{
    private int id;
    private string numeroCaso;
    private string nombreCaso;
    private string tipoDelito;
    private string estado;
    private DateTime fechaApertura;
    private string descripcion;
    private string nombreAgente;
    public CasoJudicial(int id, string numeroCaso, string nombreCaso, string tipoDelito, string estado, DateTime fechaApertura, string descripcion, string nombreAgente)
    {
        this.Id = id;
        this.NumeroCaso = numeroCaso;
        this.NombreCaso = nombreCaso;
        this.TipoDelito = tipoDelito;
        this.Estado = estado;
        this.FechaApertura = fechaApertura;
        this.Descripcion = descripcion;
        this.NombreAgente = nombreAgente;
    }
    public CasoJudicial()
    {
        this.Id = 0;
        this.NumeroCaso = "";
        this.NombreCaso = "";
        this.TipoDelito = "";
        this.Estado = "";
        this.FechaApertura = DateTime.MinValue;
        this.Descripcion = "";
        this.NombreAgente = "";
    }
    [Required]
    public int Id { get => id; set => id = value; }
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }
    public string NombreCaso { get => nombreCaso; set => nombreCaso = value; }
    public string TipoDelito { get => tipoDelito; set => tipoDelito = value; }
    public string Estado { get => estado; set => estado = value; }
    public DateTime FechaApertura { get => fechaApertura; set => fechaApertura = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string NombreAgente { get => nombreAgente; set => nombreAgente = value; }
}

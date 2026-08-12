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
    private string prioridad;
    public CasoJudicial(int id, string numeroCaso, string nombreCaso, string tipoDelito, string estado, DateTime fechaApertura, string descripcion, string nombreAgente,string prioridad)
    {
        this.Id = id;
        this.NumeroCaso = numeroCaso;
        this.NombreCaso = nombreCaso;
        this.TipoDelito = tipoDelito;
        this.Estado = estado;
        this.FechaApertura = fechaApertura;
        this.Descripcion = descripcion;
        this.NombreAgente = nombreAgente;
        this.Prioridad = prioridad;
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
        this.Prioridad = "";
    }
    public string CalcularPrioridad()
    {
        // Delitos económicos o contra el Estado
        if (TipoDelito == "Económicos" || TipoDelito == "Contra el Estado")
            return "Alta";
        // Delitos contra el patrimonio o la seguridad pública
        else if (TipoDelito == "Contra el Patrimonio" || TipoDelito == "Contra la Seguridad Pública")
            return "Media";
        // Delitos contra las personas
        else if (TipoDelito == "Contra las personas")
            return "Baja";
        // Si el tipo de delito no es válido
        else
            return "Sin definir";
    }

    public int Id { get => id; set => id = value; }
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }
    public string NombreCaso { get => nombreCaso; set => nombreCaso = value; }
    public string TipoDelito { get => tipoDelito; set => tipoDelito = value; }
    public string Estado { get => estado; set => estado = value; }
    public DateTime FechaApertura { get => fechaApertura; set => fechaApertura = value; }
    public string Descripcion { get => descripcion; set => descripcion = value; }
    public string NombreAgente { get => nombreAgente; set => nombreAgente = value; }
    public string Prioridad { get => prioridad; set => prioridad = value; }
}

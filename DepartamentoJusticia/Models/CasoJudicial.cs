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
    public CasoJudicial(int id, string numeroCaso, string nombreCaso, string tipoDelito, string estado, DateTime fechaApertura, string descripcion, string nombreAgente, string prioridad)
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
        this.FechaApertura = DateTime.Now;
        this.Descripcion = "";
        this.NombreAgente = "";
        this.Prioridad = "";
    }
    public string CalcularPrioridad()
    {
        // Prioridad segun el tipo de delito
        switch (TipoDelito)
        {
            // Delitos económicos o contra el Estado
            case "Económicos":
            case "Contra el Estado":
                return "Alta";
            // Delitos contra el patrimonio o la seguridad pública
            case "Contra el Patrimonio":
            case "Contra la Seguridad Pública":
                return "Media";
            // Delitos contra las personas
            case "Contra las personas":
                return "Baja";
            // Si el tipo de delito no es válido
            default:
                return "Sin definir";
        }
    }
    [Required]
    public int Id { get => id; set => id = value; }

    [Required(ErrorMessage = "El número de caso es obligatorio")]
    [Display(Name = "Número de caso")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }

    [Required(ErrorMessage = "El nombre del caso es obligatorio")]
    [Display(Name = "Nombre del caso")]
    public string NombreCaso { get => nombreCaso; set => nombreCaso = value; }

    [Required(ErrorMessage = "Debe seleccionar un tipo de delito")]
    [Display(Name = "Tipo de delito")]
    public string TipoDelito { get => tipoDelito; set => tipoDelito = value; }

    [Required(ErrorMessage = "Debe seleccionar un estado")]
    public string Estado { get => estado; set => estado = value; }

    [Required(ErrorMessage = "La fecha de apertura es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de apertura")]
    public DateTime FechaApertura { get => fechaApertura; set => fechaApertura = value; }

    [Required(ErrorMessage = "La descripción es obligatoria")]
    [Display(Name = "Descripción")]
    public string Descripcion { get => descripcion; set => descripcion = value; }

    [Required(ErrorMessage = "Debe seleccionar un agente")]
    [Display(Name = "Agente asignado")]
    public string NombreAgente { get => nombreAgente; set => nombreAgente = value; }

    [Display(Name = "Prioridad")]
    public string Prioridad { get => prioridad; set => prioridad = value; }
}
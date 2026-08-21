using System.ComponentModel.DataAnnotations;
namespace DepartamentoJusticia.Models;
public class Operativo
{
    private int id;
    private string nombreOperativo;
    private DateTime fechaEjecucion;
    private string ciudad;
    private string tipoOperativo;
    private string nombreAgente1;
    private string nombreAgente2;
    private string nombreAgente3;
    private string resultado;
    private string numeroCaso;
    private double costoOperativo;
    public Operativo(int id, string nombreOperativo, DateTime fechaEjecucion, string ciudad, string tipoOperativo, string nombreAgente1, string nombreAgente2, string nombreAgente3, string resultado, string numeroCaso, double costoOperativo)
    {
        this.Id = id;
        this.NombreOperativo = nombreOperativo;
        this.FechaEjecucion = fechaEjecucion;
        this.Ciudad = ciudad;
        this.TipoOperativo = tipoOperativo;
        this.NombreAgente1 = nombreAgente1;
        this.NombreAgente2 = nombreAgente2;
        this.NombreAgente3 = nombreAgente3;
        this.Resultado = resultado;
        this.NumeroCaso = numeroCaso;
        this.CostoOperativo = costoOperativo;
    }
    public Operativo()
    {
        this.Id = 0;
        this.NombreOperativo = "";
        this.FechaEjecucion = DateTime.Now;
        this.Ciudad = "";
        this.TipoOperativo = "";
        this.NombreAgente1 = "";
        this.NombreAgente2 = "";
        this.NombreAgente3 = "";
        this.Resultado = "";
        this.NumeroCaso = "";
        this.CostoOperativo = 0;
    }
    
    public double CalcularCostoOperativo(double salario1, double salario2, double salario3)
    {
        
        double total = salario1 + salario2 + salario3;
        switch (TipoOperativo)
        {
            case "Intervención y Captura":
                total += 40000;
                break;
            case "Inteligencia y Vigilancia":
                total += 50000;
                break;
            case "Contención y Disuasión":
                total += 30000;
                break;
            case "Especiales y de Emergencia":
                total += 55000;
                break;
        }
        return total;
    }
    [Required]
    public int Id { get => id; set => id = value; }

    [Required(ErrorMessage = "El nombre del operativo es obligatorio")]
    [Display(Name = "Nombre del operativo")]
    public string NombreOperativo { get => nombreOperativo; set => nombreOperativo = value; }

    [Required(ErrorMessage = "La fecha de ejecución es obligatoria")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de ejecución")]
    public DateTime FechaEjecucion { get => fechaEjecucion; set => fechaEjecucion = value; }

    [Required(ErrorMessage = "La ciudad es obligatoria")]
    public string Ciudad { get => ciudad; set => ciudad = value; }

    [Required(ErrorMessage = "Debe seleccionar un tipo de operativo")]
    [Display(Name = "Tipo de operativo")]
    public string TipoOperativo { get => tipoOperativo; set => tipoOperativo = value; }

    [Required(ErrorMessage = "Debe seleccionar el primer agente")]
    [Display(Name = "Agente 1")]
    public string NombreAgente1 { get => nombreAgente1; set => nombreAgente1 = value; }

    [Required(ErrorMessage = "Debe seleccionar el segundo agente")]
    [Display(Name = "Agente 2")]
    public string NombreAgente2 { get => nombreAgente2; set => nombreAgente2 = value; }

    [Required(ErrorMessage = "Debe seleccionar el tercer agente")]
    [Display(Name = "Agente 3")]
    public string NombreAgente3 { get => nombreAgente3; set => nombreAgente3 = value; }

    [Required(ErrorMessage = "Debe seleccionar un resultado")]
    public string Resultado { get => resultado; set => resultado = value; }

    [Required(ErrorMessage = "Debe seleccionar un caso judicial")]
    [Display(Name = "Caso judicial")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }

    [Display(Name = "Costo del operativo")]
    public double CostoOperativo { get => costoOperativo; set => costoOperativo = value; }
}
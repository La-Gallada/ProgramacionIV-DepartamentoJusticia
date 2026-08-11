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
    public Operativo(int id, string nombreOperativo, DateTime fechaEjecucion, string ciudad, string tipoOperativo, string nombreAgente1, string nombreAgente2, string nombreAgente3, string resultado, string numeroCaso)
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
    }
    public Operativo()
    {
        this.Id = 0;
        this.NombreOperativo = "";
        this.FechaEjecucion = DateTime.MinValue;
        this.Ciudad = "";
        this.TipoOperativo = "";
        this.NombreAgente1 = "";
        this.NombreAgente2 = "";
        this.NombreAgente3 = "";
        this.Resultado = "";
        this.NumeroCaso = "";
    }

    [Required]
    public int Id { get => id; set => id = value; }
    public string NombreOperativo { get => nombreOperativo; set => nombreOperativo = value; }
    public DateTime FechaEjecucion { get => fechaEjecucion; set => fechaEjecucion = value; }
    public string Ciudad { get => ciudad; set => ciudad = value; }
    public string TipoOperativo { get => tipoOperativo; set => tipoOperativo = value; }
    public string NombreAgente1 { get => nombreAgente1; set => nombreAgente1 = value; }
    public string NombreAgente2 { get => nombreAgente2; set => nombreAgente2 = value; }
    public string NombreAgente3 { get => nombreAgente3; set => nombreAgente3 = value; }
    public string Resultado { get => resultado; set => resultado = value; }
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }
}

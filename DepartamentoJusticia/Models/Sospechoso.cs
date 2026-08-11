using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Sospechoso
{
    private int id;
    private string identificacion;
    private string nombreCompleto;
    private string nacionalidad;
    private DateTime fechaNacimiento;
    private int nivelPeligrosidad;
    private string estadoLegal;
    private string numeroCaso;

    public Sospechoso(int id, string identificacion, string nombreCompleto, string nacionalidad, DateTime fechaNacimiento, int nivelPeligrosidad, string estadoLegal, string numeroCaso)
    {
        this.Id = id;
        this.Identificacion = identificacion;
        this.NombreCompleto = nombreCompleto;
        this.Nacionalidad = nacionalidad;
        this.FechaNacimiento = fechaNacimiento;
        this.NivelPeligrosidad = nivelPeligrosidad;
        this.EstadoLegal = estadoLegal;
        this.NumeroCaso = numeroCaso;
    }
    public Sospechoso()
    {
        this.Id = 0;
        this.Identificacion = "";
        this.NombreCompleto = "";
        this.Nacionalidad = "";
        this.FechaNacimiento = DateTime.MinValue;
        this.NivelPeligrosidad = 0;
        this.EstadoLegal = "";
        this.NumeroCaso = "";
    }

    [Required]
    public int Id { get => id; set => id = value; }
    public string Identificacion { get => identificacion; set => identificacion = value; }
    public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }
    public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }
    public int NivelPeligrosidad { get => nivelPeligrosidad; set => nivelPeligrosidad = value; }
    public string EstadoLegal { get => estadoLegal; set => estadoLegal = value; }
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }
}

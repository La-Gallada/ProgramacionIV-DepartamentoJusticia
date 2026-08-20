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
    private string nivelRiesgo;

    public Sospechoso(int id, string identificacion, string nombreCompleto, string nacionalidad, DateTime fechaNacimiento, int nivelPeligrosidad, string estadoLegal, string numeroCaso, string nivelRiesgo)
    {
        this.Id = id;
        this.Identificacion = identificacion;
        this.NombreCompleto = nombreCompleto;
        this.Nacionalidad = nacionalidad;
        this.FechaNacimiento = fechaNacimiento;
        this.NivelPeligrosidad = nivelPeligrosidad;
        this.EstadoLegal = estadoLegal;
        this.NumeroCaso = numeroCaso;
        this.NivelRiesgo = nivelRiesgo;
    }

    public Sospechoso()
    {
        this.Id = 0;
        this.Identificacion = "";
        this.NombreCompleto = "";
        this.Nacionalidad = "";
        this.FechaNacimiento = DateTime.Now;
        this.NivelPeligrosidad = 0;
        this.EstadoLegal = "";
        this.NumeroCaso = "";
        this.NivelRiesgo = "";
    }

    [Required]
    public int Id { get => id; set => id = value; }

    [Required(ErrorMessage = "La identificación es obligatoria.")]
    [Display(Name = "Identificación")]
    public string Identificacion { get => identificacion; set => identificacion = value; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

    [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
    [Display(Name = "Nacionalidad")]
    public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    [Display(Name = "Fecha de nacimiento")]
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

    [Range(1, 100, ErrorMessage = "El nivel de peligrosidad debe estar entre 1 y 100.")]
    [Display(Name = "Nivel de peligrosidad")]
    public int NivelPeligrosidad { get => nivelPeligrosidad; set => nivelPeligrosidad = value; }

    [Required(ErrorMessage = "El estado legal es obligatorio.")]
    [Display(Name = "Estado legal")]
    public string EstadoLegal { get => estadoLegal; set => estadoLegal = value; }

    [Required(ErrorMessage = "El caso judicial es obligatorio.")]
    [Display(Name = "Caso judicial vinculado")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }

    [Display(Name = "Nivel de riesgo")]
    public string NivelRiesgo { get => nivelRiesgo; set => nivelRiesgo = value; }

    public string CalcularNivelRiesgo()
    {
        
        if (NivelPeligrosidad >= 1 && NivelPeligrosidad <= 25)
        {
            return "Riesgo Bajo";
        }
        else if (NivelPeligrosidad >= 26 && NivelPeligrosidad <= 50)
        {
            return "Riesgo Moderado";
        }
        else if (NivelPeligrosidad >= 51 && NivelPeligrosidad <= 75)
        {
            return "Riesgo Alto";
        }
        else if (NivelPeligrosidad >= 76 && NivelPeligrosidad <= 100)
        {
            return "Riesgo Crítico";
        }
        else
        {
            return "No calculado";
        }
    }
}
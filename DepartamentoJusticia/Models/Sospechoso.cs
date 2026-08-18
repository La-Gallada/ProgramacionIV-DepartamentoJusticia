using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

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

    public int Id { get => id; set => id = value; }

    [Display(Name = "Identificacion")]
    public string Identificacion { get => identificacion; set => identificacion = value; }

    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

    [Display(Name = "Nacionalidad")]
    public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }

    [DataType(DataType.Date)]
    [CustomValidation(typeof(Sospechoso), nameof(FechaNacimientoValida))]
    [Display(Name = "Fecha de nacimiento")]
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

    [Range(1, 100, ErrorMessage = "El nivel de peligrosidad debe estar entre 1 y 100.")]
    [Display(Name = "Nivel de peligrosidad")]
    public int NivelPeligrosidad { get => nivelPeligrosidad; set => nivelPeligrosidad = value; }

    [Display(Name = "Estado legal")]
    public string EstadoLegal { get => estadoLegal; set => estadoLegal = value; }

    [Display(Name = "Caso judicial vinculado")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }

    public static ValidationResult? FechaNacimientoValida(DateTime fechaNacimiento, ValidationContext contexto)
    {
        if (fechaNacimiento == DateTime.MinValue || fechaNacimiento.Date > DateTime.Today)
        {
            return new ValidationResult("La fecha de nacimiento debe ser anterior o igual a hoy.");
        }

        return ValidationResult.Success;
    }

    [NotMapped]
    [Display(Name = "Nivel de riesgo")]
    public string NivelRiesgo
    {
        get
        {
            if (NivelPeligrosidad >= 76)
            {
                return "Riesgo Critico";
            }

            if (NivelPeligrosidad >= 51)
            {
                return "Riesgo Alto";
            }

            if (NivelPeligrosidad >= 26)
            {
                return "Riesgo Moderado";
            }

            return NivelPeligrosidad >= 1 ? "Riesgo Bajo" : "No calculado";
        }
    }

    [NotMapped]
    [Display(Name = "Edad")]
    public int Edad
    {
        get
        {
            if (FechaNacimiento == DateTime.MinValue)
            {
                return 0;
            }

            int edad = DateTime.Today.Year - FechaNacimiento.Year;

            if (FechaNacimiento.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }
    }
}

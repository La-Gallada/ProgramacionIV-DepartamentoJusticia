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

    [Required]
    public int Id { get => id; set => id = value; }

    [Required(ErrorMessage = "La identificacion es obligatoria.")]
    [StringLength(30, ErrorMessage = "La identificacion no puede superar los 30 caracteres.")]
    [Display(Name = "Identificacion")]
    public string Identificacion { get => identificacion; set => identificacion = value; }

    [Required(ErrorMessage = "El nombre completo es obligatorio.")]
    [StringLength(120, ErrorMessage = "El nombre no puede superar los 120 caracteres.")]
    [Display(Name = "Nombre completo")]
    public string NombreCompleto { get => nombreCompleto; set => nombreCompleto = value; }

    [Required(ErrorMessage = "La nacionalidad es obligatoria.")]
    [StringLength(60)]
    [Display(Name = "Nacionalidad")]
    public string Nacionalidad { get => nacionalidad; set => nacionalidad = value; }

    [Required(ErrorMessage = "La fecha de nacimiento es obligatoria.")]
    [DataType(DataType.Date)]
    [CustomValidation(typeof(Sospechoso), nameof(FechaNacimientoValida))]
    [Display(Name = "Fecha de nacimiento")]
    public DateTime FechaNacimiento { get => fechaNacimiento; set => fechaNacimiento = value; }

    [Required(ErrorMessage = "El nivel de peligrosidad es obligatorio.")]
    [Range(1, 100, ErrorMessage = "El nivel de peligrosidad debe estar entre 1 y 100.")]
    [Display(Name = "Nivel de peligrosidad")]
    public int NivelPeligrosidad { get => nivelPeligrosidad; set => nivelPeligrosidad = value; }

    [Required(ErrorMessage = "Debe seleccionar el estado legal.")]
    [StringLength(30)]
    [Display(Name = "Estado legal")]
    public string EstadoLegal { get => estadoLegal; set => estadoLegal = value; }

    [Required(ErrorMessage = "Debe seleccionar el caso judicial vinculado.")]
    [StringLength(30)]
    [Display(Name = "Caso judicial vinculado")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }

    #region Calculos de la clase logica

    public static ValidationResult? FechaNacimientoValida(DateTime fechaNacimiento, ValidationContext contexto)
    {
        if (fechaNacimiento == DateTime.MinValue || fechaNacimiento.Date > DateTime.Today)
        {
            return new ValidationResult("La fecha de nacimiento debe ser anterior o igual a hoy.");
        }

        return ValidationResult.Success;
    }

    
    /// Nivel de riesgo calculado a partir del nivel de peligrosidad.
    /// Riesgo Bajo: 1 a 25 | Moderado: 26 a 50 | Alto: 51 a 75 | Critico: 76 a 100.
    /// No se almacena en la base de datos, se calcula cada vez que se consulta.
    
    [NotMapped]
    [Display(Name = "Nivel de riesgo")]
    public string NivelRiesgo
    {
        get
        {
            if (this.NivelPeligrosidad >= 76)
            {
                return "Riesgo Critico";
            }

            if (this.NivelPeligrosidad >= 51)
            {
                return "Riesgo Alto";
            }

            if (this.NivelPeligrosidad >= 26)
            {
                return "Riesgo Moderado";
            }

            return this.NivelPeligrosidad >= 1 ? "Riesgo Bajo" : "No calculado";
        }
    }

   
    /// Edad calculada a partir de la fecha de nacimiento.
  
    [NotMapped]
    [Display(Name = "Edad")]
    public int Edad
    {
        get
        {
            if (this.FechaNacimiento == DateTime.MinValue)
            {
                return 0;
            }

            int edad = DateTime.Today.Year - this.FechaNacimiento.Year;

            if (this.FechaNacimiento.Date > DateTime.Today.AddYears(-edad))
            {
                edad--;
            }

            return edad;
        }
    }

    //e

    #endregion
}

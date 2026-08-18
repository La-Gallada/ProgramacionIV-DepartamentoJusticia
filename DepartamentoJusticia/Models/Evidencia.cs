using System.ComponentModel.DataAnnotations;
namespace DepartamentoJusticia.Models;

public class Evidencia
{
    private int id;
    private string codigo;
    private string tipoEvidencia;
    private string descripcion;
    private string lugarHallazgo;
    private DateTime fechaRecoleccion;
    private string numeroCaso;

    public Evidencia(int id, string codigo, string tipoEvidencia, string descripcion, string lugarHallazgo, DateTime fechaRecoleccion, string numeroCaso)
    {
        this.Id = id;
        this.Codigo = codigo;
        this.TipoEvidencia = tipoEvidencia;
        this.Descripcion = descripcion;
        this.LugarHallazgo = lugarHallazgo;
        this.FechaRecoleccion = fechaRecoleccion;
        this.NumeroCaso = numeroCaso;
    }

    public Evidencia()
    {
        this.Id = 0;
        this.Codigo = "";
        this.TipoEvidencia = "";
        this.Descripcion = "";
        this.LugarHallazgo = "";
        this.FechaRecoleccion = DateTime.MinValue;
        this.NumeroCaso = "";
    }



    [Required]
    public int Id { get => id; set => id = value; }
    [Required(ErrorMessage = "El código es obligatorio.")]
    public string Codigo { get => codigo; set => codigo = value; }

    [Required(ErrorMessage = "El tipo de evidencia es obligatorio.")]
    public string TipoEvidencia { get => tipoEvidencia; set => tipoEvidencia = value; }

    [Required(ErrorMessage = "La descripción es obligatoria.")]
    public string Descripcion { get => descripcion; set => descripcion = value; }

    [Required(ErrorMessage = "El lugar de hallazgo es obligatorio.")]
    public string LugarHallazgo { get => lugarHallazgo; set => lugarHallazgo = value; }

    [Required(ErrorMessage = "La fecha de recolección es obligatoria.")]
    public DateTime FechaRecoleccion { get => fechaRecoleccion; set => fechaRecoleccion = value; }

    [Required(ErrorMessage = "El caso judicial es obligatorio.")]
    public string NumeroCaso { get => numeroCaso; set => numeroCaso = value; }
}
   

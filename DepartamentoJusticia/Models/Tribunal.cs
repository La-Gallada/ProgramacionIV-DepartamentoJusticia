using System.ComponentModel.DataAnnotations;

namespace DepartamentoJusticia.Models;

public class Tribunal
{
    private int id;
    private string nombre;
    private string estado;
    private string ciudad;
    private string juezAsignado;
    private int cantidadSalas;


    public Tribunal(int id, string nombre, string estado, string ciudad, string juezAsignado, int cantidadSalas)
    {
        this.Id = id;
        this.Nombre = nombre;
        this.Estado = estado;
        this.Ciudad = ciudad;
        this.JuezAsignado = juezAsignado;
        this.CantidadSalas = cantidadSalas;
    }

    public Tribunal()
    {
        this.Id = 0;
        this.Nombre = "";
        this.Estado = "";
        this.Ciudad = "";
        this.JuezAsignado = "";
        this.CantidadSalas = 0;
    }


    [Required]
    public int Id { get => id; set => id = value; }
    [Required(ErrorMessage = "El nombre es obligatorio.")]
    public string Nombre { get => nombre; set => nombre = value; }

    [Required(ErrorMessage = "El estado es obligatorio.")]
    public string Estado { get => estado; set => estado = value; }

    [Required(ErrorMessage = "La ciudad es obligatoria.")]
    public string Ciudad { get => ciudad; set => ciudad = value; }

    [Required(ErrorMessage = "El juez asignado es obligatorio.")]
    public string JuezAsignado { get => juezAsignado; set => juezAsignado = value; }

    [Required(ErrorMessage = "La cantidad de salas es obligatoria.")]
    public int CantidadSalas { get => cantidadSalas; set => cantidadSalas = value; }
}

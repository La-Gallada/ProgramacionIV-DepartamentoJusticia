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
    public string Nombre { get => nombre; set => nombre = value; }
    public string Estado { get => estado; set => estado = value; }
    public string Ciudad { get => ciudad; set => ciudad = value; }
    public string JuezAsignado { get => juezAsignado; set => juezAsignado = value; }
    public int CantidadSalas { get => cantidadSalas; set => cantidadSalas = value; }
}

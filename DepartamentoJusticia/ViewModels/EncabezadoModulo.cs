namespace DepartamentoJusticia.ViewModels;

/// <summary>
/// Modelo del partial compartido _EncabezadoModulo.
/// Lo usan todos los modulos para tener el mismo encabezado.
/// </summary>
public class EncabezadoModulo
{
    public string Titulo { get; set; } = string.Empty;
    public string Descripcion { get; set; } = string.Empty;
    public string? TextoBoton { get; set; }
    public string Controlador { get; set; } = string.Empty;
    public string Accion { get; set; } = "Crear";
}

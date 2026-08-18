namespace DepartamentoJusticia.ViewModels;

/// <summary>
/// Traduce los estados del sistema a las clases de color definidas en
/// departamento.css. Lo usan todos los modulos para que un mismo estado
/// se vea igual en todas las pantallas.
///
/// Uso en una vista:
///     &lt;span class="dj-etiqueta-estado @Etiquetas.ClaseEstado(item.Estado)"&gt;@item.Estado&lt;/span&gt;
/// </summary>
public static class Etiquetas
{
    /// <summary>Color de la etiqueta segun el nivel de riesgo del sospechoso.</summary>
    public static string ClaseRiesgo(string? nivelRiesgo)
    {
        return (nivelRiesgo ?? "").Trim() switch
        {
            "Riesgo Critico" => "dj-estado-critico",
            "Riesgo Alto" => "dj-estado-peligro",
            "Riesgo Moderado" => "dj-estado-alerta",
            "Riesgo Bajo" => "dj-estado-exito",
            _ => "dj-estado-neutro"
        };
    }

    /// <summary>Color de la etiqueta segun el estado de cualquier modulo.</summary>
    public static string ClaseEstado(string? estado)
    {
        return (estado ?? "").Trim() switch
        {
            // Positivos / concluidos
            "Activo" or "Efectivo" or "Exitoso" or "Celebrada" or "Finalizado" or "Sin Cargos" => "dj-estado-exito",

            // En curso / advertencia
            "En proceso" or "En Desarrollo" or "Programada" or "Vacaciones" or "Investigado" or "Ingresado" => "dj-estado-alerta",

            // Negativos
            "Inactivo" or "Fallido" or "No efectivo" or "Suspendido" or "Suspendida" or "Detenido" or "Procesado" => "dj-estado-peligro",

            // Graves
            "Sentenciado" => "dj-estado-critico",

            _ => "dj-estado-neutro"
        };
    }
}

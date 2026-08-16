using DepartamentoJusticia.Models;
using System.Data.Entity;

namespace DepartamentoJusticia.Services;

public class Service : DbContext
{
    public Service() : base("DepartamentoJusticia")
    {
    }

    public DbSet<Agente> Agentes { get; set; }
    public DbSet<CasoJudicial> casosJudiciales { get; set; }
    public DbSet<Sospechoso> sospechosos { get; set; }
    public DbSet<Evidencia> evidencias { get; set; }
    public DbSet<Operativo> operativos { get; set; }
    public DbSet<Tribunal> tribunales { get; set; }
    public DbSet<Audiencia> audiencias { get; set; }
    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Bitacora> bitacoras { get; set; }



    #region Agentes Federales

    #endregion

    #region Casos Judiciales

    #endregion

    #region Sospechosos

    /// Devuelve todos los sospechosos ordenados por nombre
    public List<Sospechoso> ObtenerSospechosos()
    {
        return this.sospechosos
                   .OrderBy(s => s.NombreCompleto)
                   .ToList();
    }

    /// Devuelve un sospechoso por su identificador. Null si no existe.
    public Sospechoso? ObtenerSospechoso(int id)
    {
        return this.sospechosos.FirstOrDefault(s => s.Id == id);
    }

   
    /// Busqueda por multiples criterios: nombre, estado legal y rango de nivel
    /// de peligrosidad. Los criterios son combinables; los que vengan vacios
    /// simplemente no se aplican.
    
    public List<Sospechoso> BuscarSospechosos(string? nombre, string? estadoLegal, int? peligrosidadMinima, int? peligrosidadMaxima)
    {
        IQueryable<Sospechoso> consulta = this.sospechosos;

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            string texto = nombre.Trim();
            consulta = consulta.Where(s => s.NombreCompleto.Contains(texto));
        }

        if (!string.IsNullOrWhiteSpace(estadoLegal))
        {
            string estado = estadoLegal.Trim();
            consulta = consulta.Where(s => s.EstadoLegal == estado);
        }

        if (peligrosidadMinima.HasValue)
        {
            int minimo = peligrosidadMinima.Value;
            consulta = consulta.Where(s => s.NivelPeligrosidad >= minimo);
        }

        if (peligrosidadMaxima.HasValue)
        {
            int maximo = peligrosidadMaxima.Value;
            consulta = consulta.Where(s => s.NivelPeligrosidad <= maximo);
        }

        return consulta.OrderByDescending(s => s.NivelPeligrosidad)
                       .ThenBy(s => s.NombreCompleto)
                       .ToList();
    }

    /// Indica si ya existe otro sospechoso con la misma identificacion.
    public bool ExisteIdentificacionSospechoso(string identificacion, int idExcluir = 0)
    {
        if (string.IsNullOrWhiteSpace(identificacion))
        {
            return false;
        }

        string valor = identificacion.Trim();

        return this.sospechosos.Any(s => s.Identificacion == valor && s.Id != idExcluir);
    }

    /// <>Registra un nuevo sospechoso.
    public bool AgregarSospechoso(Sospechoso sospechoso)
    {
        try
        {
            this.sospechosos.Add(sospechoso);
            this.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// Actualiza los datos de un sospechoso existente.
    public bool ActualizarSospechoso(Sospechoso sospechoso)
    {
        try
        {
            Sospechoso? registrado = this.sospechosos.FirstOrDefault(s => s.Id == sospechoso.Id);

            if (registrado == null)
            {
                return false;
            }

            registrado.Identificacion = sospechoso.Identificacion;
            registrado.NombreCompleto = sospechoso.NombreCompleto;
            registrado.Nacionalidad = sospechoso.Nacionalidad;
            registrado.FechaNacimiento = sospechoso.FechaNacimiento;
            registrado.NivelPeligrosidad = sospechoso.NivelPeligrosidad;
            registrado.EstadoLegal = sospechoso.EstadoLegal;
            registrado.NumeroCaso = sospechoso.NumeroCaso;

            this.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    /// Elimina un sospechoso por su identificador.
    public bool EliminarSospechoso(int id)
    {
        try
        {
            Sospechoso? registrado = this.sospechosos.FirstOrDefault(s => s.Id == id);

            if (registrado == null)
            {
                return false;
            }

            this.sospechosos.Remove(registrado);
            this.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    
    /// Numeros de caso para alimentar el combo de la pantalla de sospechosos.
    /// El enunciado pide que el caso vinculado se traiga de la base de datos.
   
    public List<string> ObtenerNumerosDeCaso()
    {
        return this.casosJudiciales
                   .OrderBy(c => c.NumeroCaso)
                   .Select(c => c.NumeroCaso)
                   .ToList();
    }

    #endregion

    #region Evidencias

    #endregion

    #region Operativos

    #endregion

    #region Tribunales

    /// Nombres de tribunales para los combos de las audiencias
    public List<string> ObtenerNombresDeTribunal()
    {
        return this.tribunales
                   .OrderBy(t => t.Nombre)
                   .Select(t => t.Nombre)
                   .ToList();
    }

    #endregion

    #region Audiencias

    public List<Audiencia> ObtenerAudiencias()
    {
        return this.audiencias
                   .OrderByDescending(a => a.Fecha)
                   .ThenByDescending(a => a.Hora)
                   .ToList();
    }

    public Audiencia? ObtenerAudiencia(int id)
    {
        return this.audiencias.FirstOrDefault(a => a.Id == id);
    }

    /// Busqueda combinable por tribunal, tipo de audiencia y estado.
    public List<Audiencia> BuscarAudiencias(string? nombreTribunal, string? tipoAudiencia, string? estado)
    {
        IQueryable<Audiencia> consulta = this.audiencias;

        if (!string.IsNullOrWhiteSpace(nombreTribunal))
        {
            consulta = consulta.Where(a => a.NombreTribunal == nombreTribunal.Trim());
        }

        if (!string.IsNullOrWhiteSpace(tipoAudiencia))
        {
            consulta = consulta.Where(a => a.TipoAudiencia == tipoAudiencia.Trim());
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            consulta = consulta.Where(a => a.Estado == estado.Trim());
        }

        return consulta.OrderByDescending(a => a.Fecha)
                       .ThenByDescending(a => a.Hora)
                       .ToList();
    }

    public bool AgregarAudiencia(Audiencia audiencia)
    {
        try
        {
            this.audiencias.Add(audiencia);
            this.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool ActualizarAudiencia(Audiencia audiencia)
    {
        try
        {
            Audiencia? registrada = this.audiencias.FirstOrDefault(a => a.Id == audiencia.Id);

            if (registrada == null)
            {
                return false;
            }

            registrada.Fecha = audiencia.Fecha;
            registrada.Hora = audiencia.Hora;
            registrada.TipoAudiencia = audiencia.TipoAudiencia;
            registrada.NombreTribunal = audiencia.NombreTribunal;
            registrada.NumeroCaso = audiencia.NumeroCaso;
            registrada.Observaciones = audiencia.Observaciones;
            registrada.Estado = audiencia.Estado;

            this.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    public bool EliminarAudiencia(int id)
    {
        try
        {
            Audiencia? registrada = this.audiencias.FirstOrDefault(a => a.Id == id);

            if (registrada == null)
            {
                return false;
            }

            this.audiencias.Remove(registrada);
            this.SaveChanges();
            return true;
        }
        catch
        {
            return false;
        }
    }

    #endregion

    #region Usuarios

    #endregion

    #region Bitácora

    #endregion
}

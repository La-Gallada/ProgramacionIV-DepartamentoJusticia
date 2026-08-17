using DepartamentoJusticia.Models;
using System.Data.Entity;
using System.Linq;

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

    #region Agentes Federales CRUD

    public void agregarAgente(Agente agentito)
    {
        Agentes.Add(agentito);
        SaveChanges();
    }

    public List<Agente> mostrarAgentes()
    {
        return Agentes.ToList();
    }

    public List<Agente> mostrarAgentesActivos()
    {
        return Agentes
            .Where(a => a.Estado == "Activo")
            .ToList();
    }

    public Agente buscarAgente(int id)
    {
        var agenteBuscado = Agentes.FirstOrDefault(a => a.Id == id);

        if (agenteBuscado != null)
        {
            return agenteBuscado;
        }

        throw new Exception("Este agente no se encuentra registrado");
    }

    public Agente buscarAgentePorNombre(string nombreCompleto)
    {
        var agenteBuscado = Agentes
            .FirstOrDefault(a => a.NombreCompleto == nombreCompleto);

        if (agenteBuscado != null)
        {
            return agenteBuscado;
        }

        throw new Exception("Este agente no se encuentra registrado");
    }

    public bool existeAgentePorNombre(string nombreCompleto)
    {
        return Agentes.Any(a =>
            a.NombreCompleto == nombreCompleto &&
            a.Estado == "Activo");
    }

    public void eliminarAgente(Agente agentito)
    {
        Agentes.Remove(agentito);
        SaveChanges();
    }

    public void actualizarAgente(Agente agentito)
    {
        var agenteAntiguo = Agentes
            .FirstOrDefault(a => a.Id == agentito.Id);

        if (agenteAntiguo != null)
        {
            agenteAntiguo.NumeroPlaca = agentito.NumeroPlaca;
            agenteAntiguo.NombreCompleto = agentito.NombreCompleto;
            agenteAntiguo.Especialidad = agentito.Especialidad;
            agenteAntiguo.Rango = agentito.Rango;
            agenteAntiguo.FechaIngreso = agentito.FechaIngreso;
            agenteAntiguo.AniosExperiencia = agentito.AniosExperiencia;
            agenteAntiguo.SalarioBase = agentito.SalarioBase;
            agenteAntiguo.Estado = agentito.Estado;
            agenteAntiguo.SalarioTotal = agentito.SalarioTotal;

            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar el agente");
        }
    }

    public List<Agente> buscarAgentesPorNombre(string nombreCompleto)
    {
        return Agentes
            .Where(a => a.NombreCompleto == nombreCompleto)
            .ToList();
    }

    public List<Agente> buscarAgentesPorEspecialidad(string especialidad)
    {
        return Agentes
            .Where(a => a.Especialidad == especialidad)
            .ToList();
    }

    public List<Agente> buscarAgentesPorRango(string rango)
    {
        return Agentes
            .Where(a => a.Rango == rango)
            .ToList();
    }

    #endregion

    #region Casos Judiciales CRUD

    public void agregarCaso(CasoJudicial casito)
    {
        casosJudiciales.Add(casito);
        SaveChanges();
    }

    public List<CasoJudicial> mostrarCasos()
    {
        return casosJudiciales.ToList();
    }

    public List<CasoJudicial> mostrarCasoJudicial()
    {
        return mostrarCasos();
    }

    public CasoJudicial buscarCaso(int id)
    {
        var casoBuscado = casosJudiciales
            .FirstOrDefault(c => c.Id == id);

        if (casoBuscado != null)
        {
            return casoBuscado;
        }

        throw new Exception(
            "Este caso judicial no se encuentra registrado");
    }

    public void eliminarCaso(CasoJudicial casito)
    {
        casosJudiciales.Remove(casito);
        SaveChanges();
    }

    public void actualizarCaso(CasoJudicial casito)
    {
        var casoAntiguo = casosJudiciales
            .FirstOrDefault(c => c.Id == casito.Id);

        if (casoAntiguo != null)
        {
            casoAntiguo.NumeroCaso = casito.NumeroCaso;
            casoAntiguo.NombreCaso = casito.NombreCaso;
            casoAntiguo.TipoDelito = casito.TipoDelito;
            casoAntiguo.Estado = casito.Estado;
            casoAntiguo.FechaApertura = casito.FechaApertura;
            casoAntiguo.Descripcion = casito.Descripcion;
            casoAntiguo.NombreAgente = casito.NombreAgente;
            casoAntiguo.Prioridad = casito.Prioridad;

            SaveChanges();
        }
        else
        {
            throw new Exception(
                "No se pudo actualizar el caso judicial");
        }
    }

    public List<CasoJudicial> buscarCasosPorNumero(string numeroCaso)
    {
        return casosJudiciales
            .Where(c => c.NumeroCaso == numeroCaso)
            .ToList();
    }

    public List<CasoJudicial> buscarCasosPorTipoDelito(string tipoDelito)
    {
        return casosJudiciales
            .Where(c => c.TipoDelito == tipoDelito)
            .ToList();
    }

    public List<CasoJudicial> buscarCasosPorPrioridad(string prioridad)
    {
        return casosJudiciales
            .Where(c => c.Prioridad == prioridad)
            .ToList();
    }

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

    public void agregarEvidencia(Evidencia evidencita)
    {
        evidencias.Add(evidencita);
        SaveChanges();
    }

    public List<Evidencia> mostrarEvidencias()
    {
        return evidencias.ToList();
    }

    public List<Evidencia> buscarEvidencias(
        string codigo,
        string tipoEvidencia,
        DateTime? fechaRecoleccion)
    {
        IQueryable<Evidencia> consulta = evidencias;

        if (!string.IsNullOrWhiteSpace(codigo))
        {
            consulta = consulta
                .Where(e => e.Codigo.Contains(codigo));
        }

        if (!string.IsNullOrWhiteSpace(tipoEvidencia))
        {
            consulta = consulta
                .Where(e => e.TipoEvidencia == tipoEvidencia);
        }

        if (fechaRecoleccion.HasValue)
        {
            DateTime fechaBuscar =
                fechaRecoleccion.Value.Date;

            consulta = consulta.Where(
                e => DbFunctions.TruncateTime(
                    e.FechaRecoleccion) == fechaBuscar);
        }

        return consulta.ToList();
    }

    public Evidencia buscarEvidencia(int id)
    {
        var evidenciaBuscada = evidencias
            .FirstOrDefault(v => v.Id == id);

        if (evidenciaBuscada != null)
        {
            return evidenciaBuscada;
        }

        throw new Exception(
            "No se encuentra esa evidencia");
    }

    public void eliminarEvidencia(Evidencia evidencita)
    {
        evidencias.Remove(evidencita);
        SaveChanges();
    }

    public void actualizarEvidencia(Evidencia evidencita)
    {
        var evidenciaAntigua = evidencias
            .FirstOrDefault(v => v.Id == evidencita.Id);

        if (evidenciaAntigua != null)
        {
            evidenciaAntigua.Codigo =
                evidencita.Codigo;

            evidenciaAntigua.TipoEvidencia =
                evidencita.TipoEvidencia;

            evidenciaAntigua.Descripcion =
                evidencita.Descripcion;

            evidenciaAntigua.LugarHallazgo =
                evidencita.LugarHallazgo;

            evidenciaAntigua.FechaRecoleccion =
                evidencita.FechaRecoleccion;

            evidenciaAntigua.NumeroCaso =
                evidencita.NumeroCaso;

            SaveChanges();
        }
        else
        {
            throw new Exception(
                "No se pudo actualizar la evidencia");
        }
    }

    #endregion

    #region Operativos CRUD

    public void agregarOperativo(Operativo operativito)
    {
        operativos.Add(operativito);
        SaveChanges();
    }

    public List<Operativo> mostrarOperativos()
    {
        return operativos.ToList();
    }

    public Operativo buscarOperativo(int id)
    {
        var operativoBuscado = operativos
            .FirstOrDefault(o => o.Id == id);

        if (operativoBuscado != null)
        {
            return operativoBuscado;
        }

        throw new Exception(
            "Este operativo no se encuentra registrado");
    }

    public void eliminarOperativo(Operativo operativito)
    {
        operativos.Remove(operativito);
        SaveChanges();
    }

    public void actualizarOperativo(Operativo operativito)
    {
        var operativoAntiguo = operativos
            .FirstOrDefault(o => o.Id == operativito.Id);

        if (operativoAntiguo != null)
        {
            operativoAntiguo.NombreOperativo =
                operativito.NombreOperativo;

            operativoAntiguo.FechaEjecucion =
                operativito.FechaEjecucion;

            operativoAntiguo.Ciudad =
                operativito.Ciudad;

            operativoAntiguo.TipoOperativo =
                operativito.TipoOperativo;

            operativoAntiguo.NombreAgente1 =
                operativito.NombreAgente1;

            operativoAntiguo.NombreAgente2 =
                operativito.NombreAgente2;

            operativoAntiguo.NombreAgente3 =
                operativito.NombreAgente3;

            operativoAntiguo.Resultado =
                operativito.Resultado;

            operativoAntiguo.NumeroCaso =
                operativito.NumeroCaso;

            operativoAntiguo.CostoOperativo =
                operativito.CostoOperativo;

            SaveChanges();
        }
        else
        {
            throw new Exception(
                "No se pudo actualizar el operativo");
        }
    }

    public List<Operativo> buscarOperativosPorCiudad(
        string ciudad)
    {
        return operativos
            .Where(o => o.Ciudad == ciudad)
            .ToList();
    }

    public List<Operativo> buscarOperativosPorFecha(
        DateTime fecha)
    {
        return operativos
            .Where(o => o.FechaEjecucion == fecha)
            .ToList();
    }

    public List<Operativo> buscarOperativosPorTipo(
        string tipoOperativo)
    {
        return operativos
            .Where(o => o.TipoOperativo == tipoOperativo)
            .ToList();
    }

    public List<Operativo> buscarOperativosPorResultado(
        string resultado)
    {
        return operativos
            .Where(o => o.Resultado == resultado)
            .ToList();
    }

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

    public void agregarTribunal(Tribunal tribunalito)
    {
        tribunales.Add(tribunalito);
        SaveChanges();
    }

    public List<Tribunal> buscarTribunales(
        string nombre,
        string ciudad,
        string estado,
        string juezAsignado)
    {
        IQueryable<Tribunal> consulta = tribunales;

        if (!string.IsNullOrWhiteSpace(nombre))
        {
            consulta = consulta
                .Where(t => t.Nombre.Contains(nombre));
        }

        if (!string.IsNullOrWhiteSpace(ciudad))
        {
            consulta = consulta
                .Where(t => t.Ciudad.Contains(ciudad));
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            consulta = consulta
                .Where(t => t.Estado == estado);
        }

        if (!string.IsNullOrWhiteSpace(juezAsignado))
        {
            consulta = consulta
                .Where(t => t.JuezAsignado.Contains(juezAsignado));
        }

        return consulta.ToList();
    }

    public Tribunal buscarTribunal(int id)
    {
        var tribunalBuscado = tribunales
            .FirstOrDefault(v => v.Id == id);

        if (tribunalBuscado != null)
        {
            return tribunalBuscado;
        }

        throw new Exception(
            "No se encuentra ese tribunal");
    }

    public void eliminarTribunal(Tribunal tribunalito)
    {
        tribunales.Remove(tribunalito);
        SaveChanges();
    }

    public void actualizarTribunal(Tribunal tribunalito)
    {
        var tribunalAntiguo = tribunales
            .FirstOrDefault(v => v.Id == tribunalito.Id);

        if (tribunalAntiguo != null)
        {
            tribunalAntiguo.Nombre =
                tribunalito.Nombre;

            tribunalAntiguo.Estado =
                tribunalito.Estado;

            tribunalAntiguo.Ciudad =
                tribunalito.Ciudad;

            tribunalAntiguo.JuezAsignado =
                tribunalito.JuezAsignado;

            tribunalAntiguo.CantidadSalas =
                tribunalito.CantidadSalas;

            SaveChanges();
        }
        else
        {
            throw new Exception(
                "No se pudo actualizar el tribunal");
        }

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

    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
        SaveChanges();
    }

    public List<Usuario> ObtenerUsuarios()
    {
        List<Usuario> listaUsuarios =
            usuarios.AsNoTracking().ToList();

        return listaUsuarios;
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        Usuario? usuario = usuarios
            .AsNoTracking()
            .FirstOrDefault(u => u.Id == id);

        return usuario;
    }

    public bool ActualizarUsuario(Usuario usuario)
    {
        Usuario? usuarioActual =
            usuarios.Find(usuario.Id);

        if (usuarioActual == null)
        {
            return false;
        }

        usuarioActual.NombreCompleto =
            usuario.NombreCompleto;

        usuarioActual.Identificacion =
            usuario.Identificacion;

        usuarioActual.Cargo =
            usuario.Cargo;

        usuarioActual.FechaRegistro =
            usuario.FechaRegistro;

        usuarioActual.Estado =
            usuario.Estado;

        usuarioActual.NombreUsuario =
            usuario.NombreUsuario;

        SaveChanges();

        return true;
    }

    public bool EliminarUsuario(int id)
    {
        Usuario? usuario =
            usuarios.Find(id);

        if (usuario == null)
        {
            return false;
        }

        usuarios.Remove(usuario);
        SaveChanges();

        return true;
    }

    public bool NombreUsuarioExiste(
        string nombreUsuario,
        int idExcluir = 0)
    {
        return usuarios.Any(
            u => u.NombreUsuario == nombreUsuario &&
                 u.Id != idExcluir);
    }

    public List<Usuario> BuscarUsuarios(
        string nombreCompleto,
        string identificacion,
        string nombreUsuario,
        string cargo,
        string estado)
    {
        IQueryable<Usuario> consulta =
            usuarios.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombreCompleto))
        {
            consulta = consulta.Where(
                u => u.NombreCompleto.Contains(nombreCompleto));
        }

        if (!string.IsNullOrWhiteSpace(identificacion))
        {
            consulta = consulta.Where(
                u => u.Identificacion.Contains(identificacion));
        }

        if (!string.IsNullOrWhiteSpace(nombreUsuario))
        {
            consulta = consulta.Where(
                u => u.NombreUsuario.Contains(nombreUsuario));
        }

        if (!string.IsNullOrWhiteSpace(cargo))
        {
            consulta = consulta.Where(
                u => u.Cargo == cargo);
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            consulta = consulta.Where(
                u => u.Estado == estado);
        }

        List<Usuario> listaUsuarios =
            consulta.ToList();

        return listaUsuarios;
    }

    public bool ActualizarContrasenia(
        int id,
        string nuevaContrasenia)
    {
        Usuario? usuario =
            usuarios.Find(id);

        if (usuario == null)
        {
            return false;
        }

        usuario.Contrasenia =
            nuevaContrasenia;

        SaveChanges();

        return true;
    }

    public Usuario? ValidarUsuario(
        string nombreUsuario,
        string contrasenia)
    {
        Usuario? usuario = usuarios
            .FirstOrDefault(
                u => u.NombreUsuario == nombreUsuario);

        if (usuario == null)
        {
            return null;
        }

        if (usuario.Contrasenia != contrasenia)
        {
            return null;
        }

        if (usuario.Estado != "Activo")
        {
            return null;
        }

        return usuario;
    }

    #endregion

    #region Bitácora

    public void RegistrarBitacora(
        string nombreUsuario,
        string resultado)
    {
        Bitacora bitacora = new Bitacora();

        bitacora.Fecha =
            DateTime.Now.Date;

        bitacora.Hora =
            DateTime.Now.TimeOfDay;

        bitacora.NombreUsuario =
            nombreUsuario;

        bitacora.Resultado =
            resultado;

        bitacoras.Add(bitacora);

        SaveChanges();
    }

    public List<Bitacora> ObtenerBitacora()
    {
        List<Bitacora> listaBitacora =
            bitacoras.AsNoTracking().ToList();

        return listaBitacora;
    }

    public List<Bitacora> BuscarBitacora(
        string nombreUsuario,
        string resultado,
        DateTime? fecha)
    {
        IQueryable<Bitacora> consulta =
            bitacoras.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombreUsuario))
        {
            consulta = consulta.Where(
                b => b.NombreUsuario.Contains(nombreUsuario));
        }

        if (!string.IsNullOrWhiteSpace(resultado))
        {
            consulta = consulta.Where(
                b => b.Resultado == resultado);
        }

        if (fecha.HasValue)
        {
            DateTime fechaBuscar =
                fecha.Value.Date;

            consulta = consulta.Where(
                b => b.Fecha == fechaBuscar);
        }

        consulta = consulta
            .OrderByDescending(b => b.Fecha)
            .ThenByDescending(b => b.Hora);

        List<Bitacora> listaBitacora =
            consulta.ToList();

        return listaBitacora;
    }

    #endregion
}

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
    public void agregarSospechoso(Sospechoso sospechosito)
    {
        sospechosos.Add(sospechosito);
        SaveChanges();
    }

    public List<Sospechoso> mostrarSospechosos()
    {
        return sospechosos.ToList();
    }

    public Sospechoso buscarSospechoso(int id)
    {
        var sospechosoBuscado = sospechosos
            .FirstOrDefault(s => s.Id == id);

        if (sospechosoBuscado != null)
        {
            return sospechosoBuscado;
        }

        throw new Exception("Este sospechoso no se encuentra registrado");
    }

    public void eliminarSospechoso(Sospechoso sospechosito)
    {
        sospechosos.Remove(sospechosito);
        SaveChanges();
    }

    public void actualizarSospechoso(Sospechoso sospechosito)
    {
        var sospechosoAntiguo = sospechosos
            .FirstOrDefault(s => s.Id == sospechosito.Id);

        if (sospechosoAntiguo != null)
        {
            sospechosoAntiguo.Identificacion = sospechosito.Identificacion;
            sospechosoAntiguo.NombreCompleto = sospechosito.NombreCompleto;
            sospechosoAntiguo.Nacionalidad = sospechosito.Nacionalidad;
            sospechosoAntiguo.FechaNacimiento = sospechosito.FechaNacimiento;
            sospechosoAntiguo.NivelPeligrosidad = sospechosito.NivelPeligrosidad;
            sospechosoAntiguo.EstadoLegal = sospechosito.EstadoLegal;
            sospechosoAntiguo.NumeroCaso = sospechosito.NumeroCaso;
            sospechosoAntiguo.NivelRiesgo = sospechosito.NivelRiesgo;

            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar el sospechoso");
        }
    }

    public List<Sospechoso> buscarSospechososPorNombre(string nombreCompleto)
    {
        return sospechosos
            .Where(s => s.NombreCompleto.Contains(nombreCompleto))
            .ToList();
    }

    public List<Sospechoso> buscarSospechososPorEstadoLegal(string estadoLegal)
    {
        return sospechosos
            .Where(s => s.EstadoLegal == estadoLegal)
            .ToList();
    }
    public List<string> mostrarNumerosDeCaso()
    {
        return casosJudiciales
            .Select(c => c.NumeroCaso)
            .ToList();
    }
    public List<Sospechoso> buscarSospechososPorRiesgo(string nivelRiesgo)
    {
        return sospechosos
            .Where(s => s.NivelRiesgo == nivelRiesgo)
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

    public Evidencia buscarEvidencia(int id)
    {
        var evidenciaBuscada = evidencias
            .FirstOrDefault(v => v.Id == id);

        if (evidenciaBuscada != null)
        {
            return evidenciaBuscada;
        }

        throw new Exception("No se encuentra esa evidencia");
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
            evidenciaAntigua.Codigo = evidencita.Codigo;
            evidenciaAntigua.TipoEvidencia = evidencita.TipoEvidencia;
            evidenciaAntigua.Descripcion = evidencita.Descripcion;
            evidenciaAntigua.LugarHallazgo = evidencita.LugarHallazgo;
            evidenciaAntigua.FechaRecoleccion = evidencita.FechaRecoleccion;
            evidenciaAntigua.NumeroCaso = evidencita.NumeroCaso;

            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar la evidencia");
        }
    }

    public List<Evidencia> buscarEvidenciasPorCodigo(string codigo)
    {
        return evidencias
            .Where(e => e.Codigo.Contains(codigo))
            .ToList();
    }

    public List<Evidencia> buscarEvidenciasPorTipo(string tipoEvidencia)
    {
        return evidencias
            .Where(e => e.TipoEvidencia == tipoEvidencia)
            .ToList();
    }

    public List<Evidencia> buscarEvidenciasPorFecha(DateTime fechaRecoleccion)
    {
        DateTime fechaBuscar = fechaRecoleccion.Date;

        return evidencias
            .Where(e => DbFunctions.TruncateTime(e.FechaRecoleccion) == fechaBuscar)
            .ToList();
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

    public void agregarTribunal(Tribunal tribunalito)
    {
        tribunales.Add(tribunalito);
        SaveChanges();
    }

    public List<Tribunal> mostrarTribunales()
    {
        return tribunales.ToList();
    }

    public Tribunal buscarTribunal(int id)
    {
        var tribunalBuscado = tribunales
            .FirstOrDefault(t => t.Id == id);

        if (tribunalBuscado != null)
        {
            return tribunalBuscado;
        }

        throw new Exception("No se encuentra ese tribunal");
    }

    public void eliminarTribunal(Tribunal tribunalito)
    {
        tribunales.Remove(tribunalito);
        SaveChanges();
    }

    public void actualizarTribunal(Tribunal tribunalito)
    {
        var tribunalAntiguo = tribunales
            .FirstOrDefault(t => t.Id == tribunalito.Id);

        if (tribunalAntiguo != null)
        {
            tribunalAntiguo.Nombre = tribunalito.Nombre;
            tribunalAntiguo.Estado = tribunalito.Estado;
            tribunalAntiguo.Ciudad = tribunalito.Ciudad;
            tribunalAntiguo.JuezAsignado = tribunalito.JuezAsignado;
            tribunalAntiguo.CantidadSalas = tribunalito.CantidadSalas;

            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar el tribunal");
        }
    }

    public List<Tribunal> buscarTribunalesPorNombre(string nombre)
    {
        return tribunales
            .Where(t => t.Nombre.Contains(nombre))
            .ToList();
    }

    public List<Tribunal> buscarTribunalesPorCiudad(string ciudad)
    {
        return tribunales
            .Where(t => t.Ciudad.Contains(ciudad))
            .ToList();
    }

    public List<Tribunal> buscarTribunalesPorEstado(string estado)
    {
        return tribunales
            .Where(t => t.Estado == estado)
            .ToList();
    }

    public List<Tribunal> buscarTribunalesPorJuez(string juezAsignado)
    {
        return tribunales
            .Where(t => t.JuezAsignado.Contains(juezAsignado))
            .ToList();
    }

    public List<string> mostrarNombresDeTribunal()
    {
        return tribunales
            .Select(t => t.Nombre)
            .ToList();
    }

    #endregion

    #region Audiencias
    public void agregarAudiencia(Audiencia audiencita)
    {
        audiencias.Add(audiencita);
        SaveChanges();
    }

    public List<Audiencia> mostrarAudiencias()
    {
        return audiencias.ToList();
    }

    public Audiencia buscarAudiencia(int id)
    {
        var audienciaBuscada = audiencias
            .FirstOrDefault(a => a.Id == id);

        if (audienciaBuscada != null)
        {
            return audienciaBuscada;
        }

        throw new Exception("Esta audiencia no se encuentra registrada");
    }

    public void eliminarAudiencia(Audiencia audiencita)
    {
        audiencias.Remove(audiencita);
        SaveChanges();
    }

    public void actualizarAudiencia(Audiencia audiencita)
    {
        var audienciaAntigua = audiencias
            .FirstOrDefault(a => a.Id == audiencita.Id);

        if (audienciaAntigua != null)
        {
            audienciaAntigua.Fecha = audiencita.Fecha;
            audienciaAntigua.Hora = audiencita.Hora;
            audienciaAntigua.TipoAudiencia = audiencita.TipoAudiencia;
            audienciaAntigua.NombreTribunal = audiencita.NombreTribunal;
            audienciaAntigua.NumeroCaso = audiencita.NumeroCaso;
            audienciaAntigua.Observaciones = audiencita.Observaciones;
            audienciaAntigua.Estado = audiencita.Estado;

            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar la audiencia");
        }
    }

    public List<Audiencia> buscarAudienciasPorTribunal(string nombreTribunal)
    {
        return audiencias
            .Where(a => a.NombreTribunal == nombreTribunal)
            .ToList();
    }

    public List<Audiencia> buscarAudienciasPorTipo(string tipoAudiencia)
    {
        return audiencias
            .Where(a => a.TipoAudiencia == tipoAudiencia)
            .ToList();
    }

    public List<Audiencia> buscarAudienciasPorEstado(string estado)
    {
        return audiencias
            .Where(a => a.Estado == estado)
            .ToList();
    }


    #endregion

    #region Usuarios

    public void agregarUsuario(Usuario usuarito)
    {
        usuarios.Add(usuarito);
        SaveChanges();
    }

    public List<Usuario> mostrarUsuarios()
    {
        return usuarios.ToList();
    }

    public Usuario buscarUsuario(int id)
    {
        var usuarioBuscado = usuarios
            .FirstOrDefault(u => u.Id == id);

        if (usuarioBuscado != null)
        {
            return usuarioBuscado;
        }

        throw new Exception("Este usuario no se encuentra registrado");
    }

    public void eliminarUsuario(Usuario usuarito)
    {
        usuarios.Remove(usuarito);
        SaveChanges();
    }

    public void actualizarUsuario(Usuario usuarito)
    {
        var usuarioAntiguo = usuarios
            .FirstOrDefault(u => u.Id == usuarito.Id);

        if (usuarioAntiguo != null)
        {
            usuarioAntiguo.NombreCompleto = usuarito.NombreCompleto;
            usuarioAntiguo.Identificacion = usuarito.Identificacion;
            usuarioAntiguo.Cargo = usuarito.Cargo;
            usuarioAntiguo.FechaRegistro = usuarito.FechaRegistro;
            usuarioAntiguo.Estado = usuarito.Estado;
            usuarioAntiguo.NombreUsuario = usuarito.NombreUsuario;

            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar el usuario");
        }
    }

    public void actualizarContrasenia(int id, string nuevaContrasenia)
    {
        var usuarioAntiguo = usuarios
            .FirstOrDefault(u => u.Id == id);

        if (usuarioAntiguo != null)
        {
            usuarioAntiguo.Contrasenia = nuevaContrasenia;
            SaveChanges();
        }
        else
        {
            throw new Exception("No se pudo actualizar la contrasenia");
        }
    }

    public bool existeNombreUsuario(string nombreUsuario, int idExcluir = 0)
    {
        return usuarios.Any(u =>
            u.NombreUsuario == nombreUsuario &&
            u.Id != idExcluir);
    }

    public List<Usuario> buscarUsuariosPorNombre(string nombreCompleto)
    {
        return usuarios
            .Where(u => u.NombreCompleto.Contains(nombreCompleto))
            .ToList();
    }

    public List<Usuario> buscarUsuariosPorIdentificacion(string identificacion)
    {
        return usuarios
            .Where(u => u.Identificacion.Contains(identificacion))
            .ToList();
    }

    public List<Usuario> buscarUsuariosPorNombreUsuario(string nombreUsuario)
    {
        return usuarios
            .Where(u => u.NombreUsuario.Contains(nombreUsuario))
            .ToList();
    }

    public List<Usuario> buscarUsuariosPorCargo(string cargo)
    {
        return usuarios
            .Where(u => u.Cargo == cargo)
            .ToList();
    }

    public List<Usuario> buscarUsuariosPorEstado(string estado)
    {
        return usuarios
            .Where(u => u.Estado == estado)
            .ToList();
    }

    public Usuario login(string nombreUsuario, string contrasenia)
    {
        var usuarioLogueado = usuarios
            .FirstOrDefault(u => u.NombreUsuario == nombreUsuario
            && u.Contrasenia == contrasenia
            && u.Estado == "Activo");

        if (usuarioLogueado != null)
        {
            return usuarioLogueado;
        }

        throw new Exception("Datos de inicio de sesion incorrectos");
    }


    #endregion

    #region Bitácora

    public void registrarBitacora(string nombreUsuario, string resultado)
    {
        Bitacora bitacorita = new Bitacora();

        bitacorita.Fecha = DateTime.Now.Date;
        bitacorita.Hora = DateTime.Now.TimeOfDay;
        bitacorita.NombreUsuario = nombreUsuario;
        bitacorita.Resultado = resultado;

        bitacoras.Add(bitacorita);
        SaveChanges();
    }

    public List<Bitacora> mostrarBitacora()
    {
        return bitacoras.ToList();
    }

    public List<Bitacora> buscarBitacoraPorUsuario(string nombreUsuario)
    {
        return bitacoras
            .Where(b => b.NombreUsuario.Contains(nombreUsuario))
            .ToList();
    }

    public List<Bitacora> buscarBitacoraPorResultado(string resultado)
    {
        return bitacoras
            .Where(b => b.Resultado == resultado)
            .ToList();
    }

    public List<Bitacora> buscarBitacoraPorFecha(DateTime fecha)
    {
        DateTime fechaBuscar = fecha.Date;

        return bitacoras
            .Where(b => DbFunctions.TruncateTime(b.Fecha) == fechaBuscar)
            .ToList();
    }

    #endregion
}

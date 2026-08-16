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
        return Agentes.Where(a => a.Estado == "Activo").ToList();
    }


    public Agente buscarAgente(int id)
    {
        var agenteBuscado = Agentes.FirstOrDefault(a => a.Id == id);
        if (agenteBuscado != null)
            return agenteBuscado;
        else throw new Exception("Este agente no se encuentra registrado");
    }
    public Agente buscarAgentePorNombre(string nombreCompleto)
    {
        var agenteBuscado = Agentes.FirstOrDefault(a => a.NombreCompleto == nombreCompleto);
        if (agenteBuscado != null)
            return agenteBuscado;
        else throw new Exception("Este agente no se encuentra registrado");
    }

    public bool existeAgentePorNombre(string nombreCompleto)
    {
        return Agentes.Any(a => a.NombreCompleto == nombreCompleto && a.Estado == "Activo");
    }

    public void eliminarAgente(Agente agentito)
    {
        Agentes.Remove(agentito);
        SaveChanges();
    }

    public void actualizarAgente(Agente agentito)
    {
        var agenteAntiguo = Agentes.FirstOrDefault(a => a.Id == agentito.Id);
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
        else throw new Exception("No se pudo actualizar el agente");

    }

    public List<Agente> buscarAgentesPorNombre(string nombreCompleto)
    {
        return Agentes.Where(a => a.NombreCompleto == nombreCompleto).ToList();
    }

    public List<Agente> buscarAgentesPorEspecialidad(string especialidad)
    {
        return Agentes.Where(a => a.Especialidad == especialidad).ToList();
    }

    public List<Agente> buscarAgentesPorRango(string rango)
    {
        return Agentes.Where(a => a.Rango == rango).ToList();
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
        var casoBuscado = casosJudiciales.FirstOrDefault(c => c.Id == id);
        if (casoBuscado != null)
            return casoBuscado;
        else throw new Exception("Este caso judicial no se encuentra registrado");
    }

    public void eliminarCaso(CasoJudicial casito)
    {
        casosJudiciales.Remove(casito);
        SaveChanges();
    }

    public void actualizarCaso(CasoJudicial casito)
    {
        var casoAntiguo = casosJudiciales.FirstOrDefault(c => c.Id == casito.Id);
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
        else throw new Exception("No se pudo actualizar el caso judicial");
    }

    public List<CasoJudicial> buscarCasosPorNumero(string numeroCaso)
    {
        return casosJudiciales.Where(c => c.NumeroCaso == numeroCaso).ToList();
    }

    public List<CasoJudicial> buscarCasosPorTipoDelito(string tipoDelito)
    {
        return casosJudiciales.Where(c => c.TipoDelito == tipoDelito).ToList();
    }

    public List<CasoJudicial> buscarCasosPorPrioridad(string prioridad)
    {
        return casosJudiciales.Where(c => c.Prioridad == prioridad).ToList();
    }

    #endregion

    #region Sospechosos

    #endregion

    #region Evidencias

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
        var operativoBuscado = operativos.FirstOrDefault(o => o.Id == id);
        if (operativoBuscado != null)
            return operativoBuscado;
        else throw new Exception("Este operativo no se encuentra registrado");
    }

    public void eliminarOperativo(Operativo operativito)
    {
        operativos.Remove(operativito);
        SaveChanges();
    }

    public void actualizarOperativo(Operativo operativito)
    {
        var operativoAntiguo = operativos.FirstOrDefault(o => o.Id == operativito.Id);
        if (operativoAntiguo != null)
        {
            operativoAntiguo.NombreOperativo = operativito.NombreOperativo;
            operativoAntiguo.FechaEjecucion = operativito.FechaEjecucion;
            operativoAntiguo.Ciudad = operativito.Ciudad;
            operativoAntiguo.TipoOperativo = operativito.TipoOperativo;
            operativoAntiguo.NombreAgente1 = operativito.NombreAgente1;
            operativoAntiguo.NombreAgente2 = operativito.NombreAgente2;
            operativoAntiguo.NombreAgente3 = operativito.NombreAgente3;
            operativoAntiguo.Resultado = operativito.Resultado;
            operativoAntiguo.NumeroCaso = operativito.NumeroCaso;
            operativoAntiguo.CostoOperativo = operativito.CostoOperativo;
            SaveChanges();
        }
        else throw new Exception("No se pudo actualizar el operativo");
    }
    public List<Operativo> buscarOperativosPorCiudad(string ciudad)
    {
        return operativos.Where(o => o.Ciudad == ciudad).ToList();
    }

    public List<Operativo> buscarOperativosPorFecha(DateTime fecha)
    {
        return operativos.Where(o => o.FechaEjecucion == fecha).ToList();
    }

    public List<Operativo> buscarOperativosPorTipo(string tipoOperativo)
    {
        return operativos.Where(o => o.TipoOperativo == tipoOperativo).ToList();
    }

    public List<Operativo> buscarOperativosPorResultado(string resultado)
    {
        return operativos.Where(o => o.Resultado == resultado).ToList();
    }

    #endregion

    #region Tribunales

    #endregion

    #region Audiencias

    #endregion

    #region Usuarios

    #endregion

    #region Bitácora

    #endregion
}

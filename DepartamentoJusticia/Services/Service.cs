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

    #region Casos Judiciales CRUD
    public void agregarAgente(Agente agentito)
    { 
        Agentes.Add(agentito);
        SaveChanges();
    }

    public List<Agente> mostrarAgentes()
    { 

    return Agentes.ToList();

    }

    public Agente buscarAgente(int id)
    {
        var agenteBuscado = Agentes.FirstOrDefault(a => a.Id == id);
        if (agenteBuscado != null)
            return agenteBuscado;
        else throw new Exception("Este agente no se encuentra registrado");
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




    #endregion

    #region Sospechosos

    #endregion

    #region Evidencias

    #endregion

    #region Operativos

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
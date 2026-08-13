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
    //holaas


    #region Agentes Federales

    #endregion

    #region Casos Judiciales

    #endregion

    #region Sospechosos

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
        var evidenciaBuscada = evidencias.FirstOrDefault(v => v.Id == id);
        if (evidenciaBuscada != null)
            return evidenciaBuscada;
        else throw new Exception("No se encuentra esa evidencia");
    }

    public void eliminarEvidencia(Evidencia evidencita)
    {
        evidencias.Remove(evidencita);
        SaveChanges();
    }

    public void actualizarEvidencia(Evidencia evidencita)
    {
        var evidenciaAntigua = evidencias.FirstOrDefault(v => v.Id == evidencita.Id);
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
        else throw new Exception("No se pudo actualizar la evidencia");
    }
    #endregion

    #region Operativos

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
        var tribunalBuscado = tribunales.FirstOrDefault(v => v.Id == id);
        if (tribunalBuscado != null)
            return tribunalBuscado;
        else throw new Exception("No se encuentra ese tribunal");
    }

    public void eliminarTribunal(Tribunal tribunalito)
    {
        tribunales.Remove(tribunalito);
        SaveChanges();
    }

    public void actualizarTribunal(Tribunal tribunalito)
    {
        var tribunalAntiguo = tribunalito.FirstOrDefault(v => v.Id == tribunalito.Id);
        if (tribunalAntiguo != null)
        {
            tribunalAntiguo.Nombre = tribunalito.Nombre;
            tribunalAntiguo.Estado = tribunalito.Estado;
            tribunalAntiguo.Ciudad = tribunalito.Ciudad;
            tribunalAntiguo.JuezAsignado = tribunalito.JuezAsignado;
            tribunalAntiguo.CantidadSalas = tribunalito.CantidadSalas;s
            SaveChanges();
        }
        else throw new Exception("No se pudo actualizar el tribunal");
    }
    #endregion

    #region Audiencias

    #endregion

    #region Usuarios

    #endregion

    #region Bitácora

    #endregion
}
using DepartamentoJusticia.Models;
using System.Data.Entity;

namespace DepartamentoJusticia.Services;

public class Service : DbContext
{
    public Service() : base("DepartamentoJusticia")
    {
    }

    public DbSet<Agente> Agentes { get; set; } 

    

    #region Agentes Federales

    #endregion

    #region Casos Judiciales

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
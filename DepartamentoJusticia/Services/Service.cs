using DepartamentoJusticia.Models;
using System.Data.Entity;

namespace DepartamentoJusticia.Services;

public class Service : DbContext
{
    public Service() : base("DepartamentoJusticia")
    {
    }

    public DbSet<Agente> Agentes { get; set; } = null!;
    public DbSet<CasoJudicial> CasosJudiciales { get; set; } = null!;
    public DbSet<Sospechoso> Sospechosos { get; set; } = null!;
    public DbSet<Evidencia> Evidencias { get; set; } = null!;
    public DbSet<Operativo> Operativos { get; set; } = null!;
    public DbSet<Tribunal> Tribunales { get; set; } = null!;
    public DbSet<Audiencia> Audiencias { get; set; } = null!;
    public DbSet<Usuario> Usuarios { get; set; } = null!;
    public DbSet<Bitacora> Bitacoras { get; set; } = null!;

    protected override void OnModelCreating(DbModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        // Nombres exactos de las tablas
        modelBuilder.Entity<Agente>()
            .ToTable("Agentes");

        modelBuilder.Entity<CasoJudicial>()
            .ToTable("CasosJudiciales");

        modelBuilder.Entity<Sospechoso>()
            .ToTable("Sospechosos");

        modelBuilder.Entity<Evidencia>()
            .ToTable("Evidencias");

        modelBuilder.Entity<Operativo>()
            .ToTable("Operativos");

        modelBuilder.Entity<Tribunal>()
            .ToTable("Tribunales");

        modelBuilder.Entity<Audiencia>()
            .ToTable("Audiencias");

        modelBuilder.Entity<Usuario>()
            .ToTable("Usuarios");

        modelBuilder.Entity<Bitacora>()
            .ToTable("Bitacoras");

        // Precisión para valores monetarios
        modelBuilder.Entity<Agente>()
            .Property(agente => agente.SalarioBase)
            .HasPrecision(18, 2);

        // Caso Judicial -> Agente
        modelBuilder.Entity<CasoJudicial>()
            .HasRequired(caso => caso.Agente)
            .WithMany(agente => agente.CasosJudiciales)
            .HasForeignKey(caso => caso.AgenteId)
            .WillCascadeOnDelete(false);

        // Sospechoso -> Caso Judicial
        modelBuilder.Entity<Sospechoso>()
            .HasRequired(sospechoso => sospechoso.CasoJudicial)
            .WithMany(caso => caso.Sospechosos)
            .HasForeignKey(sospechoso => sospechoso.CasoJudicialId)
            .WillCascadeOnDelete(false);

        // Evidencia -> Caso Judicial
        modelBuilder.Entity<Evidencia>()
            .HasRequired(evidencia => evidencia.CasoJudicial)
            .WithMany(caso => caso.Evidencias)
            .HasForeignKey(evidencia => evidencia.CasoJudicialId)
            .WillCascadeOnDelete(false);

        // Operativo -> Caso Judicial
        modelBuilder.Entity<Operativo>()
            .HasRequired(operativo => operativo.CasoJudicial)
            .WithMany(caso => caso.Operativos)
            .HasForeignKey(operativo => operativo.CasoJudicialId)
            .WillCascadeOnDelete(false);

        // Operativo -> Agente 1
        modelBuilder.Entity<Operativo>()
            .HasRequired(operativo => operativo.Agente1)
            .WithMany()
            .HasForeignKey(operativo => operativo.Agente1Id)
            .WillCascadeOnDelete(false);

        // Operativo -> Agente 2
        modelBuilder.Entity<Operativo>()
            .HasRequired(operativo => operativo.Agente2)
            .WithMany()
            .HasForeignKey(operativo => operativo.Agente2Id)
            .WillCascadeOnDelete(false);

        // Operativo -> Agente 3
        modelBuilder.Entity<Operativo>()
            .HasRequired(operativo => operativo.Agente3)
            .WithMany()
            .HasForeignKey(operativo => operativo.Agente3Id)
            .WillCascadeOnDelete(false);

        // Audiencia -> Caso Judicial
        modelBuilder.Entity<Audiencia>()
            .HasRequired(audiencia => audiencia.CasoJudicial)
            .WithMany(caso => caso.Audiencias)
            .HasForeignKey(audiencia => audiencia.CasoJudicialId)
            .WillCascadeOnDelete(false);

        // Audiencia -> Tribunal
        modelBuilder.Entity<Audiencia>()
            .HasRequired(audiencia => audiencia.Tribunal)
            .WithMany(tribunal => tribunal.Audiencias)
            .HasForeignKey(audiencia => audiencia.TribunalId)
            .WillCascadeOnDelete(false);
    }

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
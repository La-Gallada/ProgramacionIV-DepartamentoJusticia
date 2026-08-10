using DepartamentoJusticia.Models;
using Microsoft.EntityFrameworkCore;

namespace DepartamentoJusticia.Data;

public class JusticiaContext : DbContext
{
    public JusticiaContext(DbContextOptions<JusticiaContext> options) : base(options)
    {
    }

    public DbSet<Agente> Agentes { get; set; }
    public DbSet<CasoJudicial> CasosJudiciales { get; set; }
    public DbSet<Sospechoso> Sospechosos { get; set; }
    public DbSet<Evidencia> Evidencias { get; set; }
    public DbSet<Operativo> Operativos { get; set; }
    public DbSet<Tribunal> Tribunales { get; set; }
    public DbSet<Audiencia> Audiencias { get; set; }
    public DbSet<Usuario> Usuarios { get; set; }
    public DbSet<Bitacora> Bitacoras { get; set; }

    protected override void OnModelCreating(ModelBuilder modelBuilder)
    {
        base.OnModelCreating(modelBuilder);

        modelBuilder.Entity<Agente>()
            .Property(agente => agente.SalarioBase)
            .HasColumnType("decimal(18,2)");

        modelBuilder.Entity<CasoJudicial>()
            .HasOne(caso => caso.Agente)
            .WithMany(agente => agente.CasosJudiciales)
            .HasForeignKey(caso => caso.AgenteId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Sospechoso>()
            .HasOne(sospechoso => sospechoso.CasoJudicial)
            .WithMany(caso => caso.Sospechosos)
            .HasForeignKey(sospechoso => sospechoso.CasoJudicialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Evidencia>()
            .HasOne(evidencia => evidencia.CasoJudicial)
            .WithMany(caso => caso.Evidencias)
            .HasForeignKey(evidencia => evidencia.CasoJudicialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Operativo>()
            .HasOne(operativo => operativo.CasoJudicial)
            .WithMany(caso => caso.Operativos)
            .HasForeignKey(operativo => operativo.CasoJudicialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Operativo>()
            .HasOne(operativo => operativo.Agente1)
            .WithMany()
            .HasForeignKey(operativo => operativo.Agente1Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Operativo>()
            .HasOne(operativo => operativo.Agente2)
            .WithMany()
            .HasForeignKey(operativo => operativo.Agente2Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Operativo>()
            .HasOne(operativo => operativo.Agente3)
            .WithMany()
            .HasForeignKey(operativo => operativo.Agente3Id)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Audiencia>()
            .HasOne(audiencia => audiencia.CasoJudicial)
            .WithMany(caso => caso.Audiencias)
            .HasForeignKey(audiencia => audiencia.CasoJudicialId)
            .OnDelete(DeleteBehavior.Restrict);

        modelBuilder.Entity<Audiencia>()
            .HasOne(audiencia => audiencia.Tribunal)
            .WithMany(tribunal => tribunal.Audiencias)
            .HasForeignKey(audiencia => audiencia.TribunalId)
            .OnDelete(DeleteBehavior.Restrict);
    }
}

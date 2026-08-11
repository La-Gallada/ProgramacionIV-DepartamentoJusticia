namespace DepartamentoJusticia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial : DbMigration
    {
        public override void Up()
        {
            CreateTable(
                "dbo.Agentes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroPlaca = c.String(nullable: false),
                        NombreCompleto = c.String(nullable: false),
                        Especialidad = c.String(nullable: false),
                        Rango = c.String(nullable: false),
                        FechaIngreso = c.DateTime(nullable: false),
                        AniosExperiencia = c.Int(nullable: false),
                        SalarioBase = c.Decimal(nullable: false, precision: 18, scale: 2),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.CasoJudicials",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NumeroCaso = c.String(nullable: false),
                        NombreCaso = c.String(nullable: false),
                        TipoDelito = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        FechaApertura = c.DateTime(nullable: false),
                        Descripcion = c.String(nullable: false),
                        AgenteId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agentes", t => t.AgenteId)
                .Index(t => t.AgenteId);
            
            CreateTable(
                "dbo.Audiencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Fecha = c.DateTime(nullable: false),
                        Hora = c.Time(nullable: false, precision: 7),
                        TipoAudiencia = c.String(nullable: false),
                        TribunalId = c.Int(nullable: false),
                        CasoJudicialId = c.Int(nullable: false),
                        Observaciones = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CasoJudicials", t => t.CasoJudicialId)
                .ForeignKey("dbo.Tribunals", t => t.TribunalId)
                .Index(t => t.TribunalId)
                .Index(t => t.CasoJudicialId);
            
            CreateTable(
                "dbo.Tribunals",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Nombre = c.String(nullable: false),
                        Estado = c.String(nullable: false),
                        Ciudad = c.String(nullable: false),
                        JuezAsignado = c.String(nullable: false),
                        CantidadSalas = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Evidencias",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Codigo = c.String(nullable: false),
                        TipoEvidencia = c.String(nullable: false),
                        Descripcion = c.String(nullable: false),
                        LugarHallazgo = c.String(nullable: false),
                        FechaRecoleccion = c.DateTime(nullable: false),
                        CasoJudicialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CasoJudicials", t => t.CasoJudicialId)
                .Index(t => t.CasoJudicialId);
            
            CreateTable(
                "dbo.Operativoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreOperativo = c.String(nullable: false),
                        FechaEjecucion = c.DateTime(nullable: false),
                        Ciudad = c.String(nullable: false),
                        TipoOperativo = c.String(nullable: false),
                        Agente1Id = c.Int(nullable: false),
                        Agente2Id = c.Int(nullable: false),
                        Agente3Id = c.Int(nullable: false),
                        Resultado = c.String(nullable: false),
                        CasoJudicialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.Agentes", t => t.Agente1Id)
                .ForeignKey("dbo.Agentes", t => t.Agente2Id)
                .ForeignKey("dbo.Agentes", t => t.Agente3Id)
                .ForeignKey("dbo.CasoJudicials", t => t.CasoJudicialId)
                .Index(t => t.Agente1Id)
                .Index(t => t.Agente2Id)
                .Index(t => t.Agente3Id)
                .Index(t => t.CasoJudicialId);
            
            CreateTable(
                "dbo.Sospechosoes",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        Identificacion = c.String(nullable: false),
                        NombreCompleto = c.String(nullable: false),
                        Nacionalidad = c.String(nullable: false),
                        FechaNacimiento = c.DateTime(nullable: false),
                        NivelPeligrosidad = c.Int(nullable: false),
                        EstadoLegal = c.String(nullable: false),
                        CasoJudicialId = c.Int(nullable: false),
                    })
                .PrimaryKey(t => t.Id)
                .ForeignKey("dbo.CasoJudicials", t => t.CasoJudicialId)
                .Index(t => t.CasoJudicialId);
            
            CreateTable(
                "dbo.Bitacoras",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        FechaHora = c.DateTime(nullable: false),
                        Usuario = c.String(nullable: false),
                        Resultado = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
            CreateTable(
                "dbo.Usuarios",
                c => new
                    {
                        Id = c.Int(nullable: false, identity: true),
                        NombreCompleto = c.String(nullable: false),
                        Identificacion = c.String(nullable: false),
                        Cargo = c.String(nullable: false),
                        FechaRegistro = c.DateTime(nullable: false),
                        Estado = c.String(nullable: false),
                        NombreUsuario = c.String(nullable: false),
                        Contrasena = c.String(nullable: false),
                    })
                .PrimaryKey(t => t.Id);
            
        }
        
        public override void Down()
        {
            DropForeignKey("dbo.Sospechosoes", "CasoJudicialId", "dbo.CasoJudicials");
            DropForeignKey("dbo.Operativoes", "CasoJudicialId", "dbo.CasoJudicials");
            DropForeignKey("dbo.Operativoes", "Agente3Id", "dbo.Agentes");
            DropForeignKey("dbo.Operativoes", "Agente2Id", "dbo.Agentes");
            DropForeignKey("dbo.Operativoes", "Agente1Id", "dbo.Agentes");
            DropForeignKey("dbo.Evidencias", "CasoJudicialId", "dbo.CasoJudicials");
            DropForeignKey("dbo.Audiencias", "TribunalId", "dbo.Tribunals");
            DropForeignKey("dbo.Audiencias", "CasoJudicialId", "dbo.CasoJudicials");
            DropForeignKey("dbo.CasoJudicials", "AgenteId", "dbo.Agentes");
            DropIndex("dbo.Sospechosoes", new[] { "CasoJudicialId" });
            DropIndex("dbo.Operativoes", new[] { "CasoJudicialId" });
            DropIndex("dbo.Operativoes", new[] { "Agente3Id" });
            DropIndex("dbo.Operativoes", new[] { "Agente2Id" });
            DropIndex("dbo.Operativoes", new[] { "Agente1Id" });
            DropIndex("dbo.Evidencias", new[] { "CasoJudicialId" });
            DropIndex("dbo.Audiencias", new[] { "CasoJudicialId" });
            DropIndex("dbo.Audiencias", new[] { "TribunalId" });
            DropIndex("dbo.CasoJudicials", new[] { "AgenteId" });
            DropTable("dbo.Usuarios");
            DropTable("dbo.Bitacoras");
            DropTable("dbo.Sospechosoes");
            DropTable("dbo.Operativoes");
            DropTable("dbo.Evidencias");
            DropTable("dbo.Tribunals");
            DropTable("dbo.Audiencias");
            DropTable("dbo.CasoJudicials");
            DropTable("dbo.Agentes");
        }
    }
}

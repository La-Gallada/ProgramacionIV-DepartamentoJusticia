namespace DepartamentoJusticia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class JuanchoCamposCalculados : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Agentes", "SalarioTotal", c => c.Double(nullable: false));
            AddColumn("dbo.CasoJudicials", "Prioridad", c => c.String());
            AddColumn("dbo.Operativoes", "CostoOperativo", c => c.Double(nullable: false));
            AlterColumn("dbo.Agentes", "NumeroPlaca", c => c.String(nullable: false));
            AlterColumn("dbo.Agentes", "NombreCompleto", c => c.String(nullable: false));
            AlterColumn("dbo.Agentes", "Especialidad", c => c.String(nullable: false));
            AlterColumn("dbo.Agentes", "Rango", c => c.String(nullable: false));
            AlterColumn("dbo.Agentes", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.CasoJudicials", "NumeroCaso", c => c.String(nullable: false));
            AlterColumn("dbo.CasoJudicials", "NombreCaso", c => c.String(nullable: false));
            AlterColumn("dbo.CasoJudicials", "TipoDelito", c => c.String(nullable: false));
            AlterColumn("dbo.CasoJudicials", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.CasoJudicials", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.CasoJudicials", "NombreAgente", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "NombreOperativo", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "Ciudad", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "TipoOperativo", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "NombreAgente1", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "NombreAgente2", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "NombreAgente3", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "Resultado", c => c.String(nullable: false));
            AlterColumn("dbo.Operativoes", "NumeroCaso", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Operativoes", "NumeroCaso", c => c.String());
            AlterColumn("dbo.Operativoes", "Resultado", c => c.String());
            AlterColumn("dbo.Operativoes", "NombreAgente3", c => c.String());
            AlterColumn("dbo.Operativoes", "NombreAgente2", c => c.String());
            AlterColumn("dbo.Operativoes", "NombreAgente1", c => c.String());
            AlterColumn("dbo.Operativoes", "TipoOperativo", c => c.String());
            AlterColumn("dbo.Operativoes", "Ciudad", c => c.String());
            AlterColumn("dbo.Operativoes", "NombreOperativo", c => c.String());
            AlterColumn("dbo.CasoJudicials", "NombreAgente", c => c.String());
            AlterColumn("dbo.CasoJudicials", "Descripcion", c => c.String());
            AlterColumn("dbo.CasoJudicials", "Estado", c => c.String());
            AlterColumn("dbo.CasoJudicials", "TipoDelito", c => c.String());
            AlterColumn("dbo.CasoJudicials", "NombreCaso", c => c.String());
            AlterColumn("dbo.CasoJudicials", "NumeroCaso", c => c.String());
            AlterColumn("dbo.Agentes", "Estado", c => c.String());
            AlterColumn("dbo.Agentes", "Rango", c => c.String());
            AlterColumn("dbo.Agentes", "Especialidad", c => c.String());
            AlterColumn("dbo.Agentes", "NombreCompleto", c => c.String());
            AlterColumn("dbo.Agentes", "NumeroPlaca", c => c.String());
            DropColumn("dbo.Operativoes", "CostoOperativo");
            DropColumn("dbo.CasoJudicials", "Prioridad");
            DropColumn("dbo.Agentes", "SalarioTotal");
        }
    }
}

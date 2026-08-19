namespace DepartamentoJusticia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NivelRiesgoSospechoso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sospechosoes", "NivelRiesgo", c => c.String());
            AlterColumn("dbo.Audiencias", "TipoAudiencia", c => c.String(nullable: false));
            AlterColumn("dbo.Audiencias", "NombreTribunal", c => c.String(nullable: false));
            AlterColumn("dbo.Audiencias", "NumeroCaso", c => c.String(nullable: false));
            AlterColumn("dbo.Audiencias", "Observaciones", c => c.String(nullable: false));
            AlterColumn("dbo.Audiencias", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.Evidencias", "Codigo", c => c.String(nullable: false));
            AlterColumn("dbo.Evidencias", "TipoEvidencia", c => c.String(nullable: false));
            AlterColumn("dbo.Evidencias", "Descripcion", c => c.String(nullable: false));
            AlterColumn("dbo.Evidencias", "LugarHallazgo", c => c.String(nullable: false));
            AlterColumn("dbo.Evidencias", "NumeroCaso", c => c.String(nullable: false));
            AlterColumn("dbo.Sospechosoes", "Identificacion", c => c.String(nullable: false));
            AlterColumn("dbo.Sospechosoes", "NombreCompleto", c => c.String(nullable: false));
            AlterColumn("dbo.Sospechosoes", "Nacionalidad", c => c.String(nullable: false));
            AlterColumn("dbo.Sospechosoes", "EstadoLegal", c => c.String(nullable: false));
            AlterColumn("dbo.Sospechosoes", "NumeroCaso", c => c.String(nullable: false));
            AlterColumn("dbo.Tribunals", "Nombre", c => c.String(nullable: false));
            AlterColumn("dbo.Tribunals", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.Tribunals", "Ciudad", c => c.String(nullable: false));
            AlterColumn("dbo.Tribunals", "JuezAsignado", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "NombreCompleto", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Identificacion", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Cargo", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Estado", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "NombreUsuario", c => c.String(nullable: false));
            AlterColumn("dbo.Usuarios", "Contrasenia", c => c.String(nullable: false));
        }
        
        public override void Down()
        {
            AlterColumn("dbo.Usuarios", "Contrasenia", c => c.String());
            AlterColumn("dbo.Usuarios", "NombreUsuario", c => c.String());
            AlterColumn("dbo.Usuarios", "Estado", c => c.String());
            AlterColumn("dbo.Usuarios", "Cargo", c => c.String());
            AlterColumn("dbo.Usuarios", "Identificacion", c => c.String());
            AlterColumn("dbo.Usuarios", "NombreCompleto", c => c.String());
            AlterColumn("dbo.Tribunals", "JuezAsignado", c => c.String());
            AlterColumn("dbo.Tribunals", "Ciudad", c => c.String());
            AlterColumn("dbo.Tribunals", "Estado", c => c.String());
            AlterColumn("dbo.Tribunals", "Nombre", c => c.String());
            AlterColumn("dbo.Sospechosoes", "NumeroCaso", c => c.String());
            AlterColumn("dbo.Sospechosoes", "EstadoLegal", c => c.String());
            AlterColumn("dbo.Sospechosoes", "Nacionalidad", c => c.String());
            AlterColumn("dbo.Sospechosoes", "NombreCompleto", c => c.String());
            AlterColumn("dbo.Sospechosoes", "Identificacion", c => c.String());
            AlterColumn("dbo.Evidencias", "NumeroCaso", c => c.String());
            AlterColumn("dbo.Evidencias", "LugarHallazgo", c => c.String());
            AlterColumn("dbo.Evidencias", "Descripcion", c => c.String());
            AlterColumn("dbo.Evidencias", "TipoEvidencia", c => c.String());
            AlterColumn("dbo.Evidencias", "Codigo", c => c.String());
            AlterColumn("dbo.Audiencias", "Estado", c => c.String());
            AlterColumn("dbo.Audiencias", "Observaciones", c => c.String());
            AlterColumn("dbo.Audiencias", "NumeroCaso", c => c.String());
            AlterColumn("dbo.Audiencias", "NombreTribunal", c => c.String());
            AlterColumn("dbo.Audiencias", "TipoAudiencia", c => c.String());
            DropColumn("dbo.Sospechosoes", "NivelRiesgo");
        }
    }
}

namespace DepartamentoJusticia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class Inicial1 : DbMigration
    {
        public override void Up()
        {
            RenameTable(name: "dbo.CasoJudicials", newName: "CasosJudiciales");
            RenameTable(name: "dbo.Tribunals", newName: "Tribunales");
            RenameTable(name: "dbo.Operativoes", newName: "Operativos");
            RenameTable(name: "dbo.Sospechosoes", newName: "Sospechosos");
        }
        
        public override void Down()
        {
            RenameTable(name: "dbo.Sospechosos", newName: "Sospechosoes");
            RenameTable(name: "dbo.Operativos", newName: "Operativoes");
            RenameTable(name: "dbo.Tribunales", newName: "Tribunals");
            RenameTable(name: "dbo.CasosJudiciales", newName: "CasoJudicials");
        }
    }
}

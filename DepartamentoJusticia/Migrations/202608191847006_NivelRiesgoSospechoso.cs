namespace DepartamentoJusticia.Migrations
{
    using System;
    using System.Data.Entity.Migrations;
    
    public partial class NivelRiesgoSospechoso : DbMigration
    {
        public override void Up()
        {
            AddColumn("dbo.Sospechosoes", "NivelRiesgo", c => c.String());
            Sql(@"
                UPDATE dbo.Sospechosoes
                SET NivelRiesgo =
                    CASE
                        WHEN NivelPeligrosidad BETWEEN 1 AND 25 THEN N'Riesgo Bajo'
                        WHEN NivelPeligrosidad BETWEEN 26 AND 50 THEN N'Riesgo Moderado'
                        WHEN NivelPeligrosidad BETWEEN 51 AND 75 THEN N'Riesgo Alto'
                        WHEN NivelPeligrosidad BETWEEN 76 AND 100 THEN N'Riesgo Crítico'
                        ELSE N'No calculado'
                    END
                WHERE NivelRiesgo IS NULL OR NivelRiesgo = ''
            ");
        }
        
        public override void Down()
        {
            DropColumn("dbo.Sospechosoes", "NivelRiesgo");
        }
    }
}

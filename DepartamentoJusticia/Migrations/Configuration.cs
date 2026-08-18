namespace DepartamentoJusticia.Migrations
{
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DepartamentoJusticia.Services.Service>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DepartamentoJusticia.Services.Service context)
        {
        }
    }
}

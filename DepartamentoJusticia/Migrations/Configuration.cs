namespace DepartamentoJusticia.Migrations
{
    using DepartamentoJusticia.Models;
    using DepartamentoJusticia.Services;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DepartamentoJusticia.Services.Service>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

       
        protected override void Seed(Service context)
        {
            if (!context.usuarios.Any())
            {
                context.usuarios.Add(new Usuario
                {
                    NombreCompleto = "Juan Gabriel Sandi Lopez",
                    Identificacion = "111111111",
                    Cargo = "Administrador",
                    FechaRegistro = DateTime.Now,
                    Estado = "Activo",
                    NombreUsuario = "juancho",
                    Contrasenia = "1234"
                });
                context.SaveChanges();
            }
        }
    }
}

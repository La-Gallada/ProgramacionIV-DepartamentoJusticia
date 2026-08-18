namespace DepartamentoJusticia.Migrations
{
    using DepartamentoJusticia.Models;
    using System;
    using System.Linq;
    using System.Data.Entity.Migrations;

    internal sealed class Configuration : DbMigrationsConfiguration<DepartamentoJusticia.Services.Service>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
        }

        protected override void Seed(DepartamentoJusticia.Services.Service context)
        {
            if (!context.usuarios.Any(u => u.NombreUsuario == "admin"))
            {
                Usuario usuarioAdministrador = new Usuario();

                usuarioAdministrador.NombreCompleto = "Administrador del Sistema";
                usuarioAdministrador.Identificacion = "ADMIN-001";
                usuarioAdministrador.Cargo = "Administrador";
                usuarioAdministrador.FechaRegistro = DateTime.Now.Date;
                usuarioAdministrador.Estado = "Activo";
                usuarioAdministrador.NombreUsuario = "admin";
                usuarioAdministrador.Contrasenia = "Admin123";

                context.usuarios.Add(usuarioAdministrador);
            }
        }
    }
}

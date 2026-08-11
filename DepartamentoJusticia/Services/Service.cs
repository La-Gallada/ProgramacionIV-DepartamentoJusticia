using DepartamentoJusticia.Models;
using System.Data.Entity;

namespace DepartamentoJusticia.Services;

public class Service : DbContext
{
    public Service() : base("DepartamentoJusticia")
    {
    }

    public DbSet<Agente> Agentes { get; set; }
    public DbSet<CasoJudicial> casosJudiciales { get; set; }
    public DbSet<Sospechoso> sospechosos { get; set; }
    public DbSet<Evidencia> evidencias { get; set; }
    public DbSet<Operativo> operativos { get; set; }
    public DbSet<Tribunal> tribunales { get; set; }
    public DbSet<Audiencia> audiencias { get; set; }
    public DbSet<Usuario> usuarios { get; set; }
    public DbSet<Bitacora> bitacoras { get; set; }



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

    public void AgregarUsuario(Usuario usuario)
    {
        usuarios.Add(usuario);
        SaveChanges();
    }

    public List<Usuario> ObtenerUsuarios()
    {
        List<Usuario> listaUsuarios = usuarios.AsNoTracking().ToList();
        return listaUsuarios;
    }

    public Usuario? ObtenerUsuarioPorId(int id)
    {
        Usuario? usuario = usuarios.AsNoTracking().FirstOrDefault(u => u.Id == id);
        return usuario;
    }

    public bool ActualizarUsuario(Usuario usuario)
    {
        Usuario? usuarioActual = usuarios.Find(usuario.Id);

        if (usuarioActual == null)
        {
            return false;
        }

        usuarioActual.NombreCompleto = usuario.NombreCompleto;
        usuarioActual.Identificacion = usuario.Identificacion;
        usuarioActual.Cargo = usuario.Cargo;
        usuarioActual.FechaRegistro = usuario.FechaRegistro;
        usuarioActual.Estado = usuario.Estado;
        usuarioActual.NombreUsuario = usuario.NombreUsuario;

        SaveChanges();
        return true;
    }

    public bool EliminarUsuario(int id)
    {
        Usuario? usuario = usuarios.Find(id);

        if (usuario == null)
        {
            return false;
        }

        usuarios.Remove(usuario);
        SaveChanges();
        return true;
    }

    public bool NombreUsuarioExiste(string nombreUsuario, int idExcluir = 0)
    {
        return usuarios.Any(u => u.NombreUsuario == nombreUsuario && u.Id != idExcluir);
    }

    public List<Usuario> BuscarUsuarios(string nombreCompleto, string nombreUsuario, string cargo, string estado)
    {
        IQueryable<Usuario> consulta = usuarios.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombreCompleto))
        {
            consulta = consulta.Where(u => u.NombreCompleto.Contains(nombreCompleto));
        }

        if (!string.IsNullOrWhiteSpace(nombreUsuario))
        {
            consulta = consulta.Where(u => u.NombreUsuario.Contains(nombreUsuario));
        }

        if (!string.IsNullOrWhiteSpace(cargo))
        {
            consulta = consulta.Where(u => u.Cargo == cargo);
        }

        if (!string.IsNullOrWhiteSpace(estado))
        {
            consulta = consulta.Where(u => u.Estado == estado);
        }

        List<Usuario> listaUsuarios = consulta.ToList();
        return listaUsuarios;
    }

    public bool ActualizarContrasenia(int id, string nuevaContrasenia)
    {
        Usuario? usuario = usuarios.Find(id);

        if (usuario == null)
        {
            return false;
        }

        usuario.Contrasenia = nuevaContrasenia;
        SaveChanges();
        return true;
    }

    #endregion

    #region Bitácora

    #endregion
}

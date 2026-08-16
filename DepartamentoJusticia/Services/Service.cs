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
    //holaas


    #region Agentes Federales

    #endregion

    #region Casos Judiciales
    public List<CasoJudicial> mostrarCasoJudicial()
    {
        return casosJudiciales.ToList();
    }

    #endregion

    #region Sospechosos

    #endregion

    #region Evidencias
    public void agregarEvidencia(Evidencia evidencita)
    {
        evidencias.Add(evidencita);
        SaveChanges();
    }

    public List<Evidencia> mostrarEvidencias()
    {
        return evidencias.ToList();
    }

    public Evidencia buscarEvidencia(int id)
    {
        var evidenciaBuscada = evidencias.FirstOrDefault(v => v.Id == id);
        if (evidenciaBuscada != null)
            return evidenciaBuscada;
        else throw new Exception("No se encuentra esa evidencia");
    }

    public void eliminarEvidencia(Evidencia evidencita)
    {
        evidencias.Remove(evidencita);
        SaveChanges();
    }

    public void actualizarEvidencia(Evidencia evidencita)
    {
        var evidenciaAntigua = evidencias.FirstOrDefault(v => v.Id == evidencita.Id);
        if (evidenciaAntigua != null)
        {
            evidenciaAntigua.Codigo = evidencita.Codigo;
            evidenciaAntigua.TipoEvidencia = evidencita.TipoEvidencia;
            evidenciaAntigua.Descripcion = evidencita.Descripcion;
            evidenciaAntigua.LugarHallazgo = evidencita.LugarHallazgo;
            evidenciaAntigua.FechaRecoleccion = evidencita.FechaRecoleccion;
            evidenciaAntigua.NumeroCaso = evidencita.NumeroCaso;
            
            SaveChanges();
        }
        else throw new Exception("No se pudo actualizar la evidencia");
    }
    #endregion

    #region Operativos

    #endregion

    #region Tribunales
    public void agregarTribunal(Tribunal tribunalito)
    {
        tribunales.Add(tribunalito);
        SaveChanges();
    }

    public List<Tribunal> mostrarTribunales()
    {
        return tribunales.ToList();
    }

    public Tribunal buscarTribunal(int id)
    {
        var tribunalBuscado = tribunales.FirstOrDefault(v => v.Id == id);
        if (tribunalBuscado != null)
            return tribunalBuscado;
        else throw new Exception("No se encuentra ese tribunal");
    }

    public void eliminarTribunal(Tribunal tribunalito)
    {
        tribunales.Remove(tribunalito);
        SaveChanges();
    }

    public void actualizarTribunal(Tribunal tribunalito)
    {
        var tribunalAntiguo = tribunales.FirstOrDefault(v => v.Id == tribunalito.Id);
        if (tribunalAntiguo != null)
        {
            tribunalAntiguo.Nombre = tribunalito.Nombre;
            tribunalAntiguo.Estado = tribunalito.Estado;
            tribunalAntiguo.Ciudad = tribunalito.Ciudad;
            tribunalAntiguo.JuezAsignado = tribunalito.JuezAsignado;
            tribunalAntiguo.CantidadSalas = tribunalito.CantidadSalas;
            SaveChanges();
        }
        else throw new Exception("No se pudo actualizar el tribunal");
    }
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

    public List<Usuario> BuscarUsuarios(string nombreCompleto, string identificacion, string nombreUsuario, string cargo, string estado)
    {
        IQueryable<Usuario> consulta = usuarios.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombreCompleto))
        {
            consulta = consulta.Where(u => u.NombreCompleto.Contains(nombreCompleto));
        }

        if (!string.IsNullOrWhiteSpace(identificacion))
        {
            consulta = consulta.Where(u => u.Identificacion.Contains(identificacion));
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

    public Usuario? ValidarUsuario(string nombreUsuario, string contrasenia)
    {
        Usuario? usuario = usuarios.FirstOrDefault(u => u.NombreUsuario == nombreUsuario);

        if (usuario == null)
        {
            return null;
        }

        if (usuario.Contrasenia != contrasenia)
        {
            return null;
        }

        if (usuario.Estado != "Activo")
        {
            return null;
        }

        return usuario;
    }

    #endregion

    #region Bitácora

    public void RegistrarBitacora(string nombreUsuario, string resultado)
    {
        Bitacora bitacora = new Bitacora();
        bitacora.Fecha = DateTime.Now.Date;
        bitacora.Hora = DateTime.Now.TimeOfDay;
        bitacora.NombreUsuario = nombreUsuario;
        bitacora.Resultado = resultado;

        bitacoras.Add(bitacora);
        SaveChanges();
    }

    public List<Bitacora> ObtenerBitacora()
    {
        List<Bitacora> listaBitacora = bitacoras.AsNoTracking().ToList();
        return listaBitacora;
    }

    public List<Bitacora> BuscarBitacora(string nombreUsuario, string resultado, DateTime? fecha)
    {
        IQueryable<Bitacora> consulta = bitacoras.AsNoTracking();

        if (!string.IsNullOrWhiteSpace(nombreUsuario))
        {
            consulta = consulta.Where(b => b.NombreUsuario.Contains(nombreUsuario));
        }

        if (!string.IsNullOrWhiteSpace(resultado))
        {
            consulta = consulta.Where(b => b.Resultado == resultado);
        }

        if (fecha.HasValue)
        {
            DateTime fechaBuscar = fecha.Value.Date;
            consulta = consulta.Where(b => b.Fecha == fechaBuscar);
        }

        consulta = consulta.OrderByDescending(b => b.Fecha).ThenByDescending(b => b.Hora);

        List<Bitacora> listaBitacora = consulta.ToList();
        return listaBitacora;
    }

    #endregion
}

using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;

namespace DepartamentoJusticia.Controllers;

public class UsuariosController : ControladorBase
{
    private readonly Service service;

    public UsuariosController(Service service)
    {
        this.service = service;
    }

    public IActionResult Index(string nombreCompleto, string identificacion, string nombreUsuario, string cargo, string estado)
    {
        ViewBag.NombreCompleto = nombreCompleto;
        ViewBag.Identificacion = identificacion;
        ViewBag.NombreUsuario = nombreUsuario;
        ViewBag.Cargo = cargo;
        ViewBag.Estado = estado;

        List<Usuario> listaUsuarios = service.BuscarUsuarios(nombreCompleto, identificacion, nombreUsuario, cargo, estado);
        return View(listaUsuarios);
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(Usuario usuario, string confirmarContrasenia)
    {
        if (service.NombreUsuarioExiste(usuario.NombreUsuario))
        {
            ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya existe.");
        }

        if (usuario.Contrasenia != confirmarContrasenia)
        {
            ModelState.AddModelError("confirmarContrasenia", "La confirmación de contraseña no coincide.");
        }

        if (!ModelState.IsValid)
        {
            return View(usuario);
        }

        service.AgregarUsuario(usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Edit(int id)
    {
        Usuario? usuario = service.ObtenerUsuarioPorId(id);

        if (usuario == null)
        {
            return RedirectToAction("Index");
        }

        return View(usuario);
    }

    [HttpPost]
    public IActionResult Edit(Usuario usuario)
    {
        if (service.NombreUsuarioExiste(usuario.NombreUsuario, usuario.Id))
        {
            ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya existe.");
        }

        if (!ModelState.IsValid)
        {
            return View(usuario);
        }

        service.ActualizarUsuario(usuario);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult Delete(int id)
    {
        Usuario? usuario = service.ObtenerUsuarioPorId(id);

        if (usuario == null)
        {
            return RedirectToAction("Index");
        }

        return View(usuario);
    }

    [HttpPost]
    public IActionResult Delete(int id, string confirmar)
    {
        service.EliminarUsuario(id);
        return RedirectToAction("Index");
    }

    [HttpGet]
    public IActionResult CambiarContrasenia(int id)
    {
        Usuario? usuario = service.ObtenerUsuarioPorId(id);

        if (usuario == null)
        {
            return RedirectToAction("Index");
        }

        return View(usuario);
    }

    [HttpPost]
    public IActionResult CambiarContrasenia(int id, string nuevaContrasenia, string confirmarNuevaContrasenia)
    {
        if (nuevaContrasenia != confirmarNuevaContrasenia)
        {
            ModelState.AddModelError("confirmarNuevaContrasenia", "La confirmación de contraseña no coincide.");
        }

        if (!ModelState.IsValid)
        {
            Usuario? usuario = service.ObtenerUsuarioPorId(id);
            return View(usuario);
        }

        service.ActualizarContrasenia(id, nuevaContrasenia);
        return RedirectToAction("Index");
    }
}

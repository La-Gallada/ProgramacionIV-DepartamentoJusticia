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
    [ValidateAntiForgeryToken]
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
    [ValidateAntiForgeryToken]
    public IActionResult Edit(Usuario usuario)
    {
        Usuario? usuarioActual = service.ObtenerUsuarioPorId(usuario.Id);

        if (usuarioActual == null)
        {
            TempData["Error"] = "El usuario solicitado no existe.";
            return RedirectToAction("Index");
        }

        usuario.Contrasenia = usuarioActual.Contrasenia;
        ModelState.Remove(nameof(Usuario.Contrasenia));

        if (service.NombreUsuarioExiste(usuario.NombreUsuario, usuario.Id))
        {
            ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya existe.");
        }

        if (!ModelState.IsValid)
        {
            return View(usuario);
        }

        if (!service.ActualizarUsuario(usuario))
        {
            TempData["Error"] = "No fue posible actualizar el usuario.";
            return RedirectToAction("Index");
        }

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
    [ValidateAntiForgeryToken]
    public IActionResult Delete(int id, string confirmar)
    {
        if (!service.EliminarUsuario(id))
        {
            TempData["Error"] = "No fue posible eliminar el usuario.";
        }

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
    [ValidateAntiForgeryToken]
    public IActionResult CambiarContrasenia(int id, string nuevaContrasenia, string confirmarNuevaContrasenia)
    {
        Usuario? usuario = service.ObtenerUsuarioPorId(id);

        if (usuario == null)
        {
            TempData["Error"] = "El usuario solicitado no existe.";
            return RedirectToAction("Index");
        }

        if (string.IsNullOrWhiteSpace(nuevaContrasenia))
        {
            ModelState.AddModelError("nuevaContrasenia", "La nueva contraseña es obligatoria.");
        }

        if (nuevaContrasenia != confirmarNuevaContrasenia)
        {
            ModelState.AddModelError("confirmarNuevaContrasenia", "La confirmación de contraseña no coincide.");
        }

        if (!ModelState.IsValid)
        {
            return View(usuario);
        }

        if (!service.ActualizarContrasenia(id, nuevaContrasenia))
        {
            TempData["Error"] = "No fue posible actualizar la contraseña.";
            return RedirectToAction("Index");
        }

        return RedirectToAction("Index");
    }
}

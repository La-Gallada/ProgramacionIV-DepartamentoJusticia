using DepartamentoJusticia.Models;
using DepartamentoJusticia.Services;
using Microsoft.AspNetCore.Mvc;
namespace DepartamentoJusticia.Controllers
{
    public class UsuariosController : ControladorBase
    {
        // GET: UsuariosController
        Service service;
        public UsuariosController() { service = new Service(); }

        public ActionResult Index(string nombreCompleto, string identificacion, string nombreUsuario, string cargo, string estado)
        {
            try
            {
                ViewBag.NombreCompleto = nombreCompleto;
                ViewBag.Identificacion = identificacion;
                ViewBag.NombreUsuario = nombreUsuario;
                ViewBag.Cargo = cargo;
                ViewBag.Estado = estado;

                if (!string.IsNullOrEmpty(nombreCompleto))
                    return View(service.buscarUsuariosPorNombre(nombreCompleto));
                else if (!string.IsNullOrEmpty(identificacion))
                    return View(service.buscarUsuariosPorIdentificacion(identificacion));
                else if (!string.IsNullOrEmpty(nombreUsuario))
                    return View(service.buscarUsuariosPorNombreUsuario(nombreUsuario));
                else if (!string.IsNullOrEmpty(cargo))
                    return View(service.buscarUsuariosPorCargo(cargo));
                else if (!string.IsNullOrEmpty(estado))
                    return View(service.buscarUsuariosPorEstado(estado));
                else
                    return View(service.mostrarUsuarios());
            }
            catch
            {
                return View(service.mostrarUsuarios());
            }
        }
        // GET: UsuariosController/Details/5
        public ActionResult Details(int id)
        {
            return RedirectToAction("Index");
        }
        // GET: UsuariosController/Create
        public ActionResult Create()
        {
            return View(new Usuario());
        }
        // POST: UsuariosController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Usuario usuarito, string confirmarContrasenia)
        {
            try
            {
                if (service.existeNombreUsuario(usuarito.NombreUsuario))
                {
                    ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya existe");
                }

                if (usuarito.Contrasenia != confirmarContrasenia)
                {
                    ModelState.AddModelError("Contrasenia", "La confirmacion de contrasenia no coincide");
                }

                if (ModelState.IsValid)
                {
                    service.agregarUsuario(usuarito);
                    return RedirectToAction("Index");
                }
                else return View(usuarito);
            }
            catch
            {
                return View(usuarito);
            }
        }
        // GET: UsuariosController/Edit/5
        public ActionResult Edit(int id)
        {
            try
            {
                var usuarioBuscado = service.buscarUsuario(id);
                return View(usuarioBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: UsuariosController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(Usuario usuarito)
        {
            try
            {
                var usuarioExistente = service.buscarUsuario(usuarito.Id);
                usuarito.Contrasenia = usuarioExistente.Contrasenia;
                ModelState.Remove(nameof(Usuario.Contrasenia));

                if (service.existeNombreUsuario(usuarito.NombreUsuario, usuarito.Id))
                {
                    ModelState.AddModelError("NombreUsuario", "El nombre de usuario ya existe");
                }

                if (ModelState.IsValid)
                {
                    service.actualizarUsuario(usuarito);
                    return RedirectToAction("Index");
                }
                else return View(usuarito);
            }
            catch
            {
                return View(usuarito);
            }
        }
        // GET: UsuariosController/CambiarContrasenia/5
        public ActionResult CambiarContrasenia(int id)
        {
            try
            {
                var usuarioBuscado = service.buscarUsuario(id);
                return View(usuarioBuscado);
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // POST: UsuariosController/CambiarContrasenia/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult CambiarContrasenia(int id, string nuevaContrasenia, string confirmarNuevaContrasenia)
        {
            try
            {
                var usuarioBuscado = service.buscarUsuario(id);

                if (string.IsNullOrWhiteSpace(nuevaContrasenia))
                {
                    ModelState.AddModelError("nuevaContrasenia", "La nueva contraseña es obligatoria.");
                    return View(usuarioBuscado);
                }

                if (nuevaContrasenia != confirmarNuevaContrasenia)
                {
                    ModelState.AddModelError("", "La confirmacion de contrasenia no coincide");
                    return View(usuarioBuscado);
                }

                service.actualizarContrasenia(id, nuevaContrasenia);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
        // GET: UsuariosController/Delete/5
        public ActionResult Delete(int id)
        {
            try
            {
                var usuarioEliminado = service.buscarUsuario(id);
                service.eliminarUsuario(usuarioEliminado);
                return RedirectToAction("Index");
            }
            catch (Exception)
            {
                return RedirectToAction("Index");
            }
        }
    }
}

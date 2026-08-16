# Guia de frontend - Departamento de Justicia

Esta guia existe para que los 9 modulos del sistema se vean igual sin que nadie
tenga que rehacer vistas al final. **El modulo de Sospechosos es la plantilla.**

---

## Regla unica

> No escriban CSS. No usen Bootstrap. Copien las vistas de `Views/Sospechosos/`
> y cambien el modelo, las columnas y los criterios de busqueda.

Todos los estilos del sistema estan en **`wwwroot/css/departamento.css`**.
Si necesitan algo que no existe ahi, avisen antes de inventar una clase.

---

## Como armar su modulo en 4 pasos

### 1. Clase logica (`Models/SuModelo.cs`)

Agreguen las anotaciones de validacion y, si su modulo tiene un calculo
del enunciado, pongalo **en la clase logica** con `[NotMapped]`, no en el
controlador. Ejemplo en `Models/Sospechoso.cs`, region `Calculos de la clase logica`.

### 2. Region en `Services/Service.cs`

Llenen **solo su region**. No toquen las regiones de los demas o el merge se
vuelve un infierno. Metodos minimos, siguiendo la region `Sospechosos`:

| Metodo | Para que |
|---|---|
| `ObtenerXxx()` | listar todo |
| `ObtenerXxx(int id)` | traer uno |
| `BuscarXxx(...)` | busqueda por multiples criterios (obligatoria del enunciado) |
| `AgregarXxx(...)` | insertar |
| `ActualizarXxx(...)` | modificar |
| `EliminarXxx(int id)` | borrar |

Los criterios de busqueda deben ser **combinables**: cada filtro que venga vacio
simplemente no se aplica. Vean `BuscarSospechosos` como ejemplo.

### 3. Controlador (`Controllers/SuControlador.cs`)

Copien `Controllers/SospechososController.cs`. Ya trae el patron completo:
inyeccion del `Service`, `Index` con busqueda, `Crear`, `Editar`, `Detalles` y
`Eliminar` con confirmacion, mas `TempData` para los mensajes.

### 4. Vistas (`Views/SuModulo/`)

Copien los 6 archivos de `Views/Sospechosos/`:

| Archivo | Que es |
|---|---|
| `Index.cshtml` | panel de busqueda + tabla |
| `_Formulario.cshtml` | campos compartidos entre Crear y Editar |
| `Crear.cshtml` | alta |
| `Editar.cshtml` | modificacion |
| `Detalles.cshtml` | ficha de solo lectura |
| `Eliminar.cshtml` | confirmacion antes de borrar |

---

## Partials compartidos

**`_MensajeAlerta`** - ya viene en el `_Layout`, no lo invoquen. Desde el
controlador:

```csharp
TempData["Exito"] = "El registro se guardo correctamente.";
TempData["Error"] = "No fue posible eliminar el registro.";
TempData["Aviso"] = "No se encontraron resultados.";
```

**`_EncabezadoModulo`** - titulo, descripcion y boton de agregar:

```cshtml
<partial name="_EncabezadoModulo" model='new EncabezadoModulo {
    Titulo = "Evidencias",
    Descripcion = "Elementos recolectados en cada caso.",
    TextoBoton = "Agregar evidencia",
    Controlador = "Evidencias",
    Accion = "Crear" }' />
```

**`_ValidationScriptsPartial`** - solo en vistas con formulario:

```cshtml
@section Scripts { <partial name="_ValidationScriptsPartial" /> }
```

---

## Clases CSS disponibles

**Estructura**

`dj-panel` `dj-panel-titulo` `dj-panel-cuerpo` `dj-encabezado` `dj-acciones`

**Formularios**

`dj-formulario-rejilla` `dj-campo` `dj-campo-ancho` `dj-etiqueta` `dj-control`
`dj-ayuda` `dj-error` `dj-resumen-errores`

**Botones**

`dj-boton` + una de `dj-boton-primario` `dj-boton-secundario` `dj-boton-peligro`
(opcional `dj-boton-pequeno` para las acciones de la tabla)

**Tablas**

`dj-tabla-envoltura` `dj-tabla` `dj-tabla-acciones` `dj-tabla-numero`
`dj-tabla-vacia` `dj-contador`

**Estados**

`dj-etiqueta-estado` + el color que devuelve el helper:

```cshtml
<span class="dj-etiqueta-estado @Etiquetas.ClaseEstado(item.Estado)">@item.Estado</span>
```

`Etiquetas.ClaseEstado()` ya conoce los estados de todos los modulos
(Activo, Inactivo, En proceso, Finalizado, Efectivo, Suspendido, etc.).
Si su modulo tiene un estado nuevo, agreguenlo en `ViewModels/Etiquetas.cs`.

**Detalle**

`dj-detalle` `dj-detalle-item` (una `<dl>` con `<dt>` y `<dd>` adentro)

---

## Activar su modulo en el menu

En `Views/Shared/_Layout.cshtml` busquen su `<li>` marcado como PENDIENTE y
cambien el `<span>` por un enlace real:

```cshtml
<li><a class="dj-menu-enlace @Activo("Evidencias")" asp-controller="Evidencias" asp-action="Index">Evidencias</a></li>
```

Y agreguen su atajo en `Views/Inicio/Index.cshtml` copiando el de Sospechosos.

---

## Pendientes que NO son de frontend

- **Chris**: el `POST Index` de `LoginController` es un marcador temporal.
  Hay que implementar validacion de usuario, contrasena, estado activo,
  registro en Bitacora y guardado de sesion. El `_Layout` ya lee de la sesion
  las claves `NombreCompleto` y `Cargo` para la barra superior.
- **Chris**: falta el filtro que impide entrar por URL sin sesion iniciada.
- **Todos**: en `Controllers/AcercaDeController.cs` hay que llenar universidad,
  profesora y los nombres reales de los integrantes.
- **Todos**: la imagen `wwwroot/img/portada.svg` es un marcador; se puede
  sustituir por una fotografia real con el mismo nombre.

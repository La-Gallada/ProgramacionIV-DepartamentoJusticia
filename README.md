# DepartamentoJusticia

Proyecto Final del curso **Programación IV**.

Sistema web desarrollado para la administración de información del Departamento de Justicia, incluyendo investigaciones criminales, agentes federales, casos judiciales, sospechosos, evidencias, operativos, tribunales, audiencias, usuarios y bitácora de accesos.

## Tecnologías

- ASP.NET Core MVC
- .NET 8
- C#
- Entity Framework Core 8
- SQL Server / LocalDB
- Razor Views
- HTML
- CSS
- Git
- GitHub

## Arquitectura

El proyecto utiliza el patrón:

**Modelo - Vista - Controlador (MVC)**

La estructura principal de acceso a datos se encuentra en:

`Services/Service.cs`

La clase `Service` hereda de `DbContext` y contiene los `DbSet` correspondientes a las entidades del sistema.

El código de acceso a datos se organiza mediante regiones (`#region`) por módulo, siguiendo la estructura utilizada en el curso.

## Base de datos

Nombre de la base de datos:

`DepartamentoJusticia`

Motor:

`SQL Server LocalDB`

Entidades principales:

- Agentes
- CasosJudiciales
- Sospechosos
- Evidencias
- Operativos
- Tribunales
- Audiencias
- Usuarios
- Bitacoras

La migración inicial del proyecto se encuentra en:

`Migrations/`

## Módulos del sistema

El sistema deberá incluir los siguientes módulos:

- Inicio
- Agentes Federales
- Casos Judiciales
- Sospechosos
- Evidencias
- Operativos
- Tribunales
- Audiencias
- Usuarios
- Bitácora
- Acerca de
- Inicio de sesión
- Cerrar sesión

## Integrantes y distribución de trabajo

### Chris

**Líder del proyecto**

Rama:

`feature/chris-seguridad`

Responsabilidades:

- Usuarios
- Inicio de sesión
- Manejo de sesiones
- Bitácora
- Integración del proyecto
- Revisión general
- Control de ramas y merges

---

### Juancho

**Backend**

Rama:

`feature/juancho-backend`

Responsabilidades:

- Agentes Federales
- Casos Judiciales
- Operativos

Incluye la implementación de:

- Cálculo del salario total del agente
- Cálculo de prioridad del caso
- Cálculo del costo del operativo

---

### Val

**Frontend**

Rama:

`feature/val-frontend`

Responsabilidades:

- Sospechosos
- Audiencias
- Diseño visual global
- Layout
- CSS
- Formularios
- Tablas
- Homogeneización visual de las vistas

Incluye la implementación de:

- Cálculo del nivel de riesgo del sospechoso

---

### Mar

Rama:

`feature/mar-modulos`

Responsabilidades:

- Tribunales
- Evidencias
- Acerca de

## Estrategia de ramas

La estructura de Git utilizada es:

```text
main
└── dev
    ├── feature/chris-seguridad
    ├── feature/juancho-backend
    ├── feature/val-frontend
    └── feature/mar-modulos

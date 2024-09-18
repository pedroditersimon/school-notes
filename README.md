# SchoolNotes
API backend en ASP.Net C# con EntityFramework, sobre un sistema escolar para la gestión de Materias, Cursadas, Alumnos, Profesores y Examenes.  
Este es un proyecto de practica para implementar y reforzar el desarrollo basico de un sistema backend en .Net.

## Conocimientos adquiridos
Resumen de los conocimientos nuevos que adquirí y apliqué en el sistema:
- Estructura MVC en backend.
- Patrón Repositorio.
- Patrón UnitOfWork.
- Migraciones y CodeFirst para la base de datos.
- Inserción de semillas o datos iniciales en la base de datos.
- Clases y Interfaces generícas para Repositorios, Servicios y Controladores.
- BaseModel con propiedades heredadas y interacción con clases y interfaces generícas.
- SoftDelete con QueryFilter.
- Estructura y organizacion de una solucion y sus projectos en C#.
- ConcurrencyCheck con UpdatedDate, para evitar sobrescribir un registro que ya se esta editando simultanemante.
- Propiedades 'Navigators' de EntityFramework.
- GUIDs.
- Tablas relacionales.
- Tests unitarios.
- DTOs.
- Mappers.

## Mención y agradecimiento
Tomé riendas gracias a el [Curso de EntityFramework de NetMentor](https://youtube.com/playlist?list=PLesmOrW3mp4i2RdfsPI5R6o5EVacGuovz&si=kRphA8p3ITI40upE) en Youtube.  
Y a hechar un vistazo a los repositorios y proyectos de NetMentor en github:
- https://github.com/ElectNewt/curso-entity-framework
- https://github.com/ElectNewt/core-driven-architecture


## ToDo
- Implementar DTOs en las request/responses de los controladores
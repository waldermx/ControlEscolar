// Program.cs (Ejemplo en capa de presentación)
using ControlEscolar.Services;
using ControlEscolar.Data;
using ControlEscolar.Factories;
using ControlEscolar.Strategies;

// Configuración de dependencias
var repository = new InMemoryRepository();
var estrategiaAlumno = new AlumnoMatriculaStrategy();
var factoryAlumno = new AlumnoFactory(estrategiaAlumno);

// Crear coordinador
var coordinador = new Coordinador(repository, factoryAlumno);

// Inscribir alumno
coordinador.InscribirEntidad("Ana López");



using ControlEscolar.Services;
using ControlEscolar.Data;
using ControlEscolar.Factories;
using ControlEscolar.Strategies;


var repository = new InMemoryMatriculableRepository();
//Pasos para crear alumno
var estrategiaAlumno = new AlumnoMatriculaStrategy(); //Define el algoritmo para generar la matricula de un alumno
var generarAlumnoRegular = new AlumnoFactory(estrategiaAlumno);// Crea una fábrica de alumnos
var alumno = generarAlumnoRegular.CrearEntidad("Nombre");


// Crear coordinador
var coordinador = new Coordinador(repository, factoryAlumno);

// Inscribir alumno
coordinador.InscribirEntidad("Ana López");


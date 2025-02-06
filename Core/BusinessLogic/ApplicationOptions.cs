using ControlEscolar.Core.Interfaces;
using ControlEscolar.EntityClasses;
using ControlEscolar.Data;
using ControlEscolar.Core.Usuarios;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ControlEscolar.Core.BusinessLogic
{
    public class ApplicationOptions : IBusinessLogic
    {
        public IEnumerable<IOperation> GetAvailableOperations()
        {
            return new List<IOperation>
            {
                new AlumnosOperation(new ControlEscolarContext()), // Pasamos el contexto
                new CalificacionesOperation(),
                new HorariosOperation(),
                new ProfesoresOperation( new ControlEscolarContext())
            };
        }
    }

    public class AlumnosOperation : IOperation
    {
        private readonly AlumnoRepository alumnoRepository;

        // Constructor que recibe el contexto y crea el repositorio
        public AlumnosOperation(ControlEscolarContext context)
        {
            alumnoRepository = new AlumnoRepository(context);
        }

        public char CommandKey => '1';
        public string Description => "Gestionar Alumnos";

        public void Execute()
        {
            Console.WriteLine("\n=== Gestión de Alumnos ===");
            Console.WriteLine("1. Ver lista de alumnos");
            Console.WriteLine("2. Agregar alumno");
            Console.WriteLine("3. Buscar alumno por matrícula");
            Console.Write("Seleccione una opción: ");

            var opcion = Console.ReadLine();

            switch (opcion)
            {
                case "1":
                    VerListaDeAlumnos();
                    break;
                case "2":
                    AgregarAlumno();
                    break;
                case "3":
                    BuscarAlumnoPorMatricula();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
            }
        }

        private void VerListaDeAlumnos()
        {
            var alumnos = alumnoRepository.ObtenerUsuarios();
            Console.WriteLine("\n=== Lista de Alumnos ===");
            
            if (!alumnos.Any())
            {
                Console.WriteLine("📭 No hay alumnos registrados aún.");
                return;
            }

            foreach (var alumno in alumnos)
            {
                Console.WriteLine(alumno.ToString());
            }
        }

        private void AgregarAlumno()
        {
            Console.WriteLine("\n=== Agregar Alumno ===");
            Console.Write("Ingrese el nombre del alumno: ");
            var nombre = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(nombre))
            {
                Console.WriteLine("❌ El nombre no puede estar vacío.");
                return;
            }

            // Crear un nuevo alumno con matrícula generada
            var nuevoAlumno = new Alumno(nombre);
           
                alumnoRepository.AgregarUsuario(nuevoAlumno);
                Console.WriteLine("✅ Alumno agregado exitosamente.");
                Console.WriteLine($"📌 Matrícula generada: {nuevoAlumno.Matricula}");
            
           
        }

        private void BuscarAlumnoPorMatricula()
        {
            Console.WriteLine("\n=== Buscar Alumno por Matrícula ===");
            Console.Write("Ingrese la matrícula del alumno: ");
            var matricula = Console.ReadLine();

            if (string.IsNullOrWhiteSpace(matricula))
            {
                Console.WriteLine("❌ La matrícula no puede estar vacía.");
                return;
            }

            var alumno = alumnoRepository.ObtenerUsuarioPorMatricula(matricula);

            if (alumno != null)
            {
                Console.WriteLine("✅ Alumno encontrado:");
                Console.WriteLine(alumno.ToString());
            }
            else
            {
                Console.WriteLine("❌ No se encontró ningún alumno con esa matrícula.");
            }
        }
    }

    public class CalificacionesOperation : IOperation
    {
        public char CommandKey => '2';
        public string Description => "Gestionar Calificaciones";

        public void Execute()
        {
            Console.WriteLine("\n=== Gestión de Calificaciones ===");
            Console.WriteLine("1. Ver calificaciones por alumno");
            Console.WriteLine("2. Registrar calificación");
            Console.WriteLine("3. Modificar calificación");
            // TODO: Implementar lógica específica de calificaciones
        }
    }

    public class HorariosOperation : IOperation
    {
        public char CommandKey => '3';
        public string Description => "Gestionar Horarios";

        public void Execute()
        {
            Console.WriteLine("\n=== Gestión de Horarios ===");
            Console.WriteLine("1. Ver horarios");
            Console.WriteLine("2. Asignar horario");
            Console.WriteLine("3. Modificar horario");
            // TODO: Implementar lógica específica de horarios
        }
    }

    public class ProfesoresOperation : IOperation
    {
            private readonly ProfesorRepository profesorRepository;

            // Constructor que recibe el contexto y crea el repositorio
            public ProfesoresOperation(ControlEscolarContext context)
            {
                profesorRepository = new ProfesorRepository(context);
            }

            public char CommandKey => '4';
            public string Description => "Gestionar Profesores";

            public void Execute()
            {
                Console.WriteLine("\n=== Gestión de Profesores ===");
                Console.WriteLine("1. Ver lista de profesores");
                Console.WriteLine("2. Agregar profesor");
                Console.WriteLine("3. Buscar profesor por matrícula");
                Console.Write("Seleccione una opción: ");

                var opcion = Console.ReadLine();

                switch (opcion)
                {
                case "1":
                    VerListaDeProfesores();
                    break;
                case "2":
                    AgregarProfesor();
                    break;
                case "3":
                    BuscarProfesorPorMatricula();
                    break;
                default:
                    Console.WriteLine("Opción no válida.");
                    break;
                }
            }

            private void VerListaDeProfesores()
            {
                var profesores = profesorRepository.ObtenerUsuarios();
                Console.WriteLine("\n=== Lista de Profesores ===");
                
                if (!profesores.Any())
                {
                Console.WriteLine("📭 No hay profesores registrados aún.");
                return;
                }

                foreach (var profesor in profesores)
                {
                Console.WriteLine(profesor.ToString());
                }
            }

            private void AgregarProfesor()
            {
                Console.WriteLine("\n=== Agregar Profesor ===");
                Console.Write("Ingrese el nombre del profesor: ");
                var nombre = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(nombre))
                {
                Console.WriteLine("❌ El nombre no puede estar vacío.");
                return;
                }

                // Crear un nuevo profesor con matrícula generada
                var nuevoProfesor = new Profesor(nombre);
               
                profesorRepository.AgregarUsuario(nuevoProfesor);
                Console.WriteLine("✅ Profesor agregado exitosamente.");
                Console.WriteLine($"📌 Matrícula generada: {nuevoProfesor.Matricula}");
            }

            private void BuscarProfesorPorMatricula()
            {
                Console.WriteLine("\n=== Buscar Profesor por Matrícula ===");
                Console.Write("Ingrese la matrícula del profesor: ");
                var matricula = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(matricula))
                {
                Console.WriteLine("❌ La matrícula no puede estar vacía.");
                return;
                }

                var profesor = profesorRepository.ObtenerUsuarioPorMatricula(matricula);

                if (profesor != null)
                {
                Console.WriteLine("✅ Profesor encontrado:");
                Console.WriteLine(profesor.ToString());
                }
                else
                {
                Console.WriteLine("❌ No se encontró ningún profesor con esa matrícula.");
                }
            }
        }
    }


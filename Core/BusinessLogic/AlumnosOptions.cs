using ControlEscolar.Core.Interfaces;
using ControlEscolar.Core.Usuarios;
using ControlEscolar.Data;
using System;
using System.Collections.Generic;

namespace ControlEscolar.Core.BusinessLogic;
public class AlumnosMenuState : IMenuState
{
    private readonly MenuContext _context;

    public AlumnosMenuState(MenuContext context)
    {
        _context = context;
    }

    public char CommandKey => '1';
    public string Description => "Gestión de Alumnos";

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("=== GESTIÓN DE ALUMNOS ===");
        Console.WriteLine("A. Agregar alumno");
        Console.WriteLine("L. Listar alumnos");
        Console.WriteLine("U. Actualizar alumno");
        Console.WriteLine("E. Eliminar alumno");
        Console.WriteLine("Q. Volver al menú principal");
    }

    public void HandleInput(MenuContext context)
    {
        var input = char.ToUpper(Console.ReadKey().KeyChar);
        
        switch (input)
        {
            case 'A':
                context.PushState(new AgregarAlumnoOperation(context.AlumnoRepository));
                break;
            case 'L':
                context.PushState(new ListarAlumnosOperation(context.AlumnoRepository));
                break;
            case 'U':
                context.PushState(new ActualizarAlumnoOperation(context.AlumnoRepository));
                break;
            case 'E':
                context.PushState(new EliminarAlumnoOperation(context.AlumnoRepository));
                break;
            case 'Q':
                context.PopState();
                break;
        }
    }
}

public class AgregarAlumnoOperation : IMenuState
{
    private readonly AlumnoRepository _repository;

    public AgregarAlumnoOperation(AlumnoRepository repository)
    {
        _repository = repository;
    }

    public void Display()
    {
        Console.Clear();
        Console.Write("Ingrese el nombre del alumno: ");
    }

    public void HandleInput(MenuContext context)
    {
        var nombre = Console.ReadLine();
        var alumno = Alumno.Crear(nombre);
        _repository.AgregarUsuario(alumno);
        Console.WriteLine("Alumno agregado. Presione cualquier tecla para continuar...");
        Console.ReadKey();
        context.PopState();
    }
}

public class ListarAlumnosOperation : IMenuState
{
    private readonly AlumnoRepository _repository;

    public ListarAlumnosOperation(AlumnoRepository repository)
    {
        _repository = repository;
    }

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("=== LISTA DE ALUMNOS ===");
        var alumnos = _repository.ObtenerUsuarios();
        foreach (var alumno in alumnos)
            Console.WriteLine(alumno);
        
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
    }

    public void HandleInput(MenuContext context)
    {
        Console.ReadKey();
        context.PopState();
    }
}
public class EliminarAlumnoOperation : IMenuState
{
    private readonly AlumnoRepository _alumnoRepository;

    public EliminarAlumnoOperation(AlumnoRepository alumnoRepository)
    {
        _alumnoRepository = alumnoRepository;
    }

    public void Display()
    {
        Console.Clear();
        Console.Write("Ingrese la matrícula del alumno a eliminar: ");
    }
    

    public void HandleInput(MenuContext context)
    {
        var matricula = Console.ReadLine();
        _alumnoRepository.EliminarUsuario(matricula);
        Console.WriteLine("Alumno eliminado exitosamente. Presione cualquier tecla para continuar...");
        Console.ReadKey();
        context.PopState();
    }
}

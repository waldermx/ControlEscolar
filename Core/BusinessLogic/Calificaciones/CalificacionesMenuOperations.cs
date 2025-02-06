using ControlEscolar.Core.Interfaces;
using ControlEscolar.Core.Entities;
using ControlEscolar.Core.Usuarios;
using ControlEscolar.Data;
namespace ControlEscolar.Core.BusinessLogic;

public class VerCalificacionesOperation : IOperation
{
    private readonly IRepository<Calificacion> _repository;

    public VerCalificacionesOperation(IRepository<Calificacion> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '1';
    public string Description => "Ver calificaciones por alumno";

    public void Execute()
    {
        Console.WriteLine("\nIngrese la matrícula del alumno:");
        string matricula = Console.ReadLine() ?? "";
        
        var calificacion = _repository.ObtenerUsuarioPorMatricula(matricula);
        
        if (calificacion != null)
        {
            Console.WriteLine(calificacion.ToString());
        }
        else
        {
            Console.WriteLine("No se encontraron calificaciones para esta matrícula.");
        }
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

public class RegistrarCalificacionOperation : IOperation
{
    private readonly IRepository<Calificacion> _repository;
    private readonly IRepository<Alumno> _alumnoRepository;
    private readonly IRepository<Materia> _materiaRepository;

    public RegistrarCalificacionOperation(
        IRepository<Calificacion> repository,
        IRepository<Alumno> alumnoRepository,
        IRepository<Materia> materiaRepository)
    {
        _repository = repository;
        _alumnoRepository = alumnoRepository;
        _materiaRepository = materiaRepository;
    }

    public char CommandKey => '2';
    public string Description => "Registrar calificación";
    public void Execute()
    {
        Console.WriteLine("\nRegistro de nueva calificación");
        
        Console.Write("Matrícula del alumno: ");
        var matricula = Console.ReadLine() ?? "";
        
        Console.Write("ID de la materia: ");
        if (!int.TryParse(Console.ReadLine(), out int materiaId))
        {
            Console.WriteLine("ID de materia inválido");
            return;
        }

        // Aquí deberías obtener el Alumno y Materia de sus respectivos repositorios
        var alumno = _alumnoRepository.ObtenerUsuarioPorMatricula(matricula);
        var materia = _materiaRepository.ObtenerUsuarioPorId(materiaId);
        
        if (alumno == null || materia == null)
        {
            Console.WriteLine("No se encontró el alumno o la materia especificada.");
            return;
        }

        Console.Write("Calificación: ");
        if (!decimal.TryParse(Console.ReadLine(), out decimal valor))
        {
            Console.WriteLine("Calificación inválida");
            return;
        }

        var calificacion = new Calificacion
        {
            Alumno = alumno,
            Materia = materia,
            Valor = valor
        };

        _repository.AgregarUsuario(calificacion);
        Console.WriteLine("Calificación registrada exitosamente.");
        
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
    }


public class ModificarCalificacionOperation : IOperation
{
    private readonly IRepository<Calificacion> _repository;

    public ModificarCalificacionOperation(IRepository<Calificacion> repository)
    {
        _repository = repository;
    }

    public char CommandKey => '3';
    public string Description => "Modificar calificación";

    public void Execute()
    {
        Console.WriteLine("\nModificación de calificación");
        
        Console.Write("Matrícula del alumno: ");
        string matricula = Console.ReadLine() ?? "";
        
        var calificacion = _repository.ObtenerUsuarioPorMatricula(matricula);
        
        if (calificacion == null)
        {
            Console.WriteLine("No se encontró la calificación para esta matrícula.");
            return;
        }

        Console.Write("Nueva calificación: ");
        if (decimal.TryParse(Console.ReadLine(), out decimal nuevoValor))
        {
            calificacion.Valor = nuevoValor;
            _repository.ActualizarUsuario(calificacion);
            Console.WriteLine("Calificación actualizada exitosamente.");
        }
        else
        {
            Console.WriteLine("Valor de calificación inválido.");
        }
        
        Console.WriteLine("\nPresione cualquier tecla para continuar...");
        Console.ReadKey();
    }
}

public class RegresarMenuPrincipalOperation : IOperation
{
    public char CommandKey => '0';
    public string Description => "Regresar al Menú Principal";

    public void Execute()
    {
        Console.WriteLine("\nRegresando al menú principal...");
        // No necesita implementación adicional ya que el control del menú
        // se manejará en la clase que gestiona los menús
    }
}
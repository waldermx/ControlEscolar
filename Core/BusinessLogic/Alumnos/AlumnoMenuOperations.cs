using ControlEscolar.Core.Interfaces;

public class AgregarAlumnoOperation : IMenuItem
{
    public char CommandKey => '1';
    public string Description => "Agregar Alumno";

    public void Execute()
    {
        // Logic to add a student
    }
}

public class ModificarAlumnoOperation : IMenuItem
{
    public char CommandKey => '2';
    public string Description => "Modificar Alumno";

    public void Execute()
    {
        // Logic to modify a student
    }
}

public class EliminarAlumnoOperation : IMenuItem
{
    public char CommandKey => '3';
    public string Description => "Eliminar Alumno";

    public void Execute()
    {
        // Logic to delete a student
    }
}

public class ListarAlumnosOperation : IMenuItem
{
    public char CommandKey => '4';
    public string Description => "Listar Alumnos";

    public void Execute()
    {
        // Logic to list students
    }
}

public class BuscarAlumnoOperation : IMenuItem
{
    public char CommandKey => '5';
    public string Description => "Buscar Alumno";

    public void Execute()
    {
        // Logic to search for a student
    }
}

public class RegresarMenuPrincipalOperation : IMenuItem
{
    public char CommandKey => '0';
    public string Description => "Regresar al Menú Principal";

    public void Execute()
    {
        // Logic to return to the main menu
    }
}
using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Core.BusinessLogic;

public class VerCalificacionesOperation : IMenuItem
{
    public char CommandKey => '1';
    public string Description => "Ver calificaciones por alumno";

    public void Execute()
    {
        // Logic to view student grades
    }
}

public class RegistrarCalificacionOperation : IMenuItem
{
    public char CommandKey => '2';
    public string Description => "Registrar calificación";

    public void Execute()
    {
        // Logic to register a grade
    }
}

public class ModificarCalificacionOperation : IMenuItem
{
    public char CommandKey => '3';
    public string Description => "Modificar calificación";

    public void Execute()
    {
        // Logic to modify a grade
    }
}

public class RegresarMenuPrincipalOperation : IMenuItem
{
    public char CommandKey => '0';
    public string Description => "Regresar al Menú Principal";

    public void Execute()
    {
        // Logic to return to main menu
    }
}
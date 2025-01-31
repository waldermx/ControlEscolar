namespace ControlEscolar.Algorithms;
public static class MatriculaGenerator
{
    private static int contador = 1000; // Solo para ejemplo, idealmente lo sacarías de la BD

    public static string GenerarMatricula(string tipo)
    {
        return $"{tipo.ToUpper()}{DateTime.Now:yyyy}{contador++}";
    }
}

using ControlEscolar.Core.BusinessLogic;
using ControlEscolar.Core.Interfaces;
using ControlEscolar.Infrastructure;


class Program
{
    public static void Main(string[] args)
    {
        // Configuración de DI (ejemplo simplificado)
        var alumnoRepo = new AlumnoRepository();
        var businessLogic = new ApplicationOptions();
        var mainLoop = new ConsoleMainLoop(businessLogic, alumnoRepo);

        mainLoop.Run();
    }
}
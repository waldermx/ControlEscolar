using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Infrastructure;
public class ConsoleMainLoop : IMainLoop
{
    private readonly MenuContext _context;

    public ConsoleMainLoop(IBusinessLogic businessLogic, AlumnoRepository alumnoRepository)
    {
        _context = new MenuContext(businessLogic, alumnoRepository);
    }

    public void Run()
    {
        while (true)
            _context.ShowMenu();
    }
}
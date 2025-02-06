using ControlEscolar.Core.Interfaces;
namespace ControlEscolar.Infrastructure;

public class ConsoleMainLoop : IMainLoop
{
    private readonly IMenu _menu;
    private bool _isRunning;

    public ConsoleMainLoop(IMenu menu)
    {
        _menu = menu;
    }

    public void Run()
    {
        _isRunning = true;

        while (_isRunning)
        {
            Console.Clear();
            _menu.Display();
            var input = Console.ReadKey();
            
            if (char.ToLower(input.KeyChar) == 'q')
            {
                _isRunning = false;
            }
            else
            {
                _menu.HandleOption(input.KeyChar);
                Console.ReadKey();
            }
        }

        Console.WriteLine("\n ¡Hasta luego!");
    }
}
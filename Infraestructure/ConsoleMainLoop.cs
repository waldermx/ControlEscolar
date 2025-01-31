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
            _menu.Display();
            var input = Console.ReadKey();
            
            if (char.ToLower(input.KeyChar) == 'q')
            {
                _isRunning = false;
            }
            else
            {
                _menu.HandleOption(input.KeyChar);
            }
        }

        Console.WriteLine("\n ¡Hasta luego!");
    }
}
using ControlEscolar.Core.BusinessLogic;
using ControlEscolar.Core.Interfaces;
using ControlEscolar.Infrastructure;



class Program
{
    static void Main(string[] args)
    {
        IBusinessLogic businessLogic = new ApplicationOptions();
        IMenu Menu = new ConsoleMenu(businessLogic);
        var mainLoop = new ConsoleMainLoop(Menu);
        mainLoop.Run();
    }
}
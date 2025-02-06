using ControlEscolar.Core.BusinessLogic;
using ControlEscolar.Core.Interfaces;
using ControlEscolar.Infrastructure;



var businessLogic = new ApplicationOptions();
var mainMenu = new ConsoleMenu(businessLogic);

while (true) // Loop principal para mantener el menú activo
{
    Console.Clear();
    Console.WriteLine("MENÚ PRINCIPAL");
    mainMenu.Display();
    
    Console.Write("\nSeleccione una opción: ");
    var input = Console.ReadKey().KeyChar;
    Console.WriteLine(); // Salto de línea
    
    mainMenu.HandleOption(input);

    Console.WriteLine("\nPresione cualquier tecla para continuar...");
    Console.ReadKey();
}
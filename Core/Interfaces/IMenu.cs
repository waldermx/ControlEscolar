
using ControlEscolar.Core.Interfaces;
using ControlEscolar.EntityClasses;
using ControlEscolar.Data;

namespace ControlEscolar.Core.Interfaces;
    // Interfaz para los estados del menú
    public interface IMenuState
    {
        void Display();
        void HandleInput(MenuContext context);
    }

    // Interfaz modificada para operaciones (ahora son estados)
    public interface IOperation : IMenuState
    {
        char CommandKey { get; }
        string Description { get; }
    }

    // Contexto que maneja el estado actual del menú
 public class MenuContext
{
    private Stack<IMenuState> _stateStack = new Stack<IMenuState>();

    public IBusinessLogic BusinessLogic { get; }
    public AlumnoRepository AlumnoRepository { get; } // Inyectar repositorio

    public MenuContext(IBusinessLogic businessLogic, AlumnoRepository alumnoRepository)
    {
        BusinessLogic = businessLogic;
        AlumnoRepository = alumnoRepository;
        _stateStack.Push(new MainMenuState(this));
    }

    public void PushState(IMenuState newState) => _stateStack.Push(newState);
    public void PopState() { if (_stateStack.Count > 1) _stateStack.Pop(); }
    
    public void ShowMenu()
    {
        _stateStack.Peek().Display();
        _stateStack.Peek().HandleInput(this);
    }
}
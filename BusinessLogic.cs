using ControlEscolar.Core.Interfaces;

namespace ControlEscolar.Core.BusinessLogic;

public interface IMenuItem
{
    char CommandKey { get; }
    string Description { get; } 
    void Execute();
}

public class BusinessLogic : IBusinessLogic
{
    private readonly IEnumerable<IMenuItem> _menuItems;

    public BusinessLogic(IEnumerable<IMenuItem> menuItems)
    {
        _menuItems = menuItems ?? throw new ArgumentNullException(nameof(menuItems));
    }

    public IEnumerable<IOperation> GetAvailableOperations()
    {
        return _menuItems.OfType<IOperation>();
    }
}
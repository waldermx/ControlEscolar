namespace ControlEscolar.Core.Interfaces;
public interface IMenu : IMenuItem
{
    void Display();
    void HandleOption(char option);
}
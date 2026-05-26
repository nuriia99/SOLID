namespace SolidAppConsole.Models;

/// <summary>
/// Interface Segregation Principle (ISP)
/// Clients should not depend on interfaces they do not use.
/// </summary>
public interface ISOLIDPrinciple
{
    string Name { get; }
    string Letter { get; }
    void Display();
}

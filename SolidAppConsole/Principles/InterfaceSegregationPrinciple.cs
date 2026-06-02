namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;
using SolidAppConsole.Services;

/// <summary>
/// Interface Segregation Principle (ISP)
/// Clients should not depend on interfaces they do not use.
/// </summary>
public class InterfaceSegregationPrinciple : ISOLIDPrinciple
{
    public string Name => "Interface Segregation Principle (ISP)";
    public string Letter => "I";

    public void Display()
    {
        Console.Clear();
        ContentLoader.PrintContent("InterfaceSegregationPrinciple");
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

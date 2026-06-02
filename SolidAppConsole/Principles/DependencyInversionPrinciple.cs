namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;
using SolidAppConsole.Services;

/// <summary>
/// Dependency Inversion Principle (DIP)
/// Depend on abstractions, not on concrete implementations.
/// </summary>
public class DependencyInversionPrinciple : ISOLIDPrinciple
{
    public string Name => "Dependency Inversion Principle (DIP)";
    public string Letter => "D";

    public void Display()
    {
        Console.Clear();
        ContentLoader.PrintContent("DependencyInversionPrinciple");
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

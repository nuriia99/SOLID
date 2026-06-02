namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;
using SolidAppConsole.Services;

/// <summary>
/// Single Responsibility Principle (SRP)
/// A class should have one, and only one, reason to change.
/// </summary>
public class SingleResponsibilityPrinciple : ISOLIDPrinciple
{
    public string Name => "Single Responsibility Principle (SRP)";
    public string Letter => "S";

    public void Display()
    {
        Console.Clear();
        ContentLoader.PrintContent("SingleResponsibilityPrinciple");
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

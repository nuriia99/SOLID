namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;
using SolidAppConsole.Services;

/// <summary>
/// Liskov Substitution Principle (LSP)
/// Objects of derived classes must be replaceable with objects of the base class.
/// </summary>
public class LiskovSubstitutionPrinciple : ISOLIDPrinciple
{
    public string Name => "Liskov Substitution Principle (LSP)";
    public string Letter => "L";

    public void Display()
    {
        Console.Clear();
        ContentLoader.PrintContent("LiskovSubstitutionPrinciple");
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

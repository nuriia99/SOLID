namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;
using SolidAppConsole.Services;

/// <summary>
/// Open/Closed Principle (OCP)
/// Classes should be OPEN for extension, but CLOSED for modification.
/// </summary>
public class OpenClosedPrinciple : ISOLIDPrinciple
{
    public string Name => "Open/Closed Principle (OCP)";
    public string Letter => "O";

    public void Display()
    {
        Console.Clear();
        ContentLoader.PrintContent("OpenClosedPrinciple");
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

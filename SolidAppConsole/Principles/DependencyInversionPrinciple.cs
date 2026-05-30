namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;

/// <summary>
/// Dependency Inversion Principle (DIP)
/// Depend on abstractions, not on concrete implementations.
/// </summary>
public class DependencyInversionPrinciple : ISOLIDPrinciple
{
    public string Name => "Dependency Inversion Principle";
    public string Letter => "D";

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"{Letter} - {Name.ToUpper()}");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

        Console.WriteLine("📋 DEFINITION:");
        Console.WriteLine("States that high-level modules should not depend on low-level modules.");
        Console.WriteLine("Instead, both should depend on abstractions.\n");

        Console.WriteLine("💡 BENEFITS:");
        Console.WriteLine("  • Low coupling");
        Console.WriteLine("  • Easy to test");
        Console.WriteLine("  • Flexible and extensible \n");

        Console.WriteLine("💡 DIP vs. Dependency Injection (DI):");
        Console.WriteLine("Dependency injection is a design pattern. The class should not be responsible for creating");
        Console.WriteLine("its dependencies. Instead, shifts the creation responsibility to another class \n");

        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

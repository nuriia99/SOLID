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
        Console.WriteLine("Depend on abstractions, not on concrete implementations.\n");
        
        Console.WriteLine("❌ BAD - Dependency on concrete classes:");
        Console.WriteLine("  class Car");
        Console.WriteLine("  {");
        Console.WriteLine("    private GasolineEngine engine = new GasolineEngine();");
        Console.WriteLine("    // Tightly coupled - I cannot change the engine");
        Console.WriteLine("  }\n");
        
        Console.WriteLine("✅ GOOD - Dependency injection:");
        Console.WriteLine("  interface IEngine { void Start(); }");
        Console.WriteLine("  class GasolineEngine : IEngine { }");
        Console.WriteLine("  class ElectricEngine : IEngine { }");
        Console.WriteLine("  class Car");
        Console.WriteLine("  {");
        Console.WriteLine("    private IEngine engine;");
        Console.WriteLine("    public Car(IEngine injectedEngine) => engine = injectedEngine;");
        Console.WriteLine("  }\n");
        
        Console.WriteLine("💡 BENEFITS:");
        Console.WriteLine("  • Low coupling");
        Console.WriteLine("  • Easy to test");
        Console.WriteLine("  • Flexible and extensible");
        
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

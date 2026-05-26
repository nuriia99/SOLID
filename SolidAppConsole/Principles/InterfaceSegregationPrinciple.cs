namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;

/// <summary>
/// Interface Segregation Principle (ISP)
/// Clients should not depend on interfaces they do not use.
/// </summary>
public class InterfaceSegregationPrinciple : ISOLIDPrinciple
{
    public string Name => "Interface Segregation Principle";
    public string Letter => "I";

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"{Letter} - {Name.ToUpper()}");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        Console.WriteLine("📋 DEFINITION:");
        Console.WriteLine("Clients should not depend on interfaces they do not use.\n");
        
        Console.WriteLine("❌ BAD - One large interface:");
        Console.WriteLine("  interface IWorker");
        Console.WriteLine("  {");
        Console.WriteLine("    void Work();");
        Console.WriteLine("    void Eat();");
        Console.WriteLine("    void Sleep();");
        Console.WriteLine("    void Code(); // Managers don't code");
        Console.WriteLine("  }\n");
        
        Console.WriteLine("✅ GOOD - Small, specific interfaces:");
        Console.WriteLine("  interface IEmployee { void Work(); }");
        Console.WriteLine("  interface IProgrammer { void Code(); }");
        Console.WriteLine("  interface IHuman { void Eat(); void Sleep(); }");
        Console.WriteLine("  class Programmer : IEmployee, IProgrammer, IHuman { }\n");
        
        Console.WriteLine("💡 BENEFITS:");
        Console.WriteLine("  • Cleaner interfaces");
        Console.WriteLine("  • Less coupling");
        Console.WriteLine("  • Greater flexibility");
        
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

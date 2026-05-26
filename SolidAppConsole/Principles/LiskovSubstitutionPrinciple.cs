namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;

/// <summary>
/// Liskov Substitution Principle (LSP)
/// Objects of derived classes must be replaceable with objects of the base class.
/// </summary>
public class LiskovSubstitutionPrinciple : ISOLIDPrinciple
{
    public string Name => "Liskov Substitution Principle";
    public string Letter => "L";

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"{Letter} - {Name.ToUpper()}");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        Console.WriteLine("📋 DEFINITION:");
        Console.WriteLine("Objects of derived classes must be replaceable with");
        Console.WriteLine("objects of the base class without breaking the application.\n");
        
        Console.WriteLine("❌ BAD - Inconsistent behavior:");
        Console.WriteLine("  class Animal { public virtual void Fly() { } }");
        Console.WriteLine("  class Bird : Animal { }");
        Console.WriteLine("  class Penguin : Animal");
        Console.WriteLine("  {");
        Console.WriteLine("    public override void Fly() { throw new Exception(); }");
        Console.WriteLine("    // Penguins cannot fly!");
        Console.WriteLine("  }\n");
        
        Console.WriteLine("✅ GOOD - Correct hierarchy:");
        Console.WriteLine("  abstract class Animal { }");
        Console.WriteLine("  abstract class Bird : Animal { public abstract void Fly(); }");
        Console.WriteLine("  class Eagle : Bird { public override void Fly() { } }");
        Console.WriteLine("  class Penguin : Animal { public void Swim() { } }\n");
        
        Console.WriteLine("💡 BENEFITS:");
        Console.WriteLine("  • Correct inheritance hierarchies");
        Console.WriteLine("  • Predictable code");
        Console.WriteLine("  • Fewer unexpected exceptions");
        
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

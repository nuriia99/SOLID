namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;

/// <summary>
/// Open/Closed Principle (OCP)
/// Classes should be OPEN for extension, but CLOSED for modification.
/// </summary>
public class OpenClosedPrinciple : ISOLIDPrinciple
{
    public string Name => "Open/Closed Principle";
    public string Letter => "O";

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"{Letter} - {Name.ToUpper()}");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        Console.WriteLine("📋 DEFINITION:");
        Console.WriteLine("Classes should be OPEN for extension,");
        Console.WriteLine("but CLOSED for modification.\n");
        
        Console.WriteLine("❌ BAD - Modifying existing code:");
        Console.WriteLine("  class DiscountCalculator");
        Console.WriteLine("  {");
        Console.WriteLine("    public decimal Calculate(int type)");
        Console.WriteLine("    {");
        Console.WriteLine("      if (type == 1) return 0.10m;");
        Console.WriteLine("      if (type == 2) return 0.20m;");
        Console.WriteLine("      // Adding new types = modifying the class");
        Console.WriteLine("    }");
        Console.WriteLine("  }\n");
        
        Console.WriteLine("✅ GOOD - Use inheritance/interfaces:");
        Console.WriteLine("  interface IDiscount { decimal Calculate(); }");
        Console.WriteLine("  class PercentageDiscount : IDiscount { }");
        Console.WriteLine("  class FixedDiscount : IDiscount { }");
        Console.WriteLine("  // New discounts without modifying existing code\n");
        
        Console.WriteLine("💡 BENEFITS:");
        Console.WriteLine("  • More flexible code");
        Console.WriteLine("  • Less error prone");
        Console.WriteLine("  • Extensible without risks");
        
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

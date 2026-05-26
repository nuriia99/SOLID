namespace SolidAppConsole.Principles;

using SolidAppConsole.Models;

/// <summary>
/// Single Responsibility Principle (SRP)
/// A class should have one, and only one, reason to change.
/// </summary>
public class SingleResponsibilityPrinciple : ISOLIDPrinciple
{
    public string Name => "Single Responsibility Principle";
    public string Letter => "S";

    public void Display()
    {
        Console.Clear();
        Console.WriteLine("═══════════════════════════════════════════════════════════════");
        Console.WriteLine($"{Letter} - {Name.ToUpper()}");
        Console.WriteLine("═══════════════════════════════════════════════════════════════\n");
        
        Console.WriteLine("📋 DEFINITION:");
        Console.WriteLine("A class should have one, and only one, reason to change.");
        Console.WriteLine("Each class should have a single responsibility.\n");
        
        Console.WriteLine("❌ BAD - Multiple responsibilities:");
        Console.WriteLine("  class User");
        Console.WriteLine("  {");
        Console.WriteLine("    public void SaveToDatabase() { }    // Responsibility 1");
        Console.WriteLine("    public void SendEmail() { }          // Responsibility 2");
        Console.WriteLine("    public void GenerateReport() { }     // Responsibility 3");
        Console.WriteLine("  }\n");
        
        Console.WriteLine("✅ GOOD - One responsibility per class:");
        Console.WriteLine("  class User { }");
        Console.WriteLine("  class UserRepository { public void Save(User u) { } }");
        Console.WriteLine("  class EmailService { public void Send(string email) { } }");
        Console.WriteLine("  class ReportGenerator { public void Generate() { } }\n");
        
        Console.WriteLine("💡 BENEFITS:");
        Console.WriteLine("  • More maintainable code");
        Console.WriteLine("  • More reusable classes");
        Console.WriteLine("  • Easier unit testing");
        
        PauseMenu();
    }

    private static void PauseMenu()
    {
        Console.WriteLine("\nPress any key to return to menu...");
        Console.ReadKey();
    }
}

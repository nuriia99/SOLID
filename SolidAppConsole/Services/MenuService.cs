namespace SolidAppConsole.Services;

/// <summary>
/// Single Responsibility Principle: Only responsible for displaying and handling menu logic
/// Dependency Inversion: Depends on PrincipleRegistry abstraction
/// </summary>
public class MenuService(PrincipleRegistry registry)
{
  private int _selectedOption = 0;

  private static void ClearConsoleCompletely()
  {
    try
    {
      System.Diagnostics.Process.Start("clear")?.WaitForExit();
    }
    catch
    {
      Console.Clear();
    }
  }

  public void Run()
  {
    bool exit = false;

    while (!exit)
    {
      DisplayMainMenu();
      exit = HandleMenuNavigation();
    }
  }

  private void DisplayMainMenu()
  {
    ClearConsoleCompletely();
    Console.WriteLine("╔════════════════════════════════════════╗");
    Console.WriteLine("║     SOLID PRINCIPLES IN C#             ║");
    Console.WriteLine("╚════════════════════════════════════════╝\n");

    Console.WriteLine("Choose which SOLID principle you want to learn:");
    Console.WriteLine("(Use ↑/↓ arrow keys to navigate, Enter to select, Esc to exit)\n");

    var principles = registry.GetAll();
    int totalOptions = principles.Count + 2;

    if (_selectedOption >= totalOptions)
      _selectedOption = 0;

    for (int i = 0; i < principles.Count; i++)
    {
      string prefix = _selectedOption == i ? ">> " : "   ";
      Console.WriteLine($"{prefix}{i + 1}. {principles[i].Letter} - {principles[i].Name}");
    }

    string viewAllPrefix = _selectedOption == principles.Count ? ">> " : "   ";
    Console.WriteLine($"{viewAllPrefix}{principles.Count + 1}. View all principles");

    string exitPrefix = _selectedOption == principles.Count + 1 ? ">> " : "   ";
    Console.WriteLine($"{exitPrefix}0. Exit\n");
  }

  private bool HandleMenuNavigation()
  {
    var principles = registry.GetAll();
    int totalOptions = principles.Count + 2;

    while (true)
    {
      var key = Console.ReadKey(intercept: true);

      switch (key.Key)
      {
        case ConsoleKey.UpArrow:
          _selectedOption = (_selectedOption - 1 + totalOptions) % totalOptions;
          return false;

        case ConsoleKey.DownArrow:
          _selectedOption = (_selectedOption + 1) % totalOptions;
          return false;

        case ConsoleKey.Enter:
          return ExecuteSelectedOption();

        case ConsoleKey.Escape:
          ClearConsoleCompletely();
          Console.WriteLine("\nGoodbye!");
          return true;

        default:
          continue;
      }
    }
  }

  private bool ExecuteSelectedOption()
  {
    var principles = registry.GetAll();
    int lastPrincipleIndex = principles.Count - 1;

    if (_selectedOption <= lastPrincipleIndex)
    {
      DisplayPrinciple(_selectedOption);
      return false;
    }
    else if (_selectedOption == principles.Count)
    {
      DisplayAllPrinciples();
      return false;
    }
    else if (_selectedOption == principles.Count + 1)
    {
      ClearConsoleCompletely();
      Console.WriteLine("\nGoodbye!");
      return true;
    }

    return false;
  }

  private void DisplayPrinciple(int index)
  {
    ClearConsoleCompletely();
    var principle = registry.GetByIndex(index);
    principle?.Display();
    _selectedOption = 0;
  }

  private void DisplayAllPrinciples()
  {
    ClearConsoleCompletely();
    Console.WriteLine("═══════════════════════════════════════════════════════════════");
    Console.WriteLine("SUMMARY OF THE 5 SOLID PRINCIPLES");
    Console.WriteLine("═══════════════════════════════════════════════════════════════\n");

    foreach (var principle in registry.GetAll())
    {
      Console.WriteLine($"{principle.Letter} - {principle.Name}");
      Console.WriteLine();
    }

    Console.WriteLine("═══════════════════════════════════════════════════════════════");
    Console.WriteLine("\nPress any key to return to menu...");
    Console.ReadKey();
    _selectedOption = 0;
  }
}

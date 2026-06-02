using SolidAppConsole.Services;
using System.Diagnostics;
using System.Reflection;


// Detectar si ya estamos dentro de Windows Terminal
bool isWindowsTerminal = Environment.GetEnvironmentVariable("WT_SESSION") != null;

// Invertir dependencia: crear IRuntimeLauncher concreto aquí
IRuntimeLauncher launcher = new RuntimeLauncher();

if (!isWindowsTerminal)
{
    if (launcher.TryLaunchExternal(out var msg))
    {
        // Se lanzó una instancia externa correctamente, terminar la actual
        return;
    }
    else if (!string.IsNullOrEmpty(msg))
    {
        Console.Error.WriteLine("No se pudo abrir terminal externa: " + msg);
    }
}

// Continuar ejecución en el proceso actual
Console.OutputEncoding = System.Text.Encoding.UTF8;

var registry = new PrincipleRegistry();
var menuService = new MenuService(registry);

ContentLoader.DiagnoseEncodings();
menuService.Run();

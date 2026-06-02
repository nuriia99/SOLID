namespace SolidAppConsole.Services;

using System.Diagnostics;
using System.IO;

public class RuntimeLauncher : IRuntimeLauncher
{
    public bool TryLaunchExternal(out string? message)
    {
        message = null;

        var entry = System.Reflection.Assembly.GetEntryAssembly()?.Location ?? Process.GetCurrentProcess().MainModule?.FileName;
        if (string.IsNullOrEmpty(entry))
        {
            message = "Entry assembly path not found.";
            return false;
        }

        var dir = Path.GetDirectoryName(entry) ?? Directory.GetCurrentDirectory();
        var baseName = Path.GetFileNameWithoutExtension(entry);
        var dllPath = Path.Combine(dir, baseName + ".dll");

        // Construir comando preferible: dotnet <dll> si existe
        string command = File.Exists(dllPath) ? $"dotnet \"{dllPath}\"" : $"\"{entry}\"";

        try
        {
            // Intentar Windows Terminal (wt.exe) primero
            var wtPsi = new ProcessStartInfo
            {
                FileName = "wt.exe",
                Arguments = $"cmd /k {command}",
                UseShellExecute = true
            };
            var p = Process.Start(wtPsi);
            if (p != null)
                return true;
        }
        catch (FileNotFoundException fnf)
        {
            message = "Windows Terminal (wt.exe) no encontrado: " + fnf.Message;
            Console.Error.WriteLine(message);
        }
        catch (System.ComponentModel.Win32Exception wex)
        {
            message = "No se pudo iniciar Windows Terminal: " + wex.Message;
            Console.Error.WriteLine(message);
        }
        catch (Exception ex)
        {
            message = "Error lanzando WT: " + ex.Message;
            Console.Error.WriteLine(ex.ToString());
        }

        // Fallback: intentar ejecutar dotnet <dll> o el exe directamente
        try
        {
            if (File.Exists(dllPath))
            {
                var psi = new ProcessStartInfo
                {
                    FileName = "dotnet",
                    Arguments = $"\"{dllPath}\"",
                    UseShellExecute = true,
                    WorkingDirectory = dir
                };
                var p2 = Process.Start(psi);
                if (p2 != null)
                    return true;
            }

            var psi2 = new ProcessStartInfo
            {
                FileName = entry,
                UseShellExecute = true,
                WorkingDirectory = dir
            };
            var p3 = Process.Start(psi2);
            if (p3 != null)
                return true;
        }
        catch (Exception ex)
        {
            message = "Fallback launch failed: " + ex.Message;
            Console.Error.WriteLine(ex.ToString());
        }

        return false;
    }
}

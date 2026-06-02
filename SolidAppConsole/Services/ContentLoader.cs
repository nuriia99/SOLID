namespace SolidAppConsole.Services;

using System.IO;
using System.Text;
using System.Diagnostics;

public static class ContentLoader
{
    public static void PrintContent(string key)
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;

            var contentDir = FindContentDirectory();
            if (contentDir == null)
            {
                Console.WriteLine("Content directory not found (searched common locations).\n");
                return;
            }

            var path = Path.Combine(contentDir, key + ".txt");

            Console.WriteLine($"Loading content from: {path}");

            if (!File.Exists(path))
            {
                Console.WriteLine($"Content file not found: {path}");
                return;
            }

            var lines = File.ReadAllLines(path, Encoding.UTF8);
            if (lines.Length == 0)
            {
                var fi = new FileInfo(path);
                Console.WriteLine($"Warning: file found but empty (size={fi.Length} bytes).\n");
            }
            foreach (var line in lines)
                Console.WriteLine(line);
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error loading content: " + ex.Message);
        }

    }

    private static string? FindContentDirectory()
    {
        string[] candidates = new[]
        {
            Path.Combine(Directory.GetCurrentDirectory(), "Content"),
            Path.Combine(AppContext.BaseDirectory ?? Directory.GetCurrentDirectory(), "Content"),
            Path.Combine(Path.GetDirectoryName(Process.GetCurrentProcess().MainModule?.FileName ?? "") ?? "", "Content")
        };

        foreach (var c in candidates)
        {
            if (!string.IsNullOrEmpty(c) && Directory.Exists(c))
                return c;
        }

        // Intentar subir carpetas padres desde AppContext.BaseDirectory
        var dir = AppContext.BaseDirectory ?? Directory.GetCurrentDirectory();
        var di = new DirectoryInfo(dir);
        for (int i = 0; i < 5 && di.Parent != null; i++)
        {
            di = di.Parent;
            var p = Path.Combine(di.FullName, "Content");
            if (Directory.Exists(p))
                return p;
        }

        return null;
    }

    public static void DiagnoseEncodings()
    {
        try
        {
            Console.OutputEncoding = Encoding.UTF8;
            var dir = FindContentDirectory();

            if (dir == null)
            {
                Console.WriteLine("Content directory not found for diagnosis.\n");
                return;
            }

            if (!Directory.Exists(dir))
            {
                Console.WriteLine("Content directory not found: " + dir);
                return;
            }

            Console.WriteLine("Encoding diagnosis for Content/*.txt:");

            var files = Directory.GetFiles(dir, "*.txt");
            foreach (var f in files)
            {
                var fi = new FileInfo(f);
                Console.WriteLine($" - {Path.GetFileName(f)}: {fi.Length} bytes");
            }

            Console.WriteLine();
        }
        catch (Exception ex)
        {
            Console.WriteLine("Error diagnosing encodings: " + ex.Message);
        }
    }


}

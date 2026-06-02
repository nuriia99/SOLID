namespace SolidAppConsole.Services;

/// <summary>
/// Responsabilidad: lanzar la aplicación en una consola externa cuando procede.
/// Interfaz para permitir inversión de dependencias y facilitar pruebas.
/// </summary>
public interface IRuntimeLauncher
{
    /// <summary>
    /// Intenta relanzar la aplicación en una consola externa (Windows Terminal o similar).
    /// Devuelve true si se lanzó una nueva instancia y la actual puede terminar.
    /// </summary>
    bool TryLaunchExternal(out string? message);
}

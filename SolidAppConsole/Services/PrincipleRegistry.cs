namespace SolidAppConsole.Services;

using SolidAppConsole.Models;
using SolidAppConsole.Principles;

/// <summary>
/// Principle Registry Service
/// Open/Closed Principle: Open for extension (add new principles), closed for modification
/// Single Responsibility: Only manages the registry of principles
/// </summary>
public class PrincipleRegistry
{
    private readonly List<ISOLIDPrinciple> _principles;

    public PrincipleRegistry()
    {
        _principles =
        [
            new SingleResponsibilityPrinciple(),
            new OpenClosedPrinciple(),
            new LiskovSubstitutionPrinciple(),
            new InterfaceSegregationPrinciple(),
            new DependencyInversionPrinciple()
        ];
    }

    public IReadOnlyList<ISOLIDPrinciple> GetAll() => _principles.AsReadOnly();

    public ISOLIDPrinciple? GetByIndex(int index)
    {
        if (index >= 0 && index < _principles.Count)
            return _principles[index];

        return null;
    }

    public int Count => _principles.Count;
}

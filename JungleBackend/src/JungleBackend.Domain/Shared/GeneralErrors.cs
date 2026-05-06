namespace JungleBackend.Domain.Shared;

public static class GeneralErrors
{
    public static Error ValueIsInvalid(string? field, string message)
    {
        string label = field ?? "value";
        return Error.Validation($"{label} is invalid", [$"{message}"], $"{field}");
    }

    public static Error ValueIsRequired(string? field)
    {
        string label = field ?? "value";
        return Error.Validation($"{label} is required", [$"{field} required"], $"{field}");
    }
}
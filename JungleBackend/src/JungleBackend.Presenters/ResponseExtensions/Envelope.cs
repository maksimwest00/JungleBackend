using JungleBackend.Domain.Shared;

namespace JungleBackend.Presenters.ResponseExtensions;

public record Envelope
{
    private Envelope(
        object? result,
        Errors errors)
    {
        Result = result;
        Errors = errors;
        TimeGenerated = DateTime.UtcNow;
    }

    public DateTime TimeGenerated { get; }

    public object? Result { get; }

    public Errors Errors { get; }

    public static Envelope Ok(object? result = null) =>
        new(result, new Errors([]));

    public static Envelope Error(Error error) => new(null, error.ToErrors());
}
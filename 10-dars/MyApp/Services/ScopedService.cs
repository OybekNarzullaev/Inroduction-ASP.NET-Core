namespace MyApp.Services;

public interface IScopedService
{
    string GetGuid();
}

public class ScopedService : IScopedService
{
    private readonly Guid _guid;
    public ScopedService()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return $"Scoped GUID: {_guid}";
    }
}

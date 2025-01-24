namespace MyApp.Services;

public interface ISingletonService
{
    string GetGuid();
}

public class SingletonService : ISingletonService
{
    private readonly Guid _guid;
    public SingletonService()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return $"Singleton GUID: {_guid}";
    }
}

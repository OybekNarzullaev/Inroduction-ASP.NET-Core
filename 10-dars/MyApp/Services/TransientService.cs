namespace MyApp.Services;


public interface ITransientService
{
    string GetGuid();
}

public class TransientService : ITransientService
{
    private readonly Guid _guid;
    public TransientService()
    {
        _guid = Guid.NewGuid();
    }

    public string GetGuid()
    {
        return $"Transient GUID: {_guid}";
    }
}

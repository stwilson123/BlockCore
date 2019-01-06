namespace BlocksCore.Abstractions.Configuration
{
    public interface IAppConfigAccessor
    {
        string GetSettings(string name);
    }
}

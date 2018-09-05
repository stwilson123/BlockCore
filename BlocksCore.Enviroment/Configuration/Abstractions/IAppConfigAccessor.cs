namespace BlocksCore.Enviroment.Configuration.Abstractions
{
    public interface IAppConfigAccessor
    {
        string GetSettings(string name);
    }
}

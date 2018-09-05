namespace BlocksCore.Enviroment.Extensions.Abstractions.Features
{
    public interface IFeatureInfo
    {
        string Id { get; }
        string Name { get; }
        int Priority { get; }
        string Description { get; }
        IModuleInfo ModuleInfo  { get; }
        string[] Dependencies { get; }
    }
}
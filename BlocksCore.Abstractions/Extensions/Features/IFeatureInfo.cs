namespace BlocksCore.Abstractions.Extensions.Features
{
    public interface IFeatureInfo
    {
        string Id { get; }
        string Name { get; }
        string Priority { get; }
        string Description { get; }
        IModuleInfo ModuleInfo  { get; }
        string[] Dependencies { get; }
    }
}
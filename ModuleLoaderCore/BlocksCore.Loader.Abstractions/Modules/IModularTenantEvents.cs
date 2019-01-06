using System.Threading.Tasks;

namespace BlocksCore.Loader.Abstractions.Modules
{
    public interface IModularTenantEvents
    {
        Task ActivatingAsync();
        Task ActivatedAsync();
        Task TerminatingAsync();
        Task TerminatedAsync();
    }
}
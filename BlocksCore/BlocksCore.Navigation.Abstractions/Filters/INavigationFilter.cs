using System.Collections.Generic;
using System.Threading.Tasks;

namespace BlocksCore.Navigation.Abstractions.Filters
{
    public interface INavigationFilter
    {
        Task<IEnumerable<INavigationDefinition>> Filter(IEnumerable<INavigationDefinition> navigationDefinitions);
    }
}
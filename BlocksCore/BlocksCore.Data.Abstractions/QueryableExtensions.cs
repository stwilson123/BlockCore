using System.Linq;
using System.Threading.Tasks;

namespace BlocksCore.Data.Abstractions
{
    public static class QueryableExtensions
    {
        public static Task<T> FirstOrDefaultAsync<T>(this IQueryable<T> queryable) where T : class
        {

            return Task.Factory.StartNew(() => queryable.FirstOrDefault());
        }
        
    }
}
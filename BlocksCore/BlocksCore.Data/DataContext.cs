using System;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;
using BlocksCore.Data.Abstractions;
using BlocksCore.Loader.Abstractions.Modules.Extensions;
using Microsoft.EntityFrameworkCore;

namespace BlocksCore.Data
{
    public class DataContext : IDataContext
    {
        private readonly DbContext _dbContext;

        public DataContext(DbContext dbContext)
        {
            _dbContext = dbContext;
        }
        
        

        public IQueryable<TSource> Query<TSource>(params Expression<Func<TSource, object>>[] includingExpressions) where TSource : class
        {
            IQueryable<TSource> queryable = _dbContext.Set<TSource>();

            foreach (var includingExpression in includingExpressions)
            {
                queryable = queryable.Include(includingExpression);
            }
         
            return queryable;
        }

        public void Save(object obj)
        {
            _dbContext.Add(obj);
        }

        public void Delete(object obj)
        {
            throw new System.NotImplementedException();
        }
    }
}
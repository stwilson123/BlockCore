using System;
using System.Linq;
using System.Linq.Expressions;

namespace BlocksCore.Data.Abstractions
{
    public interface IDataContext
    {


        IQueryable<TSource> Query<TSource>(params Expression<Func<TSource, object>>[] includingExpressions) where TSource : class;
        
        
        void Save(object obj);


        void Delete(object obj);
    }
}
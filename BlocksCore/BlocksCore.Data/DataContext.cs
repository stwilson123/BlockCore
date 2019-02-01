using System.Linq;
using BlocksCore.Data.Abstractions;
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
        
        

        public IQueryable<T> Query<T>() where T : class
        {
            return _dbContext.Query<T>();
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
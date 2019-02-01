using System.Linq;

namespace BlocksCore.Data.Abstractions
{
    public interface IDataContext
    {


        IQueryable<T> Query<T>() where T : class;
        
        void Save(object obj);


        void Delete(object obj);
    }
}
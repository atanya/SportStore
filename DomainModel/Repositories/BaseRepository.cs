using System.Data.Entity;
using DomainModel.Abstract;

namespace DomainModel.Repositories
{
    public abstract class BaseRepository<T>: IBaseRepository<T> where T:class
    {
        internal readonly DbContext Context;

        internal BaseRepository(DbContext dbContext)
        {
            Context = dbContext;
        }
    }
}

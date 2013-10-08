using System.Data.Entity;
using DomainModel.Interfaces;

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

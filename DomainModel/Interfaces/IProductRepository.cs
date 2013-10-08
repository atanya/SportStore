using System.Linq;
using DomainModel.DAL;

namespace DomainModel.Interfaces
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}

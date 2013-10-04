using System.Linq;
using DomainModel.DAL;

namespace DomainModel.Abstract
{
    public interface IProductRepository
    {
        IQueryable<Product> Products { get; }
    }
}

using System.Collections.Generic;
using System.Linq;
using DomainModel.Abstract;
using DomainModel.DAL;

namespace DomainModel.Repositories
{
    public class ProductRepository: IProductRepository
    {
        public IQueryable<Product> Products
        {
            get { return new List<Product> {new Product {Name = "Football", Price = 25}}.AsQueryable(); }
        }
    }
}

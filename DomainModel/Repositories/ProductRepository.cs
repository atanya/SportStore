using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using DomainModel.DAL;
using DomainModel.Interfaces;

namespace DomainModel.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public IQueryable<Product> Products
        {
            get { return Context.Set<Product>(); }
        }

        internal ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }

        public ProductRepository(string connectionString)
            : this(new DbContext(connectionString))
        {
        }
    }
}

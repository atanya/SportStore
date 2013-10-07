using System.Collections.Generic;
using System.Configuration;
using System.Data.Entity;
using System.Linq;
using DomainModel.Abstract;
using DomainModel.DAL;

namespace DomainModel.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public IQueryable<Product> Products
        {
            get { return Context.Set<Product>(); }
        }

        public ProductRepository(DbContext dbContext) : base(dbContext)
        {
        }
        public ProductRepository()
            : base(new DbContext(@"data source=TANYA-PC\sqlexpress;initial catalog=SportStore;persist security info=True;user id=tanya;password=tanya_;MultipleActiveResultSets=True;App=EntityFramework"))
        {
        }
    }
}

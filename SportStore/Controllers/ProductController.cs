using System.Linq;
using System.Web.Mvc;
using DomainModel.Interfaces;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ActionResult List()
        {
            var products = productRepository.Products.ToList();
            return View(products);
        }

    }
}

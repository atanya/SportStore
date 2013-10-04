using System.Linq;
using System.Web.Mvc;
using DomainModel.Abstract;
using DomainModel.Repositories;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        //temporary
        private IProductRepository productRepository = new ProductRepository();

        public ActionResult List()
        {
            return View(productRepository.Products.ToList());
        }

    }
}

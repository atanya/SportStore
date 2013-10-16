using System;
using System.Linq;
using System.Web.Mvc;
using DomainModel.Interfaces;

namespace SportStore.Controllers
{
    public class ProductController : Controller
    {
        private readonly IProductRepository productRepository;
        public int PageSize = 3;

        public ProductController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public ViewResult List(int pageNumber)
        {
            var productsCount = productRepository.Products.Count();
            ViewData["TotalPages"] = (int) Math.Ceiling((double) productsCount/PageSize);
            ViewData["CurrentPage"] = pageNumber;
            var products =
                productRepository.Products.OrderBy(p => p.Name).Skip(PageSize*(pageNumber - 1)).Take(PageSize).ToList();
            return View(products);
        }

    }
}

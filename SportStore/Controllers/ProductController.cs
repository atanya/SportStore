using System;
using System.Linq;
using System.Web.Mvc;
using DomainModel.Interfaces;
using SportStore.Models;

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

        public ViewResult List(string category, int pageNumber)
        {
            var products =
                productRepository.Products
                .Where(p => string.IsNullOrEmpty(category) || p.Category == category)
                .OrderBy(p => p.Name)
                .Skip(PageSize * (pageNumber - 1))
                .Take(PageSize).ToList();

            var productsCount = productRepository.Products.Count(p => string.IsNullOrEmpty(category) || p.Category == category);
            var totalPagesCount = (int)Math.Ceiling((double)productsCount / PageSize);

            var viewModel = new ProductListViewModel
                {
                    Products = products,
                    CurrentPage = pageNumber,
                    TotalPagesCount = totalPagesCount,
                    CurrentCategory = category
                };

            return View(viewModel);
        }

    }
}

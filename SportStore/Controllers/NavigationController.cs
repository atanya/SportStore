using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using DomainModel.Interfaces;
using SportStore.Models;

namespace SportStore.Controllers
{
    public class NavigationController : Controller
    {
        private IProductRepository productRepository;

        public NavigationController(IProductRepository productRepo)
        {
            productRepository = productRepo;
        }

        public ViewResult Menu(string selectedCategory)
        {
            var navLinks = new List<NavigationLink>
                {
                    new CategoryLink(null) {IsSelected = string.IsNullOrEmpty(selectedCategory)}
                };

            var categories = productRepository.Products.Select(x => x.Category).Distinct().OrderBy(x => x);
            foreach (var category in categories)
            {
                navLinks.Add(new CategoryLink(category) {IsSelected = category == selectedCategory});
            }
            ViewData["category"] = selectedCategory;
            return View(navLinks);
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Web.Mvc;
using DomainModel.DAL;
using DomainModel.Interfaces;
using NUnit.Framework;
using SportStore.Controllers;
using SportStore.Models;

namespace Tests
{
    [TestFixture]
    public class NavigationControllerTests
    {
        [Test]
        public void ProducesHomePlusNavLInkObjectForCategiries()
        {
            var products = new[]
                {
                    new Product {Name = "A", Category = "Animal"},
                    new Product {Name = "B", Category = "Vegetable"},
                    new Product {Name = "C", Category = "Mineral"},
                    new Product {Name = "D", Category = "Vegetable"},
                    new Product {Name = "E", Category = "Animal"}
                }.AsQueryable();
            var mockProductRepo = new Moq.Mock<IProductRepository>();
            mockProductRepo.Setup(x => x.Products).Returns(products);

            var navController = new NavigationController(mockProductRepo.Object);

            ViewResult result = navController.Menu();

            var links = ((IEnumerable<NavigationLink>)result.ViewData.Model).ToList();
            Assert.IsEmpty(result.ViewName);

            Assert.AreEqual(4, links.Count);
            Assert.AreEqual("Home", links[0].Text);
            Assert.AreEqual("Animal", links[1].Text);
            Assert.AreEqual("Mineral", links[2].Text);
            Assert.AreEqual("Vegetable", links[3].Text);
        }
    }
}

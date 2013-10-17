using System.Collections.Generic;
using System.Linq;
using DomainModel.DAL;
using DomainModel.Interfaces;
using Moq;
using NUnit.Framework;
using SportStore.Controllers;
using SportStore.Models;

namespace Tests
{
    [TestFixture]
    public class ProductControllerTests
    {
        [Test]
        [TestCase(3, 5, 2)]
        [TestCase(3, 7, 1)]
        public void ListPresentsCorrectPageOfProducts(int pageSize, int productsCount, int pageNumber)
        {
            const string productNameFirstPart = "P";
            var allProducts = Enumerable.Range(1, productsCount).Select(x => new Product { Name = productNameFirstPart + x }).ToArray();
            var productRepository = MockProductRepository(allProducts);

            var productsController = new ProductController(productRepository) {PageSize = pageSize};

            var result = productsController.List(null, pageNumber);

            Assert.IsNotNull(result, "Didn't render the view");

            var products = ((ProductListViewModel)result.ViewData.Model).Products as IList<Product>;

            Assert.IsNotNull(products, "Didn't get products");
            var gotProductsAmount = productsCount >= pageSize*pageNumber
                                        ? pageSize
                                        : productsCount - pageSize*(pageNumber - 1);
            Assert.AreEqual(gotProductsAmount, products.Count, "Got wrong number of products");

            for (var i = 1; i <= gotProductsAmount; i++)
            {
                var productIndex = pageSize*(pageNumber - 1) + i;
                Assert.AreEqual(productNameFirstPart + productIndex, products[i - 1].Name);
            }
        }

        [Test]
        [TestCase(null, 3, 3)]
        [TestCase("Cat2", 1, 2)]
        public void ListIncludesProuctsByCathegory(string cathegory, int totalPagesCount, int slectedProductsCount)
        {
            var allProducts = new[]
                    {
                        new Product {Id = 1, Name = "P1", Category = "Cat1"},
                        new Product {Id = 2, Name = "P2", Category = "Cat2"},
                        new Product {Id = 3, Name = "P3", Category = "Cat1"},
                        new Product {Id = 4, Name = "P4", Category = "Cat2"},
                        new Product {Id = 5, Name = "P5", Category = "Cat3"},
                        new Product {Id = 6, Name = "P6", Category = "Cat4"},
                        new Product {Id = 7, Name = "P7", Category = "Cat5"}
                    };
            var productRepository = MockProductRepository(allProducts);

            var productsController = new ProductController(productRepository) { PageSize = 3 };

            var result = ((ProductListViewModel)productsController.List(cathegory, 1).Model);
            var poducts = result.Products.ToArray();

            Assert.AreEqual(totalPagesCount, result.TotalPagesCount);
            Assert.AreEqual(slectedProductsCount, poducts.Length);
        }

        static IProductRepository MockProductRepository(params Product[] products)
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.Products).Returns(products.AsQueryable());
            return mockProductRepository.Object;
        }
    }
}

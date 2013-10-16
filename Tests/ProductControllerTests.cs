using System.Collections.Generic;
using System.Linq;
using DomainModel.DAL;
using DomainModel.Interfaces;
using Moq;
using NUnit.Framework;
using SportStore.Controllers;

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

            var result = productsController.List(pageNumber);

            Assert.IsNotNull(result, "Didn't render the view");

            var products = result.ViewData.Model as IList<Product>;

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

        static IProductRepository MockProductRepository(params Product[] products)
        {
            var mockProductRepository = new Mock<IProductRepository>();
            mockProductRepository.Setup(x => x.Products).Returns(products.AsQueryable());
            return mockProductRepository.Object;
        }
    }
}

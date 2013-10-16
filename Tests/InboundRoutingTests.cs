using System.Web;
using System.Web.Routing;
using NUnit.Framework;
using SportStore;

namespace Tests
{
    [TestFixture]
    public class InboundRoutingTests
    {
        [Test]
        public void SlashGoesToAllProductsPage()
        {
            TestRoute("/", new {controller = "Product", action = "List", category = (string) null, pageNumber = 1});
        }

        private void TestRoute(string url, object expectedValues)
        {
            RouteCollection routes = new RouteCollection();
            RouteConfig.RegisterRoutes(routes);
            var mockHttpContext = new Moq.Mock<HttpContextBase>();
            var mockRequest = new Moq.Mock<HttpRequestBase>();

            mockHttpContext.Setup(x => x.Request).Returns(mockRequest.Object);
            mockRequest.Setup(x => x.AppRelativeCurrentExecutionFilePath).Returns(url);

            RouteData routeData = routes.GetRouteData(mockHttpContext.Object);

            Assert.IsNotNull(routeData);

            var expectedDict = new RouteValueDictionary(expectedValues);

            foreach (var expectedVal in expectedDict)
            {
                if (expectedVal.Value == null)
                {
                    Assert.IsNotNull(routeData.Values[expectedVal.Key]);
                }
                else
                {
                    Assert.AreEqual(expectedVal.Value.ToString(), routeData.Values[expectedVal.Key].ToString());
                }
            }
        }
    }
}

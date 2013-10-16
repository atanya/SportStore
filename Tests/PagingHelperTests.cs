using System.Web.Mvc;
using NUnit.Framework;
using SportStore.HtmlHelpers;

namespace Tests
{
    [TestFixture]
    public class PagingHelperTests
    {
        [Test]
        public void PageLinksHtmlHelperTest()
        {
            HtmlHelper html = null;
            html.PagingLinks(0, 0, null);
        }

        [Test]
        public void PageLinksAhchorsTest()
        {
            HtmlHelper html = null;
            var links = html.PagingLinks(2, 3, i => "Page" + i);

            Assert.AreEqual(@"<a href=""Page1"">1</a><a class=""selected"" href=""Page2"">2</a><a href=""Page3"">3</a>", links.ToString().Replace("\r", "").Replace("\n", ""));
        }
    }
}

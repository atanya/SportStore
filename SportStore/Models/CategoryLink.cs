using System.Web.Routing;

namespace SportStore.Models
{
    public class CategoryLink: NavigationLink
    {
        public CategoryLink(string category)
        {
            Text = category ?? "Home";
            RouteValues =
                new RouteValueDictionary(
                    new {controller = "Product", action = "List", category, pageNumber = 1});
        }
    }
}
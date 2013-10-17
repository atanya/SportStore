using System.Web.Routing;

namespace SportStore.Models
{
    public class NavigationLink
    {
        public bool IsSelected { get; set; }

        public string Text { get; set; }

        public RouteValueDictionary RouteValues { get; set; }
    }
}
using System;
using System.Text;
using System.Web.Mvc;

namespace SportStore.HtmlHelpers
{
    public static class HtmlHelpers
    {
        public static MvcHtmlString PagingLinks(this HtmlHelper html, int currentPage, int totalPages, Func<int, string> pageUrl)
        {
            var result = new StringBuilder();

            for (var i = 1; i <= totalPages; i++)
            {
                TagBuilder tag = new TagBuilder("a");
                tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                if (i == currentPage)
                {
                    tag.AddCssClass("selected");
                }
                result.AppendLine(tag.ToString());
            }

            return new MvcHtmlString(result.ToString());
        }
    }
}

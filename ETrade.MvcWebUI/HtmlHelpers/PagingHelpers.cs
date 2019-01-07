using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;
using ETrade.MvcWebUI.Models;

namespace ETrade.MvcWebUI.HtmlHelpers
{
    public static class PagingHelpers
    {
        public static MvcHtmlString Pager(this HtmlHelper html, PagingInfo pagingInfo, Func<int,string> action)
        {
            var ul = new TagBuilder("ul");
            ul.AddCssClass("pagination");
            int pageCount = (int)Math.Ceiling((decimal) (pagingInfo.TotalItems / pagingInfo.ItemsPerPage)); 

            for (int i = 1; i <= pageCount; i++)
            {
                var li = new TagBuilder("li");
                if (i==pagingInfo.CurrentPage)
                    li.AddCssClass("active");
                var a = new TagBuilder("a");
                a.MergeAttribute("href", action(i));
                a.SetInnerText(i.ToString());
                li.InnerHtml = a.ToString();
                ul.InnerHtml += li.ToString();
               

            }
            return MvcHtmlString.Create(ul.ToString());
        }
        public static MvcHtmlString BootstrapPager(this HtmlHelper helper, int currentPageIndex, Func<int, string> action, int totalItems, int pageSize = 10, int numberOfLinks = 5)
        {
            if (totalItems <= 0)
            {
                return MvcHtmlString.Empty;
            }

            var totalPages = (int)Math.Ceiling(totalItems / (double)pageSize);

            var lastPageNumber = (int)Math.Ceiling((double)currentPageIndex / numberOfLinks) * numberOfLinks;

            var firstPageNumber = lastPageNumber - (numberOfLinks - 1);

            var hasPreviousPage = currentPageIndex > 1;

            var hasNextPage = currentPageIndex < totalPages;

            if (lastPageNumber > totalPages)
            {
                lastPageNumber = totalPages;
            }

            var ul = new TagBuilder("ul");

            ul.AddCssClass("pagination");

            ul.InnerHtml += AddLink(1, action, currentPageIndex == 1, "disabled", "<<", "First Page");

            ul.InnerHtml += AddLink(currentPageIndex - 1, action, !hasPreviousPage, "disabled", "<", "Previous Page");

            for (int i = firstPageNumber; i <= lastPageNumber; i++)
            {
                ul.InnerHtml += AddLink(i, action, i == currentPageIndex, "active", i.ToString(), i.ToString());
            }

            ul.InnerHtml += AddLink(currentPageIndex + 1, action, !hasNextPage, "disabled", ">", "Next Page");

            ul.InnerHtml += AddLink(totalPages, action, currentPageIndex == totalPages, "disabled", ">>", "Last Page");

            return MvcHtmlString.Create(ul.ToString());

        }



        private static TagBuilder AddLink(int index, Func<int, string> action, bool condition, string classToAdd, string linkText, string tooltip)

        {

            var li = new TagBuilder("li");

            li.MergeAttribute("title", tooltip);

            if (condition)
            {
                li.AddCssClass(classToAdd);
            }

            var a = new TagBuilder("a");

            a.MergeAttribute("href", !condition ? action(index) : "javascript:");

            a.SetInnerText(linkText);

            li.InnerHtml = a.ToString();

            return li;

        }


    }
}

//< ul class="pagination">
// <li><a href = "#" > 1 </ a ></ li >
//< li class="active"><a href = "#" > 2 </ a ></ li >


//< li >< a href="#">3</a></li>
//<li><a href = "#" > 4 </ a ></ li >
//< li >< a href="#">5</a></li>
//</ul>
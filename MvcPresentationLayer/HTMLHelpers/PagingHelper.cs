using MvcPresentationLayer.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Web;
using System.Web.Mvc;

namespace MvcPresentationLayer.HTMLHelpers
{
    public static class PagingHelper
    {
        public static MvcHtmlString PageLinks(
          this HtmlHelper html,
          //int totalPages,
          //int pageNumber
          PageInfo pageInfo
          /*Func<int, string> pageUrl
          int topicId,int page*/)
        {
            StringBuilder result = new StringBuilder();

            for (int i = 1; i <= pageInfo.TotalPages; i++)
            {
                TagBuilder tag = new TagBuilder("button"); // Construct an <a> tag
                //tag.MergeAttribute("href", pageUrl(i));
                tag.InnerHtml = i.ToString();
                tag.Attributes.Add("Name", "page");
                tag.Attributes.Add("Value", i.ToString());
                if (i == pageInfo.PageNumber)
                {
                   // tag.AddCssClass("btn-primary");
                    tag.AddCssClass("selected");
                }
                tag.AddCssClass("btn btn-default");
                result.Append(tag.ToString());
            }

            return MvcHtmlString.Create(result.ToString());
        }
    }
}
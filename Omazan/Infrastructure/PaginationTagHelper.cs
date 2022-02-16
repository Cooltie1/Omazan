using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.AspNetCore.Mvc.Routing;
using Microsoft.AspNetCore.Mvc.ViewFeatures;
using Microsoft.AspNetCore.Razor.TagHelpers;
using Omazan.Models.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Omazan.Models.Infrastructure
{
    [HtmlTargetElement("div", Attributes = "page-model")]
    public class PaginationTagHelper : TagHelper
    {
        private IUrlHelperFactory uhf;
        public PaginationTagHelper (IUrlHelperFactory tmp)
        {
            uhf = tmp;
        }
        [ViewContext]
        [HtmlAttributeNotBound]
        public ViewContext viewContext { get; set; }

        public PageInfo PageModel { get; set; }
        public string PageAction { get; set; }
        public override void Process(TagHelperContext context, TagHelperOutput output)
        {
            IUrlHelper uh = uhf.GetUrlHelper(viewContext);

            TagBuilder final = new TagBuilder("div");
            
            for (int i = 1; i < PageModel.totPages + 1; i++)
            {
                TagBuilder tagBuilder = new TagBuilder("a");
                tagBuilder.Attributes["href"] = uh.Action(PageAction, new { pagenum = i });
                tagBuilder.InnerHtml.Append(i.ToString() + " ");
                
            
                
                final.InnerHtml.AppendHtml(tagBuilder);
            }

            output.Content.AppendHtml(final.InnerHtml);
        }
    }
}

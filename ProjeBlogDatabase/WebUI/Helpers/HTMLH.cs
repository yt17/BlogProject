using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace WebUI.Helpers
{
    public static class HTMLH
    {
        public static MvcHtmlString Button(this HtmlHelper helper, string id,string typ,string txt)
        {
            string html = string.Format("<Button id='{0}' name='{0}' type='{1}'>{2}</Button>",id,typ,txt);
            return MvcHtmlString.Create(html);
        }
    }
}
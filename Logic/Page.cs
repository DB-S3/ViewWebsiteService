using System;
using System.Collections.Generic;
using System.Text;

namespace Logic
{
    public class Page
    {
        readonly Common.Interfaces.IPagesDA PageDa;
        readonly Common.Interfaces.IWebsiteDa WebsiteDa;

        public Common.Page GetPage(string _siteName, string _pageName) {
            var siteId = WebsiteDa.ReturnWebsiteiteId(_siteName);
            if (siteId != null) { 
                var pageId = PageDa.ReturnPageId(siteId, _pageName);
                if (pageId != null) {
                    return PageDa.FindPage(pageId);
                }
                return new Common.Page();
            }
            return new Common.Page();
        }

        public Page()
        {
            PageDa = Factory.Factory.GetPageDA();
            WebsiteDa = Factory.Factory.GetWebsiteDa();
        }
    }
}

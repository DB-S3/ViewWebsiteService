using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Logic
{
    public class Page
    {
        readonly Common.Interfaces.IPagesDA PageDa;
        readonly Common.Interfaces.IWebsiteDa WebsiteDa;

        public async Task<Common.Page> GetPage(string _siteName, string _pageName) {
            var siteId = await WebsiteDa.ReturnWebsiteiteId(_siteName);
            if (siteId != null) { 
                var pageId = await PageDa.ReturnPageId(siteId, _pageName);
                if (pageId != null) {
                    return await PageDa.FindPage(pageId);
                }
                return new Common.Page();
            }
            return new Common.Page();
        }

        public Page(Data.Database db)
        {
            PageDa = Factory.Factory.GetPageDA(db);
            WebsiteDa = Factory.Factory.GetWebsiteDa(db);
        }
    }
}

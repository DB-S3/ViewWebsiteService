using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class WebsiteDa : Common.Interfaces.IWebsiteDa
    {
        public string ReturnWebsiteiteId(string _siteName) {
            using (Database db = new Database())
            {
                string result = db.Websites.Where(x => x.Url == _siteName).FirstOrDefault().Id;
                if (db.Websites.Where(x => x.Url == _siteName).Count() > 0)
                {
                    return db.Websites.Where(x => x.Url == _siteName).FirstOrDefault().Id;
                }
                return null;
            }
        }
    }
}

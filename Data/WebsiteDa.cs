using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WebsiteDa : Common.Interfaces.IWebsiteDa
    {
        public async Task<string> ReturnWebsiteiteId(string _siteName) {
            using (Database db = new Database())
            {
                if (db.Websites.Where(x => x.Url == _siteName).Count() > 0)
                {
                    return db.Websites.Where(x => x.Url == _siteName).FirstOrDefault().Id;
                }
                return null;
            }
        }
    }
}

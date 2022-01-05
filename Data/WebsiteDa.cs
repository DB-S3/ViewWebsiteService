using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class WebsiteDa : Common.Interfaces.IWebsiteDa
    {
        public readonly Data.Database db;
        public WebsiteDa(Data.Database _db)
        {
            db = _db;
        }
        public async Task<string> ReturnWebsiteiteId(string _siteName) {
            if (db.Websites.Where(x => x.Url == _siteName).Count() > 0)
            {
                return db.Websites.Where(x => x.Url == _siteName).FirstOrDefault().Id;
            }
            return null;
        }
    }
}

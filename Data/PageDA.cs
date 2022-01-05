using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Data
{
    public class PageDA : Common.Interfaces.IPagesDA
    {
        public readonly Data.Database db;
        public PageDA(Data.Database _db) {
            db = _db;
        }
        public async Task<string> ReturnPageId(string _siteId, string _pageName) {
            if (db.Pages.Where(x => x.WebsiteId == _siteId && x.Name == _pageName).Count() > 0) {
                return db.Pages.Where(x => x.WebsiteId == _siteId && x.Name == _pageName).FirstOrDefault().Id; ;
            }
            return null;
        }
        public async Task<Common.Page> FindPage(string Id)
        {
          return db.Pages.Where(x=> x.Id == Id).Include(t=> t.Objects).ThenInclude(y=> y.options).FirstOrDefault();
        }
    }
}

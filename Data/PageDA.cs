﻿using Common;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Data
{
    public class PageDA : Common.Interfaces.IPagesDA
    {
        public string ReturnPageId(string _siteId, string _pageName) {
            using (Database db = new Database())
            {
                if (db.Pages.Where(x => x.WebsiteId == _siteId && x.Name == _pageName).Count() > 0) {
                    return db.Pages.Where(x => x.WebsiteId == _siteId && x.Name == _pageName).FirstOrDefault().Id; ;
                }
                return null;
            }
        }
        public Common.Page FindPage(string Id)
        {
            using (Database db = new Database())
            {
                return db.Pages.Where(x=> x.Id == Id).Include(t=> t.Objects).ThenInclude(y=> y.options).FirstOrDefault();
            }
        }
    }
}

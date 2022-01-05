using System;

namespace Factory
{
    public class Factory
    {
        public static Data.PageDA GetPageDA(Data.Database db) {
            return new Data.PageDA(db);
        }
        public static Data.WebsiteDa GetWebsiteDa(Data.Database db)
        {
            return new Data.WebsiteDa(db);
        }
    }
}

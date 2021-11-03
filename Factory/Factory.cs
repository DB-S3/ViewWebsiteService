using System;

namespace Factory
{
    public class Factory
    {
        public static Data.PageDA GetPageDA() {
            return new Data.PageDA();
        }
        public static Data.WebsiteDa GetWebsiteDa()
        {
            return new Data.WebsiteDa();
        }
    }
}

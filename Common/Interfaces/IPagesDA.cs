using System;
using System.Collections.Generic;
using System.Text;

namespace Common.Interfaces
{
    public interface IPagesDA
    {
      
        Common.Page FindPage(string Id);
        string ReturnPageId(string _siteId, string _pageName);
    }
}

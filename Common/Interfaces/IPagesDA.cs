using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Common.Interfaces
{
    public interface IPagesDA
    {

        Task<Common.Page> FindPage(string Id);
        Task<string> ReturnPageId(string _siteId, string _pageName);
    }
}

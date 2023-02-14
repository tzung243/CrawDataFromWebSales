using System;
using System.Collections.Generic;
namespace CrawDataFromWebSales
{
    public interface IStore
    {
        List<string> getLinkProducts(string url);

        bool isStore(string url);

        bool isStore(Uri url);

        string getDomain();
    }
}

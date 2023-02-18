using OpenQA.Selenium.DevTools.V107.Database;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace CrawDataFromWebSales
{
    public interface IStore
    {
        List<string> getLinkProducts(string url);

        bool isStore(string url);

        bool isStore(Uri url);

        string getDomain();
        Task<Data> getData(Data data);

    }
}

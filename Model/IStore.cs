using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Model
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

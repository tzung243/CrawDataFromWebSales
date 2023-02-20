namespace Model
{
    public class StoreFactory
    {
        public IStore GetStore(string url)
        {
            url = url.Trim();
            if (string.IsNullOrWhiteSpace(url)) return null;

            if (WebDienMayXanh.Instance.isStore(url))
            {
                return WebDienMayXanh.Instance;
            }
            if (WebNguyenKim.Instance.isStore(url))
            {
                return WebNguyenKim.Instance;
            }
            if (WebDienMayChoLon.Instance.isStore(url))
            {
                return WebDienMayChoLon.Instance;
            }
            if (WebMediaMart.Instance.isStore(url))
            {
                return WebMediaMart.Instance;
            }
            if (WebHC.Instance.isStore(url))
            {
                return WebHC.Instance;
            }

            return null;
        }
    }
}

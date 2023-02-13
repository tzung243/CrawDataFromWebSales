using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CrawDataFromWebSales
{
    public class WebHC : IStore
    {
        private WebHC() { }
        private static WebHC instance;

        public static WebHC Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebHC();
                }
                return instance;
            }
        }

        private static string host = "hc.com.vn";
        public List<string> getLinkProducts(string url)
        {
            WebDriver driver = new ChromeDriver();
            driver.Navigate().GoToUrl(url);

            List<string> hrefTags = new List<string>();
            while (true)
            {
                hrefTags.AddRange(getLinkProductsInPagination(driver));
                try
                {
                    IWebElement next = driver.FindElement(By.CssSelector("a.btn_next"));
                    driver.Navigate().GoToUrl(next.GetAttribute("href"));
                }
                catch
                {

                    break;
                }
            }

            driver.Close();
            return hrefTags.Distinct().ToList();
        }

        private List<string> getLinkProductsInPagination(WebDriver driver)
        {
            List<IWebElement> links = driver.FindElements(By.CssSelector("a.product-render[href]")).ToList();
            List<string> hrefTags = new List<string>();
            foreach (IWebElement link in links)
            {
                string href = link.GetAttribute("href");

                hrefTags.Add(href);

            }
            return hrefTags.Distinct().ToList();
        }

        public bool isStore(string url)
        {
            Uri uriParsed = new Uri(url);
            return isStore(uriParsed);
        }

        public bool isStore(Uri url)
        {
            return url.Host.Equals(host);
        }
    }
}
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;

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

            using (var driver = new ChromeDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
                driver.Navigate().GoToUrl(url);

                int pageIndex = 1;
                List<string> hrefTags = new List<string>();
                while (true)
                {
                    try
                    {
                        Thread.Sleep(3000);
                        hrefTags.AddRange(GetLinkProductsInPagination(driver));
                        IWebElement page = driver.FindElement(By.XPath($"//a[@data-pageid = '{++pageIndex}']"));
                        page.Click();

                    }
                    catch
                    {
                        break;
                    }
                }
                driver.Quit();
                return hrefTags.Distinct().ToList();
            }
        }

        private List<string> GetLinkProductsInPagination(WebDriver driver)
        {

            List<IWebElement> links = driver.FindElements(By.XPath("//h3[@id]/a")).ToList();
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
        public string getDomain()
        {
            return host;
        }

        public void getData(Data data)
        {
            throw new NotImplementedException();
        }

    }
}
using Nest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using System.Windows.Forms;

namespace CrawDataFromWebSales
{
    public class WebMediaMart : IStore
    {
        private WebMediaMart() { }
        private static WebMediaMart instance;

        public static WebMediaMart Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebMediaMart();
                }
                return instance;
            }
        }

        private static string host = "mediamart.vn";
        public List<string> getLinkProducts(string url)
        {
            WebDriver driver = new ChromeDriver();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(40);
            driver.Navigate().GoToUrl(url);

            List<string> hrefTags = new List<string>();
            while (true)
            {
                try
                {
                    Thread.Sleep(2000);
                    IWebElement seeMore = driver.FindElement(By.CssSelector("a.seemoreproducts"));
                    seeMore.Click();

                }
                catch

                {

                    break;
                }
            }

            hrefTags = getLinkProducts(driver);

            driver.Quit();

            return hrefTags;
            
        }

        private List<string> getLinkProducts(WebDriver driver)
        {
            List<IWebElement> links = driver.FindElements(By.CssSelector("a.product-item[href]")).ToList();
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
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
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
            driver.Navigate().GoToUrl(url);

            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(2));
            wait.Until(drv =>
            {
                try
                {
                    IWebElement seeMore = drv.FindElement(By.CssSelector("a.seemoreproducts"));
                    seeMore.Click();
                }
                catch (Exception e)
                {
                    MessageBox.Show(e.Message);
                    return false;
                }

                return true;
            });
            List<string> hrefTags = new List<string>();

            hrefTags.AddRange(getLinkProducts(driver));

            driver.Close();
            return hrefTags.Distinct().ToList();
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
    }
}
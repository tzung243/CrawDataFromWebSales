using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Threading;
using OpenQA.Selenium.Support.UI;
using static System.Windows.Forms.LinkLabel;

namespace CrawDataFromWebSales
{
    public class WebDienMayChoLon : IStore
    {
        private WebDienMayChoLon() { }
        private static WebDienMayChoLon instance;

        public static WebDienMayChoLon Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebDienMayChoLon();
                }
                return instance;
            }
        }

        private static string host = "dienmaycholon.vn";
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
                    IWebElement seeMore = driver.FindElement(By.XPath($"//*[@id=\"js-scroll\"]/div/div[2]/div[4]/div/div[2]/button"));
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
            List<IWebElement> links = driver.FindElements(By.CssSelector("a.img_pro[href]")).ToList();
            List<string> hrefTags = new List<string>();
            foreach (IWebElement link in links)
            {
                try
                {
                    string href = link.GetAttribute("href");

                    hrefTags.Add(href);

                }
                catch
                {
                    continue;
                }


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

        public async Task<Data> getData(Data data)
        {
            throw new NotImplementedException();
        }
    }
}

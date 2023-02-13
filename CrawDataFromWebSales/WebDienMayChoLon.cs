using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
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
            driver.Navigate().GoToUrl(url);

            List<string> hrefTags = new List<string>();
            WebDriverWait wait = new WebDriverWait(driver, TimeSpan.FromMinutes(10));
            while (true)
            {
                try
                {
                    Thread.Sleep(5000);
                    wait.IgnoreExceptionTypes(typeof(NoSuchElementException));

                    var page = wait.Until((d) =>
                    {
                        try
                        {
                            IWebElement seeMore = d.FindElement(By.XPath($"//*[@id=\"js-scroll\"]/div/div[2]/div[4]/div/div[2]"));
                            //IWebElement seeMore = d.FindElement(By.CssSelector("div.see_more_cat, button[@count]"));
                            if (seeMore.Displayed)
                            {
                                return seeMore;
                            }
                        }
                        catch
                        {
                            return null;
                        }

                        return null;
                    });

                    page.Click();

                }
                catch 

                {

                    break;
                }
            }
           

            hrefTags.AddRange(getLinkProducts(driver));

            driver.Quit();
            driver.Close();
            
            return hrefTags.Distinct().ToList();
        }

        private List<string> getLinkProducts(WebDriver driver)
        {
            List<IWebElement> links = driver.FindElements(By.CssSelector("a.img_pro[href]")).ToList();
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

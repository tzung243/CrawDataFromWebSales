using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
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
        public async Task<List<string>> getLinkProducts(string url)
        {

            using (var driver = new ChromeDriver())
            {
                driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
                driver.Navigate().GoToUrl(url);

                IJavaScriptExecutor js = (IJavaScriptExecutor)driver;

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                int pageIndex = 1;
                List<string> hrefTags = new List<string>();
                while (true)
                {
                    try
                    {
                        //Thread.Sleep(5 * 1000);
                        var links = await getLinkProductsInPagination(driver);
                        hrefTags.AddRange(links);

                        var page = wait.Until((d) =>
                        {
                            IWebElement element = d.FindElement(By.XPath($"//a[@data-pageid = '{pageIndex++}']"));
                            if (element == null) return null;

                            if (element.Displayed &&
                                element.Enabled &&
                                element.GetAttribute("href") != null)
                            {
                                return element;
                            }

                            return null;
                        });

                        js.ExecuteAsyncScript("arguments[0].click();", page);

                        //page.Click();

                    }
                    catch
                    {
                        break;
                    }
                }
                return hrefTags.Distinct().ToList();
            }
        }

        private async Task<List<string>> getLinkProductsInPagination(WebDriver driver)
        {
            await Task.Run(() =>
            {
                List<IWebElement> links = driver.FindElements(By.XPath("//h3[@id]/a")).ToList();
                List<string> hrefTags = new List<string>();
                foreach (IWebElement link in links)
                {
                    string href = link.GetAttribute("href");

                    hrefTags.Add(href);

                }
                return hrefTags.Distinct().ToList();
            });
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
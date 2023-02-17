using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;

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

        public async Task<Data> getData(Data data)
        {
            var tokenSource = new CancellationTokenSource();
            Action getData = () =>
            {

                try
                {
                    HtmlWeb htmlWeb = new HtmlWeb()
                    {
                        AutoDetectEncoding = false,
                        OverrideEncoding = Encoding.UTF8
                    };
                    var documentNode = htmlWeb.Load(data.url).DocumentNode;

                    data.name = documentNode.SelectSingleNode("//h1").InnerHtml;

                    string price = documentNode.SelectSingleNode("//div[@class = 'pdetail-price-box']").InnerText;
                    price = Regex.Replace(price, "\\D", "");
                    data.price = UInt32.Parse(price);

                    data.description = documentNode.SelectSingleNode("//div[@class = 'pdetail-desc']/p").InnerText;

                    data.status = 1;
                    data.time_load = DateTime.Now;
                }
                catch (Exception)
                {
                    data.status = 2;
                    tokenSource.Cancel();
                }
            };

            Task crawlTaks = new Task(getData, tokenSource.Token);
            crawlTaks.Start();
            await crawlTaks;

            return data;
        }

    }
}
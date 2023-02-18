using Nest;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;
using HtmlAgilityPack;
using System.Text;
using System.Threading.Tasks;
using Fizzler.Systems.HtmlAgilityPack;
using System.Windows.Forms;
using System.Net;

namespace CrawDataFromWebSales
{
    public class WebDienMayXanh : IStore
    {

        private WebDienMayXanh() { }
        private static WebDienMayXanh instance;

        public static WebDienMayXanh Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebDienMayXanh();
                }
                return instance;
            }
        }

        private static string host = "www.dienmayxanh.com";

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

                    IWebElement seeMore = driver.FindElement(By.CssSelector("div.view-more a"));
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
            List<IWebElement> links = driver.FindElements(By.CssSelector("a.main-contain[href]")).ToList();
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
            Action get_Data = () =>
            {
                try
                {
                    HtmlWeb htmlWeb = new HtmlWeb()
                    {
                        AutoDetectEncoding = false,
                        OverrideEncoding = Encoding.UTF8
                    };

                    htmlWeb.PreRequest = delegate (HttpWebRequest webReq)
                    {
                        webReq.Timeout = 600000; // number of milliseconds
                        return true;
                    };

                    HtmlDocument doc = new HtmlDocument
                    {
                        OptionUseIdAttribute = true
                    };

                    doc = htmlWeb.Load(data.url);

                    string name = doc.DocumentNode.SelectSingleNode(".//div[@data-name]").Attributes["data-name"].Value;
                    string price = doc.DocumentNode.QuerySelector("p.box-price-present").InnerText;
                    price = price.Replace(".", "");
                    price = price.Replace("&#x20AB;", "");
                    double curPrice;
                    double.TryParse(price, out curPrice);
                    

                    var description = doc.DocumentNode.SelectSingleNode(".//div[@class='content-article']").InnerText;

                    data.status = 1;
                    data.name = name;
                    data.price = curPrice;
                    data.description = description;

                }
                catch(Exception)
                {
                    data.status = 2;
                    data.time_load = DateTime.Now;
                    tokenSource.Cancel();
                }
            };
            Task crawlTask = new Task(get_Data, tokenSource.Token);
            crawlTask.Start();
            await crawlTask;
            data.time_load = DateTime.Now;
            return data;
        }


    }
}

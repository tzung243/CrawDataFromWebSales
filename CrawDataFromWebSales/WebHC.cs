using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using static System.Windows.Forms.VisualStyles.VisualStyleElement.Tab;

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

        async Task<Data> IStore.getData(Data data)

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
                    htmlWeb.PreRequest = delegate (HttpWebRequest webReq)
                    {
                        webReq.Timeout = 60000; // number of milliseconds
                        return true;
                    };
                    var documentNode = htmlWeb.Load(data.url).DocumentNode;

                    data.name = documentNode.SelectSingleNode("//h1").InnerHtml;
                    string price = documentNode.QuerySelector("span.price-new").InnerText;
                    data.price = Regex.Replace(price, "\\D", "").Trim();

                    var desNodes = documentNode.QuerySelector("div.tab-content").InnerText;
                    data.description = desNodes;

                    data.status = 1;
                    data.time_load = DateTime.Now;
                }
                catch
                {
                    data.status = 2;
                    data.time_load = DateTime.Now;
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

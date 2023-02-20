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

namespace Model
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
            ChromeOptions options = new ChromeOptions();
            options.AddArgument("headless");
            WebDriver driver = new ChromeDriver(options);
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
                        webReq.Timeout = 600000; // number of milliseconds
                        return true;
                    };

                    HtmlDocument doc = new HtmlDocument
                    {
                        OptionUseIdAttribute = true
                    };


                    var documentNode = htmlWeb.Load(data.url).DocumentNode;

                    data.name = documentNode.SelectSingleNode("//h1").InnerHtml;
                    var priceNode = documentNode.QuerySelector("div.price_block");

                    double curPrice;
                    if (priceNode != null)
                    {
                        string price = priceNode.InnerText;
                        price = Regex.Replace(price, "\\D", "");
                        double.TryParse(price, out curPrice);
                    }
                    else
                    {
                        curPrice = -10; // k ton tai gia
                    }

                    data.price = curPrice;

                    var desNodes = documentNode.SelectNodes("//div[@class = 'des_pro_item']")[1]
                                                    .ChildNodes.Select(n => n.InnerText);
                    var des = new StringBuilder();
                    foreach (var node in desNodes)
                    {
                        des.Append(node);
                    }
                    data.description = des.ToString();

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

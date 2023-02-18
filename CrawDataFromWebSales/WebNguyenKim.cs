using Fizzler.Systems.HtmlAgilityPack;
using HtmlAgilityPack;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Forms;
using HtmlDocument = HtmlAgilityPack.HtmlDocument;

namespace CrawDataFromWebSales
{
    public class WebNguyenKim : IStore
    {
        private WebNguyenKim() { }
        private static WebNguyenKim instance;

        public static WebNguyenKim Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = new WebNguyenKim();
                }
                return instance;
            }
        }

        private static string host = "www.nguyenkim.com";
        public List<string> getLinkProducts(string url)
        {
            using (WebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(url);

                List<string> hrefTags = new List<string>();
                while (true)
                {
                    hrefTags.AddRange(getLinkProductsInPagination(driver));
                    try
                    {
                        IWebElement next = driver.FindElement(By.CssSelector("a.btn_next"));
                        driver.Navigate().GoToUrl(next.GetAttribute("href"));
                    }
                    catch
                    {

                        break;
                    }
                }

                driver.Quit();
                return hrefTags;
            }

        }
        private List<string> getLinkProductsInPagination(WebDriver driver)
        {
            List<IWebElement> links = driver.FindElements(By.CssSelector("a.product-render[href]")).ToList();
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

                    string name = doc.DocumentNode.SelectSingleNode(".//h1[@class='product_info_name']").InnerText;
                    string price = doc.DocumentNode.QuerySelector("span.nk-price-final").InnerText;

                    price = price.Replace(".", "");
                    price = price.Replace("đ", "");

                    string description = doc.DocumentNode.SelectSingleNode(".//div[@class='productInfo_description']").InnerText;

                    data.status = 1;
                    data.name = name;
                    data.price = Convert.ToDouble(price.Trim());
                    data.description = description;

                }
                catch
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

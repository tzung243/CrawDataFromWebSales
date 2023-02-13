using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Linq;

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
            using (WebDriver driver = new ChromeDriver())
            {
                driver.Navigate().GoToUrl(url);
                while (true)
                {
                    try
                    {
                        IJavaScriptExecutor jsExecutor = (IJavaScriptExecutor)driver;

                        bool ctn = (bool)jsExecutor.ExecuteScript("" +
                            "let seeMore = document.querySelector('div.see_more_cat');\n" +
                            "if (!seeMore) {\n" +
                            "return false;\n" +
                            "}\n" +
                            "seeMore.click();\n" +
                            "return true;\n");
                        if (!ctn)
                        {
                            break;
                        }
                    }
                    catch

                    {

                        break;
                    }
                }
                List<string> hrefTags = new List<string>();

                hrefTags.AddRange(getLinkProducts(driver));

                return hrefTags.Distinct().ToList();
            }
        }

        private List<string> getLinkProducts(WebDriver driver)
        {
            List<IWebElement> links = driver.FindElements(By.CssSelector("div.product div.product_block_img a.img_pro[href]")).ToList();
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

﻿using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            throw new NotImplementedException();
        }

    }
}

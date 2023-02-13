using OpenQA.Selenium.Chrome;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Policy;

namespace CrawDataFromWebSales
{
    public class WebDienMayXanh : IStore
    {

        private WebDienMayXanh() { }
        private static WebDienMayXanh instance;

        public static WebDienMayXanh Instance { get { 
                if (instance == null)
                {
                    instance = new WebDienMayXanh();
                }
                return instance; } }

        private static string host = "www.dienmayxanh.com";

        public List<string> getLinkProducts(string url)
        {
            try
            {
                WebDriver driver = new ChromeDriver();
                driver.Navigate().GoToUrl(url);

                List<IWebElement> links = driver.FindElements(By.CssSelector("a.main-contain[href]")).ToList();
                List<string> hrefTags = new List<string>();

                foreach (IWebElement link in links)
                {
                    string href = link.GetAttribute("href");

                    hrefTags.Add(href);
                }
                driver.Close();
                return hrefTags.Distinct().ToList();
            }
            catch
            {
                return null;    
            }
            
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

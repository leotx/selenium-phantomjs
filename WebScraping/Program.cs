using System;
using OpenQA.Selenium;
using OpenQA.Selenium.PhantomJS;
using OpenQA.Selenium.Support.UI;

namespace WebScraping
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var driver = new PhantomJSDriver())
            {
                driver.Navigate().GoToUrl("http://www.google.com/");

                var query = driver.FindElementByName("q");
                query.SendKeys("hello");
                query.Submit();

                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(10));
                wait.Until(d => d.Title.ToLower().StartsWith("hello"));

                Console.WriteLine("Page title: " + driver.Title);

                var resultsPanel = driver.FindElementById("search");
                var searchResults = resultsPanel.FindElements(By.XPath(".//a"));

                foreach (var result in searchResults)
                {
                    Console.WriteLine(result.Text);
                }
            }

            Console.ReadKey();
        }
    }
}

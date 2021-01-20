using System;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Ecs.SupportClasses
{
    public static class Browser
    {
        private static IWebDriver driver;
        public static string TestURL;

        public static IWebDriver Driver()
        {
            TestURL = "http://localhost:3000/";
            if (driver == null)
            {
                var path = AppDomain.CurrentDomain.BaseDirectory + "..\\..\\";
                driver = new ChromeDriver(path);
            }
            return driver;
        }

        public static void GoHome()
        {
            Driver().Navigate().GoToUrl(TestURL);
        }

    }
}

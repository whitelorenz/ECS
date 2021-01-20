using OpenQA.Selenium;
using Ecs.SupportClasses;

namespace Ecs.Pages
{
    class Dialog
    {
        public IWebElement resultMessage => Browser.Driver().FindElement(By.XPath(".//div[@class='dialog']"));
    }
}

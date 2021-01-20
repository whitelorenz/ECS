using OpenQA.Selenium;
using Ecs.SupportClasses;

namespace Ecs.Pages
{
    class HomePage
    {
        public IWebElement RenderChallengeButton => Browser.Driver().FindElement(By.XPath(".//button[@data-test-id='render-challenge']"));
        public IWebElement challenge1 => Browser.Driver().FindElement(By.XPath(".//input[@data-test-id='submit-1']"));
        public IWebElement challenge2 => Browser.Driver().FindElement(By.XPath(".//input[@data-test-id='submit-2']"));
        public IWebElement challenge3 => Browser.Driver().FindElement(By.XPath(".//input[@data-test-id='submit-3']"));
        public IWebElement yourName => Browser.Driver().FindElement(By.XPath(".//input[@data-test-id='submit-4']"));
        public IWebElement submitAnswers => Browser.Driver().FindElements(By.XPath(".//button[@tabindex='0' and @type='button']"))[1];

        internal string FindIndex(int[] ar)
        {
            int firstNumbers, lastNumbers = 0;
            for (int i = 1; i < 7; i++)
            {
                firstNumbers = 0;
                for (int j = 0; j < i; j++)
                {
                    firstNumbers = firstNumbers + ar[j];
                }
                lastNumbers = 0;
                for (int j = i + 1; j < 9; j++)
                {
                    lastNumbers = lastNumbers + ar[j];
                }

                if (firstNumbers == lastNumbers)
                {
                    return (i).ToString();
                }
            }
            return null;
        }
    }
}

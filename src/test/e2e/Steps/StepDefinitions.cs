using TechTalk.SpecFlow;
using Ecs.SupportClasses;
using Ecs.Pages;
using OpenQA.Selenium;
using FluentAssertions;
using System;

namespace Ecs.Steps
{
    [Binding]
    public class StepDefinitions
    {
        private ScenarioContext _scenarioContext;

        public StepDefinitions(ScenarioContext scenarioContext)
        {
            _scenarioContext = scenarioContext;
        }

        HomePage HomePage;
        Dialog Dialog;

        [Given(@"I am on the Home Page")]
        public void GivenIAmOnTheHomePage()
        {
            Browser.GoHome();

            HomePage = new HomePage();
        }

        [When(@"I render the challenge")]
        public void WhenIRenderTheChallenge()
        {
            HomePage.RenderChallengeButton.Click();
        }

        [When(@"I calculate the array centres")]
        public void WhenICalculateTheArrayCentres()
        {
            //Collect data
            int[] array1 = new int[9];
            int[] array2 = new int[9];
            int[] array3 = new int[9];

            for (int i = 0; i < 9; i++)
            {
                array1[i] = Int16.Parse(Browser.Driver().FindElement(By.XPath($".//td[@data-test-id='array-item-1-{i}']")).Text);
                array2[i] = Int16.Parse(Browser.Driver().FindElement(By.XPath($".//td[@data-test-id='array-item-2-{i}']")).Text);
                array3[i] = Int16.Parse(Browser.Driver().FindElement(By.XPath($".//td[@data-test-id='array-item-3-{i}']")).Text);
            }

            //calculate centres
            _scenarioContext["Index1"] = HomePage.FindIndex(array1);
            _scenarioContext["Index2"] = HomePage.FindIndex(array2);
            _scenarioContext["Index3"] = HomePage.FindIndex(array3);
        }

        [When(@"I submit the array centres")]
        public void WhenISubmitTheArrayCentres()
        {
            HomePage.challenge1.SendKeys(_scenarioContext["Index1"].ToString());
            HomePage.challenge2.SendKeys(_scenarioContext["Index2"].ToString());
            HomePage.challenge3.SendKeys(_scenarioContext["Index3"].ToString());
            HomePage.yourName.SendKeys("Lorenzo");
            HomePage.submitAnswers.Click();
        }

        [Then(@"a message is shown")]
        public void ThenAMessageIsShown(Table table)
        {
            Dialog = new Dialog();
            table.Rows[0]["Message"].Should().Equals(Dialog.resultMessage);
        }

        [AfterFeature]
        public static void AfterScenario()
        {
            Browser.Driver().Quit();
        }
    }
}

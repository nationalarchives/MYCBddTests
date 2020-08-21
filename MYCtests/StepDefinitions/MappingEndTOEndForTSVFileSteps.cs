using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MYCtests.StepDefinitions
{
    [Binding]
    public class MappingEndTOEndForTSVFileSteps
    {
        private string ChangeColumNamePath;
        public IWebDriver _driver;
        [Given(@"that I am at the Mapping Page with uploaded tsv file")]
        public void GivenThatIAmAtTheMappingPageWithUploadedTsvFile()
        {
            _driver = new PageNavigator().GoToMYCPage();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
            var pageNavigator = new PageNavigator();
            ChangeColumNamePath = pageNavigator.Configuration.GetValue<string>("ChangeColumNamePath");
            _driver.FindElement(By.LinkText("Add a collection")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("upload")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(ChangeColumNamePath);
            _driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
            Thread.Sleep(2000);
        }

        [Given(@"mandatory fields have been added to the list of Matched fields for tsv file")]
        public void GivenMandatoryFieldsHaveBeenAddedToTheListOfMatchedFieldsForTsvFile()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.LinkText("Map fields to Discovery >")).Click();
            Thread.Sleep(1000);

            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.XPath("//label[contains(.,'Level Of Description')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[3]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Title')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'Titles')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Name Of Creator(s)')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[5]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Scope And Content')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[6]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Reference Code')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[7]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Covering Dates')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[8]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Start Date')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[9]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'End Date')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[10]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);

        }
        
        [When(@"I click the Submit and continue button")]
        public void WhenIClickTheSubmitAndContinueButton()
        {
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Submit and continue']")).Click();
        }

        [Then(@"Enter the mapping Name for tsv file")]
        public void ThenEnterTheMappingNameForTsvFile()
        {
            DateTime start = DateTime.UtcNow;
            _driver.FindElement(By.Id("map_name")).SendKeys("MapTest" +start);
            Thread.Sleep(1000);
        }
        
        [Then(@"I arrive at the view history page")]
        public void ThenIArriveAtTheViewHistoryPage()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
        }
        
        [Then(@"I see an information message stating that my file has been successfully mapped")]
        public void ThenISeeAnInformationMessageStatingThatMyFileHasBeenSuccessfullyMapped()
        {
            String Mapping_Message = _driver.FindElement(By.XPath("//*[@id='page_wrap']/div/div/div[2]/span/span")).Text;
            Assert.IsTrue(Mapping_Message.Contains("Mapping submitted"));
        }
        
       
    }
}

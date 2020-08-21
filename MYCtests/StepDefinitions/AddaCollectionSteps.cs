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
    public class AddaCollectionSteps
    {
        private string KenrickCollectionPath;
        public IWebDriver _driver;

        [Given(@"I am on MYC page and I sign in to add a collection")]
        public void GivenIAmOnMYCPageAndISignInToAddACollection()
        {
            _driver = new PageNavigator().GoToMYCPage();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
            var pageNavigator = new PageNavigator();
            KenrickCollectionPath = pageNavigator.Configuration.GetValue<string>("KenrickCollectionPath");     
        }

        [When(@"I upload a valid file")]
        public void WhenIUploadAValidFile()
        {
            _driver.FindElement(By.LinkText("Add a collection")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("upload")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(KenrickCollectionPath);
            _driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
        }

        [When(@"check for the message The file has been added to the queue for upload\. Please go to View history for more details\.")]
        public void WhenCheckForTheMessageTheFileHasBeenAddedToTheQueueForUpload_PleaseGoToViewHistoryForMoreDetails_()
        {
            string uploadMsg = _driver.FindElement(By.CssSelector(".emphasis-block > span")).Text;
            Assert.IsTrue(uploadMsg.Contains("The file has been added to the queue for upload. Please go to View history for more details."));
        }
        
        [Then(@"go to view history and click on Map fields to Discovery")]
        public void WhenGoToViewHistoryAndClickOnMapFieldsToDiscovery()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("Map fields to Discovery >")).Click();
            Thread.Sleep(1000);
        }
        [When(@"map the fields in mapping page")]
        public void WhenMapTheFieldsInMappingPage()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.XPath("//label[contains(.,'Level Of Description')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'physical_description')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Title')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'title')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Name Of Creator(s)')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'creator')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Scope And Content')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'description_level')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Reference Code')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'parts_reference')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'Start Date')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'production.date.start')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//label[contains(.,'End Date')]")).Click();
            _driver.FindElement(By.XPath("//label[contains(.,'production.date.end')]")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
            DateTime start = DateTime.UtcNow;
            _driver.FindElement(By.Id("map_name")).SendKeys("TestKenrickMapping" + start);
           // _driver.FindElement(By.Id("map_name")).SendKeys("TestKenrickMapping");
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Submit and continue']")).Click();

        }

        [Then(@"I should see the newly uploaded file with the status Upload awaiting your mapping")]
        public void ThenIShouldSeeTheNewlyUploadedFileWithTheStatusUploadAwaitingYourMapping()
        {
            _driver.FindElement(By.CssSelector(".discoveryPrimaryCallToActionLink:nth-child(1)")).Click();
        }
    }
}

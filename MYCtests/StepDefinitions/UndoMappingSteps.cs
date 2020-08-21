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
    public class UndoMappingSteps
    {
        private string ChangeColumNamePath;
        public IWebDriver _driver;
        [Given(@"I am on MYC page, sign in and go to mapping page")]
        public void GivenIAmOnMYCPageSignInAndGoToMappingPage()
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
        
        [Given(@"I am at the Mapping Page")]
        public void GivenIAmAtTheMappingPage()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.LinkText("Map fields to Discovery >")).Click();
            Thread.Sleep(1000);
        }
        
        [Given(@"Pairs of items have been added to the list of Matched fields")]
        public void GivenPairsOfItemsHaveBeenAddedToTheListOfMatchedFields()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

            js.ExecuteScript("window.scrollTo(0, 800)");
            _driver.FindElement(By.XPath("//label[contains(.,'Level Of Description')]")).Click();
            _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[3]/label")).Click();
            _driver.FindElement(By.Id("match")).Click();
            Thread.Sleep(1000);
        }
        
        [When(@"I click an undo button")]
        public void WhenIClickAnUndoButton()
        {
            _driver.FindElement(By.LinkText("Undo")).Click();
            Thread.Sleep(3000);
        }
        
        [Then(@"the mapped pair of fields is removed from the list of Matched fields")]
        public void ThenTheMappedPairOfFieldsIsRemovedFromTheListOfMatchedFields()
        {
            _driver.Navigate().Refresh();
            String DiscoveryField = _driver.FindElement(By.XPath("//label[contains(.,'Level Of Description')]")).Text;
            Console.WriteLine(DiscoveryField);
            Assert.AreEqual("Level Of Description", DiscoveryField);
            String SelectYourField = _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[3]/label")).Text;
            Console.WriteLine(SelectYourField);
            Assert.AreEqual("Level Of Description", SelectYourField);
        }
        
        [Then(@"the corresponding Discovery and your fields return to their lists")]
        public void ThenTheCorrespondingDiscoveryAndYourFieldsReturnToTheirLists()
        {
            _driver.Close();
        }
        [Given(@"more pair of items added to the list of Matched fields")]
        public void GivenMorePairOfItemsAddedToTheListOfMatchedFields()
        {
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;

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
        }

        [When(@"I click the undo all button")]
        public void WhenIClickTheUndoAllButton()
        {
            _driver.FindElement(By.LinkText("Undo all")).Click();
            Thread.Sleep(3000);
        }

        [Then(@"all mapped pairs of fields are removed from the list of matched fields")]
        public void ThenAllMappedPairsOfFieldsAreRemovedFromTheListOfMatchedFields()
        {
            _driver.Navigate().Refresh();
            String DiscoveryField1 = _driver.FindElement(By.XPath("//label[contains(.,'Level Of Description')]")).Text;
            Console.WriteLine(DiscoveryField1);
            Assert.AreEqual("Level Of Description", DiscoveryField1);
            String SelectYourField1 = _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[3]/label")).Text;
            Console.WriteLine(SelectYourField1);
            Assert.AreEqual("Level Of Description", SelectYourField1);

            String DiscoveryField2 = _driver.FindElement(By.XPath("//label[contains(.,'Title')]")).Text;
            Console.WriteLine(DiscoveryField2);
            Assert.AreEqual("Title", DiscoveryField2);
            String SelectYourField2 = _driver.FindElement(By.XPath("//label[contains(.,'Titles')]")).Text;
            Console.WriteLine(SelectYourField2);
            Assert.AreEqual("Titles", SelectYourField2);

            String DiscoveryField3 = _driver.FindElement(By.XPath("//label[contains(.,'Name Of Creator(s)')]")).Text;
            Console.WriteLine(DiscoveryField3);
            Assert.AreEqual("Name Of Creator(s)", DiscoveryField3);
            String SelectYourField3 = _driver.FindElement(By.XPath("//div[@id='custom-fields']/div[5]/label")).Text;
            Console.WriteLine(SelectYourField3);
            Assert.AreEqual("Name Of Creator(s)", SelectYourField3);

        }

        [Then(@"all previously matched items are returned to the list of Discovery fields and your fields\.")]
        public void ThenAllPreviouslyMatchedItemsAreReturnedToTheListOfDiscoveryFieldsAndYourFields_()
        {
            _driver.Close();
        }

    }
}

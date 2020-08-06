using Microsoft.Extensions.Configuration;
using Nunit_NetCore;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Threading;
using TechTalk.SpecFlow;

namespace MYCtests.StepDefinitions
{
    [Binding]
    public class DeleteSavedMappingSteps
    {
        private string KenrickCollectionPath;
        public IWebDriver _driver;

        [Given(@"I am on MYC page and I sign in to delete saved mapping")]
        public void GivenIAmOnMYCPageAndISignInToDeleteSavedMapping()
        {
            _driver = new PageNavigator().GoToMYCPage();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
            var pageNavigator = new PageNavigator();
            KenrickCollectionPath = pageNavigator.Configuration.GetValue<string>("KenrickCollectionPath");
        }
        [When(@"I upload a file and go to view history")]
        public void WhenIUploadAFileAndGoToViewHistory()
        {
            _driver.FindElement(By.LinkText("Add a collection")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("upload")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//form[@id='upload-form']/div/label/span")).Click();
            _driver.SwitchTo().ActiveElement().SendKeys(KenrickCollectionPath);
            _driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
        }
        [When(@"Click on map fields to Discovery")]
        public void WhenClickOnMapFieldsToDiscovery()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("Map fields to Discovery >")).Click();
            Thread.Sleep(1000);
        }
        
        [When(@"I am at the Mapping Page and map the fields and save the mapping")]
        public void WhenIAmAtTheMappingPageAndMapTheFieldsAndSaveTheMapping()
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
            _driver.FindElement(By.Id("map_name")).SendKeys("TestMapping");
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Submit and continue']")).Click();
        }
        
        [When(@"I select a mapping from the list of saved mappings")]
        public void WhenISelectAMappingFromTheListOfSavedMappings()
        {
            _driver.FindElement(By.LinkText("Add a collection")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("upload")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//form[@id='upload-form']/div/label/span")).Click();
            _driver.SwitchTo().ActiveElement().SendKeys(KenrickCollectionPath);
            _driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("Map fields to Discovery >")).Click();
            Thread.Sleep(1000);
        }
        
        [When(@"select Delete this mapping")]
        public void WhenSelectDeleteThisMapping()
        {
            SelectElement oSelect = new SelectElement(_driver.FindElement(By.Id("metadata-map")));
            oSelect.SelectByText("TestMapping");
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Select']")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 400)");
            _driver.FindElement(By.Id("delete-mapping")).Click();

        }
        
        [Then(@"the deletion overlay screen should appear to approve and reject")]
        public void ThenTheDeletionOverlayScreenShouldAppearToApproveAndReject()
        {
            String overlayScreen = _driver.FindElement(By.XPath("//form[@id='delete-mapping-form']")).Text;
            Console.WriteLine(overlayScreen);
            //_driver.SwitchTo().Alert().Accept();

        }

        [Then(@"I can click yet to delete saved mapping")]
        public void ThenICanClickYetToDeleteSavedMapping()
        {
            _driver.FindElement(By.XPath("//input[@type='submit' and @value='Yes']")).Click();
            _driver.Quit();
        }
    }
}

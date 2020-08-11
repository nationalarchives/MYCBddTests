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
    public class ValidationTestsSteps
    {
        public IWebDriver _driver;
        [Given(@"I am on MYC page and I sign in")]
        public void GivenIAmOnMYCPageAndISignIn()
        {
            _driver = new PageNavigator().GoToMYCPage();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
        }

        [When(@"Go to Add a collection")]
        public void WhenGoToAddACollection()
        {
            _driver.FindElement(By.LinkText("Add a collection")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("upload")).Click();
            Thread.Sleep(1000);
        }


        [When(@"upload ""(.*)"" type")]
        public void WhenUploadType(string invalidFilePath)
        {
            var pageNavigator = new PageNavigator();
            var path = pageNavigator.Configuration.GetValue<string>(invalidFilePath);
            _driver.FindElement(By.XPath("//input[@type='file']")).SendKeys(path);
            _driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
            Thread.Sleep(2000);
        }
        [When(@"check for the upload message The file has been added to the queue for upload\. Please go to View history for more details\.")]
        public void WhenCheckForTheUploadMessageTheFileHasBeenAddedToTheQueueForUpload_PleaseGoToViewHistoryForMoreDetails_()
        {
            string uploadMsg = _driver.FindElement(By.CssSelector(".emphasis-block > span")).Text;
            Assert.IsTrue(uploadMsg.Contains("The file has been added to the queue for upload. Please go to View history for more details."));
        }

        [Then(@"go to View history and see error report ""(.*)""")]
        public void ThenGoToViewHistoryAndSeeErrorReport(string errorMsg)
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.CssSelector(".discoveryPrimaryCallToActionLink:nth-child(1)")).Click();
            Thread.Sleep(3000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 500)");
            _driver.FindElement(By.LinkText("See error report >")).Click();
            Thread.Sleep(2000);
            string actualErrorMsg = _driver.FindElement(By.XPath("//main[@id='page_wrap']/div/div/div[2]/div[2]/table/tbody/tr/td[2]")).Text;
            Assert.AreEqual(actualErrorMsg, errorMsg);
            _driver.Quit();
        }
        [Then(@"go to View history and see the ""(.*)""")]
        public void ThenGoToViewHistoryAndSeeThe(string errorMsg)
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            string warningMessage = _driver.FindElement(By.ClassName("warning")).Text;
            Assert.AreEqual(warningMessage, errorMsg);
            _driver.Quit();
        }
        [Then(@"go to View history and click on preview and approve")]
        public void ThenGoToViewHistoryAndClickOnPreviewAndApprove()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(2000);
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.LinkText("Preview and approve >")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("actionState")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.CssSelector(".discoveryPrimaryCallToActionLink:nth-child(1)")).Click();
        }
        [Then(@"see the ""(.*)""")]
        public void ThenSeeThe(string errorMsg)
        {
            string actualErrorMsg = _driver.FindElement(By.XPath("//*[@id='page_wrap']/div/div/div[2]/div[2]/table/tbody/tr/td[2]")).Text;
            Assert.AreEqual(actualErrorMsg, errorMsg);
        }


    }
}

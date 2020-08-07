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
    public class ValidFilesUploadSteps
    {
        private string FondsPath;
        private string FondsAndSubFondsPath;
        private string SeriesPath;
        private string AllLevelsPath;

        public IWebDriver _driver;


        [Given(@"I am on MYC page, sign in")]
        public void GivenIAmOnMYCPageSignIn()
        {
            _driver = new PageNavigator().GoToMYCPage();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
            var pageNavigator = new PageNavigator();
            FondsPath = pageNavigator.Configuration.GetValue<string>("FondsPath");
            FondsAndSubFondsPath = pageNavigator.Configuration.GetValue<string>("FondsAndSubFondsPath");
            SeriesPath = pageNavigator.Configuration.GetValue<string>("SeriesPath");
            AllLevelsPath = pageNavigator.Configuration.GetValue<string>("AllLevelsPath");


        }

        [When(@"I upload the ""(.*)""")]
        public void WhenIUploadThe(string validFiles)
        {
            _driver.FindElement(By.LinkText("Add a collection")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Id("upload")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.XPath("//form[@id='upload-form']/div/label/span")).Click();
            if (validFiles == "FondsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(FondsPath);
            }
            if (validFiles == "FondsAndSubFondsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(FondsAndSubFondsPath);
            }
            if (validFiles == "SeriesPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SeriesPath);
            }
            if (validFiles == "AllLevelsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(AllLevelsPath);
            }

            _driver.FindElement(By.XPath("//input[@value='Upload']")).Click();
            Thread.Sleep(2000);
            string uploadMsg = _driver.FindElement(By.CssSelector(".emphasis-block > span")).Text;
            Assert.IsTrue(uploadMsg.Contains("The file has been added to the queue for upload. Please go to View history for more details."));
        }

        [Then(@"check for the message upload completed")]
        public void ThenCheckForTheMessageUploadCompleted()
        {
            _driver.FindElement(By.LinkText("View history")).Click();
            Thread.Sleep(3000);
            _driver.FindElement(By.CssSelector(".discoveryPrimaryCallToActionLink:nth-child(1)")).Click();
            IJavaScriptExecutor js = (IJavaScriptExecutor)_driver;
            js.ExecuteScript("window.scrollTo(0, 600)");
            _driver.FindElement(By.LinkText("Preview and approve >")).Click();
            Thread.Sleep(1000);
            _driver.FindElement(By.Name("actionState")).Click();
            Thread.Sleep(2000);
            _driver.FindElement(By.CssSelector(".discoveryPrimaryCallToActionLink:nth-child(1)")).Click();
            string uploadMsg = _driver.FindElement(By.XPath("//div[@class='collection upload'][1]")).Text;
            Assert.IsTrue(uploadMsg.Contains("Upload completed"));
            _driver.Close();
        }
    }
}

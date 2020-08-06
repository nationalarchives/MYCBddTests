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
        private string DateValidationFilePath;
        private string EmptyFilePath;
        private string ChangeColumNamePath;
        private string FondsWithNoLegalStatusPath;
        private string FondsWithNoNameOfCreatorsPath;
        private string FondsWithNoReferencePath;
        private string InvalidFilePath;
        private string ItemLevelPath;
        private string ModifyLevelNamePath;
        private string SubFondsPath;
        private string SubItemPath;
        private string SubSeriesPath;
        private string SubSubFondsPath;
        private string SubSubSeriesPath;
        private string SubSubSubFondsPath;
        private string SubSubSubSeriesPath;
        private string DiscoveryFormsXlsFormat;


        public IWebDriver _driver;
        [Given(@"I am on MYC page and I sign in")]
        public void GivenIAmOnMYCPageAndISignIn()
        {
            _driver = new PageNavigator().GoToMYCPage();
           var webDriver = new PageNavigator();
           webDriver.SingleSignOn(_driver);
            var pageNavigator = new PageNavigator();
            DateValidationFilePath = pageNavigator.Configuration.GetValue<string>("DateValidationFilePath");
            EmptyFilePath = pageNavigator.Configuration.GetValue<string>("EmptyFilePath");
            ChangeColumNamePath = pageNavigator.Configuration.GetValue<string>("ChangeColumNamePath");
            FondsWithNoLegalStatusPath = pageNavigator.Configuration.GetValue<string>("FondsWithNoLegalStatusPath");
            FondsWithNoNameOfCreatorsPath = pageNavigator.Configuration.GetValue<string>("FondsWithNoNameOfCreatorsPath");
            FondsWithNoReferencePath = pageNavigator.Configuration.GetValue<string>("FondsWithNoReferencePath");
            InvalidFilePath = pageNavigator.Configuration.GetValue<string>("InvalidFilePath");
            ItemLevelPath = pageNavigator.Configuration.GetValue<string>("ItemLevelPath");
            ModifyLevelNamePath = pageNavigator.Configuration.GetValue<string>("ModifyLevelNamePath");
            SubFondsPath = pageNavigator.Configuration.GetValue<string>("SubFondsPath");
            SubItemPath = pageNavigator.Configuration.GetValue<string>("SubItemPath");
            SubSeriesPath = pageNavigator.Configuration.GetValue<string>("SubSeriesPath");
            SubSubFondsPath = pageNavigator.Configuration.GetValue<string>("SubSubFondsPath");
            SubSubSeriesPath = pageNavigator.Configuration.GetValue<string>("SubSubSeriesPath");
            SubSubSubFondsPath = pageNavigator.Configuration.GetValue<string>("SubSubSubFondsPath");
            SubSubSubSeriesPath = pageNavigator.Configuration.GetValue<string>("SubSubSubSeriesPath");
            DiscoveryFormsXlsFormat = pageNavigator.Configuration.GetValue<string>("DiscoveryFormsXlsFormat");
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
            // _driver.FindElement(By.XPath("//*[@id='upload-form']/div/label/strong")).Click();
            //_driver.FindElement(By.XPath("//input[@type='file']")).SendKeys("C:\\Projects\\ExpertContributions\\Test\\Data\\Validationtsv\\Empty file_Mapper.tsv");

            _driver.FindElement(By.XPath("//form[@id='upload-form']/div/label/span")).Click();

           // _driver.SwitchTo().Alert();
            // _driver.actions().sendKeys(protractor.Key.ENTER).perform();
            if (invalidFilePath == "DateValidationFilePath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(DateValidationFilePath);
            }
            if(invalidFilePath == "EmptyFilePath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(EmptyFilePath);
            }
            if (invalidFilePath == "ChangeColumNamePath")
            { 
                _driver.SwitchTo().ActiveElement().SendKeys(ChangeColumNamePath);
            }
            if (invalidFilePath == "FondsWithNoLegalStatusPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(FondsWithNoLegalStatusPath);
            }
            if (invalidFilePath == "FondsWithNoNameOfCreatorsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(FondsWithNoNameOfCreatorsPath);
            }
            if (invalidFilePath == "FondsWithNoReferencePath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(FondsWithNoReferencePath);
            }
            if (invalidFilePath == "InvalidFilePath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(InvalidFilePath);
            }
            if (invalidFilePath == "ItemLevelPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(ItemLevelPath);
            }
            if (invalidFilePath == "ModifyLevelNamePath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(ModifyLevelNamePath);
            }
            if (invalidFilePath == "SubFondsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubFondsPath);
            }
            if (invalidFilePath == "SubItemPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubItemPath);
            }
            if (invalidFilePath == "SubSeriesPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubSeriesPath);
            }
            if (invalidFilePath == "SubSubFondsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubSubFondsPath);
            }
            if (invalidFilePath == "SubSubSeriesPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubSubSeriesPath);
            }
            if (invalidFilePath == "SubSubSubFondsPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubSubSubFondsPath);
            }
            if (invalidFilePath == "SubSubSubSeriesPath")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(SubSubSubSeriesPath);
            }
            if (invalidFilePath == "DiscoveryFormsXlsFormat")
            {
                _driver.SwitchTo().ActiveElement().SendKeys(DiscoveryFormsXlsFormat);
            }
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
            string warningMessage =_driver.FindElement(By.ClassName("warning")).Text;
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

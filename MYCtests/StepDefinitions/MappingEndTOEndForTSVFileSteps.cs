using Microsoft.Extensions.Configuration;
using Nunit_NetCore;
using OpenQA.Selenium;
using System;
using TechTalk.SpecFlow;

namespace MYCtests.StepDefinitions
{
    [Binding]
    public class MappingEndTOEndForTSVFileSteps
    {
        private string KenrickCollectionPath;
        public IWebDriver _driver;
        [Given(@"that I am at the Mapping Page with uploaded tsv file")]
        public void GivenThatIAmAtTheMappingPageWithUploadedTsvFile()
        {
            _driver = new PageNavigator().GoToMYCPage();
            var webDriver = new PageNavigator();
            webDriver.SingleSignOn(_driver);
            var pageNavigator = new PageNavigator();
            KenrickCollectionPath = pageNavigator.Configuration.GetValue<string>("KenrickCollectionPath");
        }

        [Given(@"mandatory fields have been added to the list of Matched fields for tsv file")]
        public void GivenMandatoryFieldsHaveBeenAddedToTheListOfMatchedFieldsForTsvFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"I click the Submit and continue button")]
        public void WhenIClickTheSubmitAndContinueButton()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"Enter the mapping Name for tsv file")]
        public void ThenEnterTheMappingNameForTsvFile()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I arrive at the view history page")]
        public void ThenIArriveAtTheViewHistoryPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"I see an information message stating that my file has been successfully mapped")]
        public void ThenISeeAnInformationMessageStatingThatMyFileHasBeenSuccessfullyMapped()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the file moves on to validation")]
        public void ThenTheFileMovesOnToValidation()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"click Preview and Approve")]
        public void ThenClickPreviewAndApprove()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"click Approve")]
        public void ThenClickApprove()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"click refresh to see collection upload compted")]
        public void ThenClickRefreshToSeeCollectionUploadCompted()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"click view in discovery to see the detail page of this collection")]
        public void ThenClickViewInDiscoveryToSeeTheDetailPageOfThisCollection()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

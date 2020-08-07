﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.3.0.0
//      SpecFlow Generator Version:3.1.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace MYCtests.FeatureFiles
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.3.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [NUnit.Framework.TestFixtureAttribute()]
    [NUnit.Framework.DescriptionAttribute("validationTests")]
    public partial class ValidationTestsFeature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "validationTests.feature"
#line hidden
        
        [NUnit.Framework.OneTimeSetUpAttribute()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-GB"), "validationTests", null, ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [NUnit.Framework.OneTimeTearDownAttribute()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        [NUnit.Framework.SetUpAttribute()]
        public virtual void TestInitialize()
        {
        }
        
        [NUnit.Framework.TearDownAttribute()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
            testRunner.ScenarioContext.ScenarioContainer.RegisterInstanceAs<NUnit.Framework.TestContext>(NUnit.Framework.TestContext.CurrentContext);
        }
        
        public virtual void ScenarioStart()
        {
            testRunner.OnScenarioStart();
        }
        
        public virtual void ScenarioCleanup()
        {
            testRunner.CollectScenarioErrors();
        }
        
        public virtual void FeatureBackground()
        {
#line 3
#line hidden
#line 4
 testRunner.Given("I am on MYC page and I sign in", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 5
 testRunner.When("Go to Add a collection", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("Data Validation")]
        [NUnit.Framework.CategoryAttribute("mytag")]
        [NUnit.Framework.TestCaseAttribute("EmptyFilePath", "Your template is empty - it does not contain any catalogue information.", null)]
        [NUnit.Framework.TestCaseAttribute("DateValidationFilePath", "Your collection must have either \'covering dates\', or a \'start date\' and an \'end " +
            "date\'.", null)]
        [NUnit.Framework.TestCaseAttribute("FondsWithNoNameOfCreatorsPath", "\'Creator name\' is a required field at fonds level for this collection.", null)]
        [NUnit.Framework.TestCaseAttribute("FondsWithNoReferencePath", "\'Reference code\' is a required field at fonds level for this collection.", null)]
        [NUnit.Framework.TestCaseAttribute("InvalidFilePath", "types of error(s)/0 types of warning(s)", null)]
        [NUnit.Framework.TestCaseAttribute("ItemLevelPath", "We require a valid level hierarchy in this field. It is not possible to have item" +
            " directly under fonds", null)]
        [NUnit.Framework.TestCaseAttribute("ModifyLevelNamePath", "We expect to see \'fonds\' in this field; it currently contains \'fond\'", null)]
        [NUnit.Framework.TestCaseAttribute("SubFondsPath", "We expect to see \'fonds\' in this field; it currently contains \'sub-fonds\'", null)]
        [NUnit.Framework.TestCaseAttribute("SubItemPath", "We require a valid level hierarchy in this field. It is not possible to have sub-" +
            "item directly under file", null)]
        [NUnit.Framework.TestCaseAttribute("SubSeriesPath", "We require a valid level hierarchy in this field. It is not possible to have sub-" +
            "series directly under fonds", null)]
        [NUnit.Framework.TestCaseAttribute("SubSubFondsPath", "We require a valid level hierarchy in this field. It is not possible to have sub-" +
            "sub-fonds directly under fonds", null)]
        [NUnit.Framework.TestCaseAttribute("SubSubSeriesPath", "We require a valid level hierarchy in this field. It is not possible to have sub-" +
            "sub-series directly under series", null)]
        [NUnit.Framework.TestCaseAttribute("SubSubSubFondsPath", "We require a valid level hierarchy in this field. It is not possible to have sub-" +
            "sub-sub-fonds directly under fonds", null)]
        [NUnit.Framework.TestCaseAttribute("SubSubSubSeriesPath", "We require a valid level hierarchy in this field. It is not possible to have sub-" +
            "sub-sub-series directly under series", null)]
        public virtual void DataValidation(string invalidFilePath, string errorMsg, string[] exampleTags)
        {
            string[] @__tags = new string[] {
                    "mytag"};
            if ((exampleTags != null))
            {
                @__tags = System.Linq.Enumerable.ToArray(System.Linq.Enumerable.Concat(@__tags, exampleTags));
            }
            string[] tagsOfScenario = @__tags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("invalidFilePath", invalidFilePath);
            argumentsOfScenario.Add("errorMsg", errorMsg);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("Data Validation", null, tagsOfScenario, argumentsOfScenario);
#line 8
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 9
 testRunner.When(string.Format("upload \"{0}\" type", invalidFilePath), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 10
 testRunner.And("check for the upload message The file has been added to the queue for upload. Ple" +
                        "ase go to View history for more details.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 11
 testRunner.Then(string.Format("go to View history and see error report \"{0}\"", errorMsg), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("ChangeColumNamePath")]
        [NUnit.Framework.TestCaseAttribute("ChangeColumNamePath", "There was a problem with our system; please try again later.(If you are seeing th" +
            "is error repeatedly, contact us)", null)]
        public virtual void ChangeColumNamePath(string invalidFilePath, string errorMsg, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("invalidFilePath", invalidFilePath);
            argumentsOfScenario.Add("errorMsg", errorMsg);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("ChangeColumNamePath", null, tagsOfScenario, argumentsOfScenario);
#line 31
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 32
 testRunner.When(string.Format("upload \"{0}\" type", invalidFilePath), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 33
 testRunner.And("check for the upload message The file has been added to the queue for upload. Ple" +
                        "ase go to View history for more details.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 34
 testRunner.Then(string.Format("go to View history and see the \"{0}\"", errorMsg), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [NUnit.Framework.TestAttribute()]
        [NUnit.Framework.DescriptionAttribute("FondsWithNoLegalStatus")]
        [NUnit.Framework.TestCaseAttribute("FondsWithNoLegalStatusPath", "\'Legal status\' is a required field at fonds level for this collection.", null)]
        public virtual void FondsWithNoLegalStatus(string invalidFilePath, string errorMsg, string[] exampleTags)
        {
            string[] tagsOfScenario = exampleTags;
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            argumentsOfScenario.Add("invalidFilePath", invalidFilePath);
            argumentsOfScenario.Add("errorMsg", errorMsg);
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("FondsWithNoLegalStatus", null, tagsOfScenario, argumentsOfScenario);
#line 40
this.ScenarioInitialize(scenarioInfo);
#line hidden
            bool isScenarioIgnored = default(bool);
            bool isFeatureIgnored = default(bool);
            if ((tagsOfScenario != null))
            {
                isScenarioIgnored = tagsOfScenario.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((this._featureTags != null))
            {
                isFeatureIgnored = this._featureTags.Where(__entry => __entry != null).Where(__entry => String.Equals(__entry, "ignore", StringComparison.CurrentCultureIgnoreCase)).Any();
            }
            if ((isScenarioIgnored || isFeatureIgnored))
            {
                testRunner.SkipScenario();
            }
            else
            {
                this.ScenarioStart();
#line 3
this.FeatureBackground();
#line hidden
#line 41
 testRunner.When(string.Format("upload \"{0}\" type", invalidFilePath), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 42
 testRunner.And("check for the upload message The file has been added to the queue for upload. Ple" +
                        "ase go to View history for more details.", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 43
 testRunner.Then("go to View history and click on preview and approve", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
#line 44
 testRunner.And(string.Format("see the \"{0}\"", errorMsg), ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion

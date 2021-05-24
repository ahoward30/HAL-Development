﻿// ------------------------------------------------------------------------------
//  <auto-generated>
//      This code was generated by SpecFlow (https://www.specflow.org/).
//      SpecFlow Version:3.7.0.0
//      SpecFlow Generator Version:3.7.0.0
// 
//      Changes to this file may cause incorrect behavior and will be lost if
//      the code is regenerated.
//  </auto-generated>
// ------------------------------------------------------------------------------
#region Designer generated code
#pragma warning disable
namespace ITMatching.BDDTests.Features
{
    using TechTalk.SpecFlow;
    using System;
    using System.Linq;
    
    
    [System.CodeDom.Compiler.GeneratedCodeAttribute("TechTalk.SpecFlow", "3.7.0.0")]
    [System.Runtime.CompilerServices.CompilerGeneratedAttribute()]
    [TechTalk.SpecRun.FeatureAttribute("As a client, I want the meeting room to be fully responsive while matching and to" +
        " be periodically updated with relevant info while I am waiting to be matched wit" +
        "h an expert.", Description="\tResponsive Client Waiting Room", SourceFile="Features\\ResponsiveClientWaitingRoom.feature", SourceLine=0)]
    public partial class AsAClientIWantTheMeetingRoomToBeFullyResponsiveWhileMatchingAndToBePeriodicallyUpdatedWithRelevantInfoWhileIAmWaitingToBeMatchedWithAnExpert_Feature
    {
        
        private TechTalk.SpecFlow.ITestRunner testRunner;
        
        private string[] _featureTags = ((string[])(null));
        
#line 1 "ResponsiveClientWaitingRoom.feature"
#line hidden
        
        [TechTalk.SpecRun.FeatureInitialize()]
        public virtual void FeatureSetup()
        {
            testRunner = TechTalk.SpecFlow.TestRunnerManager.GetTestRunner();
            TechTalk.SpecFlow.FeatureInfo featureInfo = new TechTalk.SpecFlow.FeatureInfo(new System.Globalization.CultureInfo("en-US"), "Features", "As a client, I want the meeting room to be fully responsive while matching and to" +
                    " be periodically updated with relevant info while I am waiting to be matched wit" +
                    "h an expert.", "\tResponsive Client Waiting Room", ProgrammingLanguage.CSharp, ((string[])(null)));
            testRunner.OnFeatureStart(featureInfo);
        }
        
        [TechTalk.SpecRun.FeatureCleanup()]
        public virtual void FeatureTearDown()
        {
            testRunner.OnFeatureEnd();
            testRunner = null;
        }
        
        public virtual void TestInitialize()
        {
        }
        
        [TechTalk.SpecRun.ScenarioCleanup()]
        public virtual void TestTearDown()
        {
            testRunner.OnScenarioEnd();
        }
        
        public virtual void ScenarioInitialize(TechTalk.SpecFlow.ScenarioInfo scenarioInfo)
        {
            testRunner.OnScenarioInitialize(scenarioInfo);
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
#line 4
#line hidden
            TechTalk.SpecFlow.Table table1 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "ASPNetUserID",
                        "UserName",
                        "FirstName",
                        "LastName",
                        "Email",
                        "PhoneNumber"});
            table1.AddRow(new string[] {
                        "1",
                        "12b",
                        "aa@a.a",
                        "Al",
                        "Adams",
                        "aa@a.a",
                        "1112223333"});
            table1.AddRow(new string[] {
                        "2",
                        "32c",
                        "bb@b.b",
                        "Ben",
                        "Burger",
                        "bb@b.b",
                        "3232231111"});
#line 5
 testRunner.Given("the following ITMUsers exist", ((string)(null)), table1, "Given ");
#line hidden
            TechTalk.SpecFlow.Table table2 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "ITMUserID",
                        "WorkSchedule",
                        "IsAvailable"});
            table2.AddRow(new string[] {
                        "1",
                        "4",
                        "NULL",
                        "True"});
            table2.AddRow(new string[] {
                        "2",
                        "5",
                        "NULL",
                        "True"});
            table2.AddRow(new string[] {
                        "3",
                        "6",
                        "NULL",
                        "True"});
            table2.AddRow(new string[] {
                        "4",
                        "7",
                        "NULL",
                        "False"});
#line 9
 testRunner.And("the following Experts exist", ((string)(null)), table2, "And ");
#line hidden
            TechTalk.SpecFlow.Table table3 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "ClientID",
                        "RequestTitle",
                        "RequestDescription",
                        "IsOpen"});
            table3.AddRow(new string[] {
                        "1",
                        "1",
                        "\"Broken Mouse\"",
                        "\"Mouse is broken.\"",
                        "True"});
            table3.AddRow(new string[] {
                        "2",
                        "2",
                        "\"Dead Pixel\"",
                        "\"Bad Screen.\"",
                        "True"});
#line 15
 testRunner.And("the following HelpRequests exist", ((string)(null)), table3, "And ");
#line hidden
            TechTalk.SpecFlow.Table table4 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "ServiceId",
                        "RequestId"});
            table4.AddRow(new string[] {
                        "1",
                        "1",
                        "1"});
            table4.AddRow(new string[] {
                        "2",
                        "1",
                        "2"});
#line 19
 testRunner.And("the following RequestServices exist", ((string)(null)), table4, "And ");
#line hidden
            TechTalk.SpecFlow.Table table5 = new TechTalk.SpecFlow.Table(new string[] {
                        "ID",
                        "ServiceId",
                        "ExpertId"});
            table5.AddRow(new string[] {
                        "1",
                        "1",
                        "1"});
            table5.AddRow(new string[] {
                        "2",
                        "1",
                        "2"});
#line 23
 testRunner.And("the following ExpertServices exist", ((string)(null)), table5, "And ");
#line hidden
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("As a client, I need to page to update periodically, so that I can have up to date" +
            " information on the matching process.", SourceLine=27)]
        public virtual void AsAClientINeedToPageToUpdatePeriodicallySoThatICanHaveUpToDateInformationOnTheMatchingProcess_()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a client, I need to page to update periodically, so that I can have up to date" +
                    " information on the matching process.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 28
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
#line 4
this.FeatureBackground();
#line hidden
#line 29
 testRunner.Given("I am an ITMUser with an ID of \'<ID>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 30
 testRunner.And("I have an open Help Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 31
 testRunner.And("I am on the ClientWaitingRoom page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 32
 testRunner.When("5 seconds has elapsed since the timer started", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 33
 testRunner.Then("the page should refresh", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("As a client, I want to know how many experts are online while I am searching for " +
            "a match, so I may know how likely a match is.", SourceLine=34)]
        public virtual void AsAClientIWantToKnowHowManyExpertsAreOnlineWhileIAmSearchingForAMatchSoIMayKnowHowLikelyAMatchIs_()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a client, I want to know how many experts are online while I am searching for " +
                    "a match, so I may know how likely a match is.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 35
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
#line 4
this.FeatureBackground();
#line hidden
#line 36
 testRunner.Given("I am an ITMUser with an ID of \'<ID>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 37
 testRunner.And("I have an open Help Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 38
 testRunner.And("I am on the ClientWaitingRoom page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 39
 testRunner.When("the page loads", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 40
 testRunner.Then("the onlineExpertCounter should display 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
        
        [TechTalk.SpecRun.ScenarioAttribute("As a client, I want to know how many online experts are appropriate matches while" +
            " I am searching for a match, so I may know how likely a match is.", SourceLine=41)]
        public virtual void AsAClientIWantToKnowHowManyOnlineExpertsAreAppropriateMatchesWhileIAmSearchingForAMatchSoIMayKnowHowLikelyAMatchIs_()
        {
            string[] tagsOfScenario = ((string[])(null));
            System.Collections.Specialized.OrderedDictionary argumentsOfScenario = new System.Collections.Specialized.OrderedDictionary();
            TechTalk.SpecFlow.ScenarioInfo scenarioInfo = new TechTalk.SpecFlow.ScenarioInfo("As a client, I want to know how many online experts are appropriate matches while" +
                    " I am searching for a match, so I may know how likely a match is.", null, tagsOfScenario, argumentsOfScenario, this._featureTags);
#line 42
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
#line 4
this.FeatureBackground();
#line hidden
#line 43
 testRunner.Given("I am an ITMUser with an ID of \'<ID>\'", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Given ");
#line hidden
#line 44
 testRunner.And("I have an open Help Request", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 45
 testRunner.And("I am on the ClientWaitingRoom page", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "And ");
#line hidden
#line 46
 testRunner.When("the page loads", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "When ");
#line hidden
#line 47
 testRunner.Then("the potentialMatchingExpertCounter should display 3", ((string)(null)), ((TechTalk.SpecFlow.Table)(null)), "Then ");
#line hidden
            }
            this.ScenarioCleanup();
        }
    }
}
#pragma warning restore
#endregion
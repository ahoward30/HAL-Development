using System;
using TechTalk.SpecFlow;

namespace ITMatching.BDDTests.Steps
{
    [Binding]
    public class AsAClientWhoHasFinishedAMeetingIWouldLikeToBePromptedWithAMessageAskingMeIfIFeltLikeMyExpertWasHelpfulOrNotSoThatMyFeedbackMayInfluenceFutureMatching_Steps
    {
        [Given(@"the client is logged in")]
        public void GivenTheClientIsLoggedIn()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"the client is on the Feedback Page")]
        public void GivenTheClientIsOnTheFeedbackPage()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"(.*) experts are offline")]
        public void GivenExpertsAreOffline(int p0)
        {
            ScenarioContext.Current.Pending();
        }
        
        [Given(@"they have the same tags")]
        public void GivenTheyHaveTheSameTags()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"the client submits a response")]
        public void WhenTheClientSubmitsAResponse()
        {
            ScenarioContext.Current.Pending();
        }
        
        [When(@"they match with a client")]
        public void WhenTheyMatchWithAClient()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the response should be reflected on the meeting object")]
        public void ThenTheResponseShouldBeReflectedOnTheMeetingObject()
        {
            ScenarioContext.Current.Pending();
        }
        
        [Then(@"the expert with a higher satisfaction percent should be displayed first")]
        public void ThenTheExpertWithAHigherSatisfactionPercentShouldBeDisplayedFirst()
        {
            ScenarioContext.Current.Pending();
        }
    }
}

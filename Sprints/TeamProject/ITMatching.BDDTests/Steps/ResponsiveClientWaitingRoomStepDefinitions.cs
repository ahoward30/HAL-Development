using System;
using ITMatching.Models;
using System.Collections.Generic;
using System.Linq;
using NUnit.Framework;
using System.Text;
using System.Threading;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;
using OpenQA.Selenium;

namespace ITMatching.BDDTests.Steps
{
    [Binding]
    public class AsAClientIWantTheMeetingRoomToBeFullyResponsiveWhileMatchingAndToBePeriodicallyUpdatedWithRelevantInfoWhileIAmWaitingToBeMatchedWithAnExpert_Steps
    {
        private readonly ScenarioContext _ctx;
        private Table _userTable;
        private string _hostBaseName = @"https://localhost:44319/";

        public AsAClientIWantTheMeetingRoomToBeFullyResponsiveWhileMatchingAndToBePeriodicallyUpdatedWithRelevantInfoWhileIAmWaitingToBeMatchedWithAnExpert_Steps(ScenarioContext scenarioContext)
        {
            _ctx = scenarioContext;
        }

        [Given(@"the following ITMUsers exist")]
        public void GivenTheFollowingITMUsersExist(Table table)
        {
            IEnumerable<Itmuser> clients = table.CreateSet<Itmuser>();
            _ctx["Clients"] = clients;
        }

        [Given(@"the following Experts exist")]
        public void GivenTheFollowingExpertsExist(Table table)
        {
            IEnumerable<Expert> experts = table.CreateSet<Expert>();
            _ctx["Experts"] = experts;
        }

        [Given(@"the following HelpRequests exist")]
        public void GivenTheFollowingHelpRequestsExist(Table table)
        {
            IEnumerable<HelpRequest> hr = table.CreateSet<HelpRequest>();
            _ctx["HelpRequests"] = hr;
        }

        [Given(@"the following RequestServices exist")]
        public void GivenTheFollowingRequestServicesExist(Table table)
        {
            IEnumerable<RequestService> rs = table.CreateSet<RequestService>();
            _ctx["RequestServices"] = rs;
        }

        [Given(@"the following ExpertServices exist")]
        public void GivenTheFollowingExpertServicesExist(Table table)
        {
            IEnumerable<ExpertService> es = table.CreateSet<ExpertService>();
            _ctx["ExpertServices"] = es;
        }

        [Given(@"I am an ITMUser with userName of '(.*)'")]
        public void GivenIAmAnITMUserWithUserNameOf(string UserName)
        {
            _ctx["UserName"] = UserName;
        }

        [Given(@"I have an open Help Request")]
        public void GivenIHaveAnOpenHelpRequest()
        {
            string userName = (string)_ctx["UserName"];
            IEnumerable<Itmuser> clients = (IEnumerable<Itmuser>)_ctx["Clients"];
            IEnumerable<HelpRequest> helpRequests = (IEnumerable<HelpRequest>)_ctx["HelpRequests"];
            IEnumerable<RequestService> requestServices = (IEnumerable<RequestService>)_ctx["RequestServices"];
            Itmuser itu = clients.Where(itu => itu.UserName == userName).FirstOrDefault();
            HelpRequest hr = helpRequests.Where(hr => hr.ClientId == itu.Id && hr.IsOpen).FirstOrDefault();
            _ctx["HelpRequest"] = hr;

            _ctx["RequestService"] = requestServices.Where(rs => rs.RequestId == hr.Id).FirstOrDefault();
        }

        [Given(@"I am on the ClientWaitingRoom page")]
        public void GivenIAmOnTheClientWaitingRoomPage()
        {
            //Logging In
            IWebDriver driver = (IWebDriver)_ctx["WebDriver"];
            driver.Navigate().GoToUrl(_hostBaseName + @"Identity/Account/Login");
            string userName = (string)_ctx["UserName"];
            IEnumerable<Itmuser> clients = (IEnumerable<Itmuser>)_ctx["Clients"];
            Itmuser itu = clients.Where(itu => itu.UserName == userName).FirstOrDefault();
            driver.FindElement(By.Id("Input_Email")).SendKeys(itu.Email);
            driver.FindElement(By.Id("Input_Password")).SendKeys("!!!1AAAa");
            driver.FindElement(By.Id("account")).FindElement(By.CssSelector("button[type=submit]")).Click();

            //Resubmitting HelpRequest
            driver.Navigate().GoToUrl(_hostBaseName + @"Matching/RequestForm");
            HelpRequest hr = (HelpRequest)_ctx["HelpRequest"];
            RequestService rs = (RequestService)_ctx["RequestService"];
            string serviceId = rs.ServiceId.ToString();
            driver.FindElement(By.Id("HelpRequest.RequestTitle")).SendKeys(hr.RequestTitle);
            driver.FindElement(By.Id("HelpRequest.RequestDescription")).SendKeys(hr.RequestTitle);
            driver.FindElement(By.Id("HelpRequest.RequestTitle")).SendKeys(hr.RequestTitle);
            driver.FindElement(By.Id("checkbox")).FindElement(By.CssSelector("checkbox")).Click();
            driver.FindElement(By.Id(serviceId)).FindElement(By.CssSelector("button[type=submit]")).Click();

            //
        }

        [When(@"(.*) seconds has elapsed since the timer started")]
        public void WhenSecondsHasElapsedSinceTheTimerStarted(int p0)
        {
        }

        [When(@"the page loads")]
        public void WhenThePageLoads()
        {
        }

        [Then(@"the page should refresh")]
        public void ThenThePageShouldRefresh()
        {
        }

        [Then(@"the onlineExpertCounter should display (.*)")]
        public void ThenTheOnlineExpertCounterShouldDisplay(int p0)
        {
        }

        [Then(@"the potentialMatchingExpertCounter should display (.*)")]
        public void ThenThePotentialMatchingExpertCounterShouldDisplay(int p0)
        {
        }
    }
}

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
using OpenQA.Selenium.Chrome;

namespace ITMatching.BDDTests.Steps
{
    [Binding]
    public class ThemeToggleSteps
    {
        private readonly ScenarioContext _ctx;
        private string _hostBaseName = @"https://it-matching.azurewebsites.net/";
        private IWebDriver driver = new ChromeDriver();

        public ThemeToggleSteps(ScenarioContext scenarioContext)
        {
            _ctx = scenarioContext;
            _ctx["WebDriver"] = driver;
        }

        [Given(@"I am on the home page")]
        public void GivenIAmOnTheHomePage()
        {
            IWebDriver driver = (IWebDriver)_ctx["WebDriver"];
            driver.Navigate().GoToUrl(_hostBaseName);
        }

        [Given(@"the current theme is dark")]
        public void GivenTheCurrentThemeIsDark()
        {
            bool isLightTheme = driver.FindElement(By.Id("toggleButton")).Selected;
            if (isLightTheme)
            {
                driver.FindElement(By.ClassName("switch")).Click();
            }
        }
        
        [When(@"I click on the theme slider")]
        public void WhenIClickOnTheThemeSlider()
        {
            driver.FindElement(By.ClassName("switch")).Click();
        }

        [Then(@"the theme should change to be light")]
        public void ThenTheThemeShouldChangeToBeLight()
        {
            bool isLightTheme = driver.FindElement(By.Id("toggleButton")).Selected;
            Assert.That(isLightTheme);
        }
    }
}

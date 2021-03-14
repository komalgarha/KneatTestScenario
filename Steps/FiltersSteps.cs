using KneatProject.Pages;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using TechTalk.SpecFlow;
using TechTalk.SpecFlow.Assist;

namespace KneatProject.Steps
{
    [Binding]
    public class FiltersSteps
    {
        Homepage homepage = null;

        [Given(@"I launch the website")]
        public void GivenILaunchTheWebsite()
        {
            IWebDriver webDriver = new ChromeDriver();
            webDriver.Navigate().GoToUrl("http://www.booking.com");
            webDriver.Manage().Window.Maximize();
            homepage = new Homepage(webDriver);
        }
        
        [When(@"I enter the following details")]
        public void GivenIEnterTheFollowingDetails(Table table)
        {
            dynamic data = table.CreateDynamicInstance();
            homepage.EnterDetails((string)data.Location);
        }
        
        [When(@"I click Search Button")]
        public void GivenIClickSearchButton()
        {
            homepage.SearchButton();
        }
        
        [When(@"the star rating filter is applied")]
        public void WhenTheStarRatingFilterIsApplied()
        {
            homepage.ApplyStarFilter();
        }

        [When(@"the sauna filter is applied")]
        public void WhenTheSaunaFilterIsApplied()
        {
            homepage.ApplySaunaFilter();
        }



        [Then(@"the following expected result should be displayed\.")]
        public void ThenTheFollowingExpectedResultShouldBeDisplayed_(Table table)
        {
            dynamic data1 = table.CreateDynamicInstance();

            Assert.That(homepage.IsHotelListed(data1.ExpectedHotel), Is.True);
        }

        [Then(@"the following not expected result should be displayed\.")]
        public void ThenTheFollowingNotExpectedResultShouldBeDisplayed_(Table table)
        {
            dynamic data2 = table.CreateDynamicInstance();

            Assert.That(homepage.IsHotelNotListed(data2.NotExpectedHotel), Is.False);
        }


        [Then(@"Close the Browser Instance")]
        public void ThenCloseTheBrowserInstance()
        {
            homepage.CloseBoroswer();
        }

    }
}

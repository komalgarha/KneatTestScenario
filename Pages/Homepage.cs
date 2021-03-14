using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace KneatProject.Pages
{
    public class Homepage
    {
        public Homepage(IWebDriver webDriver)
        {
            WebDriver = webDriver;
        }

        public IWebDriver WebDriver { get; }

        // User Interface Web Elements
        public IWebElement LocationElement => WebDriver.FindElement(By.Name("ss"));

        public IWebElement CalElement => WebDriver.FindElement(By.XPath("//div[@data-calendar2-type='checkin']"));

        public IWebElement NextElement => WebDriver.FindElement(By.XPath("//div[@data-bui-ref='calendar-next']"));

        public IWebElement DateElement => WebDriver.FindElement(By.XPath("//td[@data-date='2021-06-14']"));

        public IWebElement DateElement1 => WebDriver.FindElement(By.XPath("//td[@data-date='2021-06-15']"));

        public IWebElement StarFilterElement => WebDriver.FindElement(By.XPath("//div[@id='filter_class']/child::div[2]//a[@data-id='class-5']"));

        public IWebElement FittnessFilterElement => WebDriver.FindElement(By.XPath("//div[@id='filter_popular_activities']/child::div[2]//a[@data-id='popular_activities-11']"));

        public IWebElement SaunaFilterElement => WebDriver.FindElement(By.XPath("//div[@id='filter_popular_activities']/child::div[2]//a[@data-id='popular_activities-10']"));

        
        public IWebElement ResultElement => WebDriver.FindElement(By.XPath("//html//body//div[3]//div//div[3]//div[1]//div[1]//div[6]//div[4]//div[1]//div//div[1]//div[2]//div[1]//div[1]//div[1]//h3//a//span[1]"));


        public void EnterDetails(string location)
        {
            LocationElement.SendKeys(location);
            System.Threading.Thread.Sleep(3000);
            CalElement.Click();
            NextElement.Click();
            NextElement.Click();
            DateElement.Click();
            DateElement1.Click();
        }

 
        public void SearchButton() => LocationElement.Submit();

        public void ApplyStarFilter() => StarFilterElement.Click();

        public void ApplySaunaFilter()
        {
            FittnessFilterElement.Click();
            System.Threading.Thread.Sleep(6000);
            SaunaFilterElement.Click();
        }

        public bool IsHotelListed(string ExpectedHotelName)
        {
            System.Threading.Thread.Sleep(3000);

            if (ResultElement.Text == ExpectedHotelName)
            {
                return true;
            }
            else
            {
                return false;
            }
             
        }

        public bool IsHotelNotListed(string NotExpectedHotelName)
        {
            System.Threading.Thread.Sleep(3000);

            if (ResultElement.Text == NotExpectedHotelName)
            {
                return true;
            }
            else
            {
                return false;
            }

        }

        public void CloseBoroswer()
        {
            WebDriver.Close();
            WebDriver.Quit();
        }
    }
}

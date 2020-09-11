using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Internal;
//using Shouldly;

namespace Sara.Feature

{
    [Binding]
    public class LaunchWebsite
    {
        IWebDriver driver;

        [SetUp]
        public void startBrowser()
        {
            driver = new ChromeDriver("C://Users//domin//Desktop//Chrome");

        }

        [Test]
        public void Test()
        {
            driver.Url = "https://saucedemo.com";

            driver.FindElement(By.Id("details-button"));
            IWebElement lnk = driver.FindElement(By.Id("details-button"));
            lnk.Click();
            IWebElement lnk2 = driver.FindElement(By.LinkText("Proceed to saucedemo.com (unsafe)"));
            lnk2.Click();

        }
        [TearDown]
           public void closeBrowser()
           {
               driver.Close();
           }
             

        [Given(@"a valid user logs in to SwagLabs with ""(.*)"" ""(.*)""")]
        public void GivenAValidUserLogsInToSwagLabsWith(string p0, string p1)
        {
            IWebElement userName = driver.FindElement(By.Id("user-name"));
            userName.SendKeys("standard_user");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("secret_sauce");
        }

        [Given(@"an unknown user logs in to SwagLabs")]
        public void GivenAnUnknownUserLogsInToSwagLabs()
        {
            IWebElement userName = driver.FindElement(By.Id("user-name"));
            userName.SendKeys("unknown_user");
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys("password");
        }
        [When(@"the Login button is selected")]
        public void WhenTheLoginButtonIsSelected()
        {
            driver.FindElement(By.Id("login-button"));
            IWebElement lnk = driver.FindElement(By.Id("login-button"));
            lnk.Click();
        }

        [Then(@"the product page is launched")]
        public void ThenTheProductPageIsLaunched()
        {
            driver.FindElement(By.ClassName("product_label"));
            Equals(true);
        }

        [Then(@"a message returned not indicating valid user with incorrect password or invalid username")]
        public void ThenAMessageReturnedNotIndicatingValidUserWithIncorrectPasswordOrInvalidUsername()
        {
            // to be completed
            //driver.FindElement(By.LinkText.ToString("product_label"));
            //does not contain string text equalto ("valid user", "incorrect password" "invalid username")
        }

        [Then(@"a message returned not indicating valid user with incorrect password")]
        public void ThenAMessageReturnedNotIndicatingValidUserWithIncorrectPassword()
        {
            // to be completed
        }
    }
}


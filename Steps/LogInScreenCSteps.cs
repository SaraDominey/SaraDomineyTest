using System;
using TechTalk.SpecFlow;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using Shouldly;
using System.Threading;


namespace Sara.Feature

{
    [Binding]
    public class LaunchWebsite
    {
        IWebDriver driver;
        private string expected;

        [SetUp]
        public void DriverLocation()
        {
            driver = new ChromeDriver("C://Users//domin//Desktop//Chrome");

        }


        [Given(@"browser is launched")]
        public void GivenBrowserisLaunched()
        {
            driver = new ChromeDriver("C://Users//domin//Desktop//Chrome");
            driver.Url = "https://saucedemo.com";

            driver.FindElement(By.Id("details-button"));
            IWebElement lnk = driver.FindElement(By.Id("details-button"));
            lnk.Click();
            IWebElement lnk2 = driver.FindElement(By.LinkText("Proceed to saucedemo.com (unsafe)"));
            lnk2.Click();

        }


        [Given(@"a valid user logs in to SwagLabs with ""(.*)"" ""(.*)""")]
        public void GivenAValidUserLogsInToSwagLabsWith(string username, string password1)
        {
            IWebElement userName = driver.FindElement(By.Id("user-name"));
            userName.SendKeys(username);
            IWebElement password = driver.FindElement(By.Id("password"));
            password.SendKeys(password1);

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
            ShouldAssertException.Equals(By.ClassName("product_label"), "product_labels");

            Thread.Sleep(1000);
        }


        [Then(@"add to cart")]
        public void ThenAddToCart()
        {
            driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']"));
            IWebElement cart = driver.FindElement(By.CssSelector("button[class='btn_primary btn_inventory']"));
            cart.Click();

            Thread.Sleep(1000);

        }


        [Then(@"close browser")]
        public void ThenCloseBrowser()
        {
            driver.Close();
        }


        [Then(@"view basket content")]
        public void ThenViewBasketContent()
        {
            //driver.FindElement(By.ClassName("product_label"));
            IWebElement shopCart = driver.FindElement(By.Id("shopping_cart_container"));
            shopCart.Click();

            driver.FindElement(By.Id("shopping_cart_container"));
            driver.FindElement(By.ClassName("cart_desc_label"));
            var cartElement = driver.FindElement(By.ClassName("cart_desc_label"));
            var itemExists = true;

            if (string.IsNullOrEmpty(cartElement.Text))
            {
                Console.WriteLine("Expected an entry in the cart but none found");
                itemExists = false;
            };

            Thread.Sleep(1000);
            itemExists.ShouldBeTrue();

        }


        [Then(@"confirm displayed error message does not indicate a valid user with incorrect password or invalid username")]
        public void ThenConfirmDisplayedErrorMessageDoesNotIndicatAValidUserWithIncorrectPasswordOrInvalidUsername()
        {
            driver.FindElement(By.ClassName("error-button"));
            var text = driver.FindElement(By.ClassName("error-button")).Text.Contains("Username and password do not match any user in this service");
            var incorrectErrorMessage = false;
            
            if (text)
            {
                var valid = "valid user";
                Contains.Substring(valid);
                Console.WriteLine("invalid error message being returned to end user");
                incorrectErrorMessage = true;
            }

            else if (text)
            {
                var incorrect = "incorrect password";
                Contains.Substring(incorrect);
                Console.WriteLine("invalid error message being returned to end user");
                incorrectErrorMessage = true;
            }

            else if (text)
            {

                var invalid = "invalid username";
                Contains.Substring(invalid);
                Console.WriteLine("invalid error message being returned to end user");
                incorrectErrorMessage = true;
            }

            incorrectErrorMessage.ShouldBeFalse();

        }
    }
}
    


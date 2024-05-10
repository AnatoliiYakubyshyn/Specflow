using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using TechTalk.SpecFlow;
using Newtonsoft.Json;

using Specflow.Pages;

[assembly:Parallelizable(ParallelScope.Fixtures)]

namespace Specflow.Steps
{
    [Binding]
    public class Shop
    {
        private IWebDriver driver;

        private HomePage _homePage;

        private LoginPage _loginPage;

        public Shop(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }


        [Given("I am on Home Page")]
        public void GivenIamOnMainPage()
        {
            _homePage = new HomePage(driver);
            _homePage.Open();   
        }

        [When(@"I login with ""(.*)"" and ""(.*)""")]
        public void WhenILogInWith(string login, string password)
        {
            _loginPage = _homePage.ClickLoginIcon();
            _homePage = _loginPage.Login(login,password);
        }

        [Then("Account page is opened")]
        public void ThenAccountPageIsOpened()
        {
            Assert.IsTrue(_homePage.IsLoggedIn());
        }

        [Then("Account page is not opened")]
        public void ThenAccountPageIsNotOpened()
        {
            Assert.IsFalse(_homePage.IsLoggedIn());
        }

    }
}
using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using NUnit.Framework;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using TechTalk.SpecFlow;
using Newtonsoft.Json;

namespace Specflow.Steps
{
    [Binding]
    public class Shop
    {
        private IWebDriver driver;

        public Shop(IWebDriver webDriver)
        {
            this.driver = webDriver;
        }


        [Given("I am on Home Page")]
        public void GivenIamOnMainPage()
        {
            string json = File.ReadAllText("config.json");

            // Deserialize JSON to dynamic object
            dynamic data = JsonConvert.DeserializeObject(json);

            // Accessing data
            string baseUrl = data.base_url;
            driver.Navigate().GoToUrl(baseUrl);
        }

        [When(@"I login with ""(.*)"" and ""(.*)""")]
        public void WhenILogInWith(string login, string password)
        {
            driver.FindElement(By.XPath("//header[contains(@class,'page-header')]//li[contains(@class,'authorization-link')]")).Click();
            driver.FindElement(By.Id("email")).SendKeys(login);
            driver.FindElement(By.Id("pass")).SendKeys(password);
            driver.FindElement(By.Id("send2")).Click();
        }

        [Then("Account page is opened")]
        public void ThenAccountPageIsOpened()
        {
            Assert.IsTrue(driver.FindElement(By.XPath("//header//span[contains(text(),'Welcome')]")).Displayed);
        }


    }
}
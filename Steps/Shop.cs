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

using Specflow.Drivers;

namespace Specflow.Steps
{
    [Binding]
    public class Shop
    {
        [Given("I am on Home Page")]
        public void GivenIamOnMainPage()
        {
            string json = File.ReadAllText("config.json");

            // Deserialize JSON to dynamic object
            dynamic data = JsonConvert.DeserializeObject(json);

            // Accessing data
            string baseUrl = data.base_url;
            IWebDriver driver = Driver.driver;
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            driver.Navigate().GoToUrl(baseUrl);
        }

        [When(@"I login with ""(.*)"" and ""(.*)""")]
        public void WhenILogInWith(string login, string password)
        {
            Driver.driver.FindElement(By.XPath("//header[contains(@class,'page-header')]//li[contains(@class,'authorization-link')]")).Click();
            Driver.driver.FindElement(By.Id("email")).SendKeys(login);
            Driver.driver.FindElement(By.Id("pass")).SendKeys(password);
            Driver.driver.FindElement(By.Id("send2")).Click();
        }

        [Then("Account page is opened")]
        public void ThenAccountPageIsOpened() {
           Assert.IsTrue(Driver.driver.FindElement(By.XPath("//header//span[contains(text(),'Welcome')]")).Displayed);
        }


    }
}
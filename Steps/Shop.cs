using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

using Specflow.Drivers;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;


using TechTalk.SpecFlow;

namespace Specflow.Steps
{
    [Binding]
    public class Shop
    {
        [Given("I am on Home Page")]
        public void GivenIamOnMainPage() {
            IWebDriver driver = Driver.driver;
            driver.Navigate().GoToUrl("https://magento.softwaretestingboard.com/");
        }
        
    }
}
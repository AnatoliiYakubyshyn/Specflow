using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

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
            driver.Navigate().GoToUrl(baseUrl);
        }

    }
}
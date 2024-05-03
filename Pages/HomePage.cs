using System;
using System.IO;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Newtonsoft.Json;

using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Specflow.Pages
{
    public class HomePage : AbstractPage
    {

        [FindsBy(How = How.XPath, Using = "//header[contains(@class,'page-header')]//li[contains(@class,'authorization-link')]")]
        private IWebElement  _loginIcon;

        [FindsBy(How = How.XPath, Using = "//header//span[contains(text(),'Welcome')]")]
        private IWebElement _succesfullLoginMarker;

        public HomePage(IWebDriver driver) : base(driver)
        {
            string json = File.ReadAllText("config.json");

            // Deserialize JSON to dynamic object
            dynamic data = JsonConvert.DeserializeObject(json);

            // Accessing data
            string baseUrl = data.base_url;

            SetUrl(baseUrl);
        }

        public LoginPage ClickLoginIcon() {
            _loginIcon.Click();
            return new LoginPage(Driver);
        }

        public bool IsLoggedIn() {
            return _succesfullLoginMarker.Displayed;
        }

    }
}
using System;

using TechTalk.SpecFlow;
using BoDi;

using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;

namespace Specflow.Hooks
{
    [Binding]
    public class Hooks
    {

        private IWebDriver driver;

        private readonly IObjectContainer _container;

        public Hooks(IObjectContainer container)
        {
            _container = container;
        }

        [AfterScenario]
        public void TearDown()
        {
            driver.Quit();
        }

        [BeforeScenario(Order = 1)]
        public void FirstBeforeScenario(ScenarioContext scenarioContext)
        {
            driver = new ChromeDriver();
            driver.Manage().Window.Maximize();
            driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(10);
            _container.RegisterInstanceAs<IWebDriver>(driver);
        }

    }
}
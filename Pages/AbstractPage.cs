using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using SeleniumExtras.PageObjects;

namespace Specflow.Pages
{
    public abstract class AbstractPage
    {
        protected IWebDriver Driver {get;set;}

        private string _url;

        public AbstractPage(IWebDriver driver)
        {
            this.Driver = driver;
            PageFactory.InitElements(Driver, this);
        }

        public void SetUrl(string url)
        {
            this._url = url;
        }

        public void Open()
        {
            Driver.Navigate().GoToUrl(_url);
        }
    }
}
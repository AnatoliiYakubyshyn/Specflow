using OpenQA.Selenium;
using SeleniumExtras.PageObjects;

namespace Specflow.Pages
{
    public class LoginPage : AbstractPage
    {

        [FindsBy(How = How.Id, Using = "email")]
        private IWebElement _emailField;

        [FindsBy(How = How.Id, Using = "pass")]
        private IWebElement _passwordField;

        [FindsBy(How = How.Id, Using = "send2")]
        private IWebElement _submitButton;

        public LoginPage(IWebDriver driver) : base(driver) { }

        public void TypeEmail(string text) {
            _emailField.SendKeys(text);
        }

        public void TypePassword(string text) {
            _passwordField.SendKeys(text);
        }

        public HomePage SubmitForm() {
            _submitButton.Click();
            return new HomePage(Driver);
        }

        public HomePage Login(string login, string password) {
            TypeEmail(login);
            TypePassword(password);
            return SubmitForm();
        }

    }
}
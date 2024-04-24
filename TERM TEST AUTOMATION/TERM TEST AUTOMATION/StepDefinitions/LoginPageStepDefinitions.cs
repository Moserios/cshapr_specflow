using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;


namespace TERM_TEST_AUTOMATION.StepDefinitions
{
    [Binding]
    public class LoginPageSteps
    {
        private readonly IWebDriver _driver;

        public LoginPageSteps(WebDriverSupport webDriverSupport)
        {
            _driver = webDriverSupport.Driver;
        }


        [Given(@"User is at the login page")]
        public void GivenUserIsAtTheLoginPage()
        {
            _driver.Navigate().GoToUrl("http://sergey.molchun:Xatr+peKL9Ri@open20204.domain1.local/Open/Login.aspx?ReturnUrl=%2fOpen%2fapp%2findex.html#/terms/termsAdministration/termTemplates");
        }


        [When(@"User enters ""(.*)"" as a username")]
        public void WhenUserEntersAsAUsername(string username)
        {
            IWebElement usernameField = _driver.FindElement(By.Id("X_A_txtUsername"));
            usernameField.Clear();
            usernameField.SendKeys(username);
        }


        [When(@"User clicks the login button")]
        public void WhenUserClicksTheLoginButton()
        {
            IWebElement loginButton = _driver.FindElement(By.Id("X_A_btnLogin"));
            loginButton.Click();
        }


        [Then(@"User should be at the Term Page")]
        public void ThenUserShouldBeAtTheTermPage()
        {
            WebDriverWait wait = new WebDriverWait(_driver, TimeSpan.FromSeconds(20));
            IWebElement termCreateButton = wait.Until(driver => driver.FindElement(By.CssSelector("div.btn.btn-primary")));
            Assert.NotNull(termCreateButton, "Term create button should be present");
        }
    }
}
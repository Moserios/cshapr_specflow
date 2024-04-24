using BoDi;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome; // or any other browser driver
using OpenQA.Selenium.Support.UI;
using TechTalk.SpecFlow;
using TERM_TEST_AUTOMATION.StepDefinitions;


[Binding]
public class Hooks
{
    private readonly IObjectContainer _objectContainer;
    private WebDriverSupport _webDriverSupport;


    public Hooks(IObjectContainer objectContainer)
    {
        _objectContainer = objectContainer;
    }

    [BeforeScenario]
    public void InitializeWebDriver()
    {
        _webDriverSupport = new WebDriverSupport();
        _objectContainer.RegisterInstanceAs<WebDriverSupport>(_webDriverSupport);
    }

    [AfterScenario]
    public void CleanupWebDriver()
    {
        _webDriverSupport.Dispose();
    }
}

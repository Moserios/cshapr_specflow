using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Edge;

namespace TERM_TEST_AUTOMATION.StepDefinitions
{
    public class WebDriverSupport
    {
        public IWebDriver Driver { get; private set; }

        public WebDriverSupport()
        {
            // Chrome
            Driver = new ChromeDriver();
            Driver.Manage().Window.Maximize();


            // To use Edge, uncomment the following lines and comment out the others:
            // Edge requires MicrosoftWebDriver.exe to be in PATH or specified location
            //Driver = new EdgeDriver(); //Use with parameter for external webdriver: Driver = new EdgeDriver(@"D:\intapp\webdriver\")
            //Driver.Manage().Window.Maximize();

            // To use Firefox, uncomment the following lines and comment out the others:
            // Firefox requires geckodriver.exe to be in PATH or specified location
            //Driver = new FirefoxDriver(); //Use with parameter for external webdriver: Driver = new EdgeDriver(@"D:\intapp\webdriver\")
            //Driver.Manage().Window.Maximize();
        }

        public void Dispose()
        {
            if (Driver != null)
            {
                Driver.Quit();
                Driver = null;
            }
        }
    }
}

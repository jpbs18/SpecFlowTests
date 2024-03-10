using AngleSharp.Dom;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Security.Policy;
using TechTalk.SpecFlow;
using WebDriverManager.DriverConfigs.Impl;

namespace SpecFlowProject1
{
    [Binding]
    public class LoginStepDefinitions
    {
        IWebDriver driver;
        private string _url;
        private User _user;


        public LoginStepDefinitions(User user)
        {
            new WebDriverManager.DriverManager().SetUpDriver(new ChromeConfig());

            driver = new ChromeDriver();
            _url = Runner.configurationRoot["Url"];
            _user = user;
        }



        [BeforeScenario]
        public void BeforeScenario(ScenarioContext sc, FeatureContext fc)
        {
            Console.WriteLine(sc.ScenarioInfo.Title);
        }

        [AfterScenario]
        public void AfterScenario(ScenarioContext sc, FeatureContext fc)
        {
            driver.Quit();
        }

        [BeforeStep]
        public void BeforeStep(ScenarioContext sc)
        {
            Console.Write("Before step.");
        }


        [AfterStep]
        public void AfterStep(ScenarioContext sc)
        {
            if (sc.TestError != null)
            {
               string base64 = ((ITakesScreenshot)driver).GetScreenshot().AsBase64EncodedString;
            }
        }



        [Given(@"I am on login page")]
        public void GivenIAmOnLoginPage()
        {
            driver.Navigate().GoToUrl(_url);
        }

        [When(@"I provide username (.*)")]
        public void WhenIProvideUsername(string username)
        {
            driver.FindElement(By.Id("user-name")).SendKeys(username);
        }

        [When(@"I provide password (.*)")]
        public void WhenIProvidePassword(string password)
        {
            driver.FindElement(By.Id("password")).SendKeys(password);
        }

        [When(@"I select login")]
        public void WhenISelectLogin()
        {
            driver.FindElement(By.Id("login-button")).Click();
        }

        [When(@"I calculate (.*) as value")]
        public void WhenICalculateAsValue(int p0)
        {
            int result = p0 + 100;
            Console.Write(result);
            Assert.GreaterOrEqual(result, 100);
        }


        [Then(@"Appears a dashboard")]
        public void ThenAppearsADashboard()
        { 
            int count = driver.FindElements(By.XPath("//div[text()='Swag Labs']")).Count;
            Assert.That(count, Is.EqualTo(1));
        }

        [Then(@"user adds fisrtName and lastName")]
        public void ThenUserAddsFisrtNameAndLastName()
        {
            _user.firstName = "Dan";
            _user.lastName = "Silva";
        }

        [Then(@"Appears user details")]
        public void ThenAppearsUserDetails()
        {
            throw new PendingStepException();
        }
    }
}

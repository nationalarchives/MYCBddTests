using Microsoft.Extensions.Configuration;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TechTalk.SpecFlow;

namespace Nunit_NetCore
{
    [Binding]
    public class PageNavigator
    {
        public IConfiguration Configuration { get; set; }

        public String baseUrl;

        public PageNavigator()
        {
            var configurationBuilder = new ConfigurationBuilder()
                                        .AddJsonFile("appsettings.json");
            Configuration = configurationBuilder.Build();
            baseUrl = Configuration.GetValue<string>("baseUrl");

        }
        public IWebDriver OpenChromeAndNavigateTo(string url)
        {
            var path = Configuration.GetValue<string>("googleDriverPath");
            ChromeDriverService service = ChromeDriverService.CreateDefaultService(path, "chromedriver.exe");
            var _driver = new ChromeDriver(service);
            _driver.Manage().Window.Maximize();
            _driver.Manage().Timeouts().ImplicitWait = TimeSpan.FromSeconds(30);
            _driver.Navigate().GoToUrl(url);
            return _driver;
        }
        public IWebDriver GoToMYCPage()
        {
            var url = Configuration.GetValue<string>("baseUrl");
            return OpenChromeAndNavigateTo(url);
        }
        public void SingleSignOn(IWebDriver driver)
        {
            var username = Configuration.GetValue<string>("username");
            var password = Configuration.GetValue<string>("password");

            driver.FindElement(By.Id("UserName")).SendKeys(username);
            driver.FindElement(By.Id("Password")).SendKeys(password);
            driver.FindElement(By.ClassName("singleColumnSubmit")).Click();
        }
        public IWebDriver GoToAddCollectionsPage()
        {
            var url = Configuration.GetValue<string>("addCollectionUrl");
            return OpenChromeAndNavigateTo(url);
        }

    }

}
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Text;

namespace Nunit_NetCore
{
    public class SignOn
    {
        public IWebDriver _driver;
        public void SingleSignOn()
        {
            try
            {
                _driver.FindElement(By.Id("UserName")).SendKeys("discovery@nationalarchives.gov.uk");
                _driver.FindElement(By.Id("Password")).SendKeys("DiscoveryTest1");
            }
            catch (Exception)
            {
                Console.WriteLine( "Exception found");
            }
        }
    }
}

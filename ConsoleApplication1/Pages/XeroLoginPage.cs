using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroExercise;
using XeroExercise.Pages;

namespace ConsoleApplication1
{
    public class XeroLoginPage : BasePage
    {

        public XeroLoginPage(IWebDriver _driver)
        {
            PageFactory.InitElements(_driver, this);
        }

        private IWebElement emailWebElement 
        {
            get { return Driver.FindElement(By.Id("email")); }
        }

        private IWebElement passwordWebElement
        {
            get { return Driver.FindElement(By.Id("password")); }
        }

        private IWebElement LoginButton
        {
            get { return Driver.FindElement(By.Id("submitButton")); }
        }  

        public void Login()
        {
            emailWebElement.SendKeys(ConfigurationManager.AppSettings["UserEmail"]);
            passwordWebElement.SendKeys(ConfigurationManager.AppSettings["Password"]);
            LoginButton.Click();
        }
    }
}

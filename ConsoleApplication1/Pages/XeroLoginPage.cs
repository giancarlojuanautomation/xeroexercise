using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroExercise.Pages;

namespace ConsoleApplication1
{
    public class XeroLoginPage : BasePage
    {

        public XeroLoginPage()
        {
            PageFactory.InitElements(WebDriverFactory.driver, this);
        }

        private IWebElement emailWebElement 
        {
            get { return Driver.FindElement(By.Id("email"), 10); }
        }

        private IWebElement passwordWebElement
        {
            get { return Driver.FindElement(By.Id("password"), 10); }
        }

        private IWebElement LoginButton
        {
            get { return Driver.FindElement(By.Id("submitButton"), 10); }
        }  

        public void Login()
        {
            emailWebElement.SendKeys(ConfigurationManager.AppSettings["UserEmail"]);
            passwordWebElement.SendKeys(ConfigurationManager.AppSettings["Password"]);
            LoginButton.Click();
        }
    }
}

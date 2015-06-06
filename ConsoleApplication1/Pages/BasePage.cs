using ConsoleApplication1;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroExercise.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(WebDriverFactory.driver, this);
        }

        public static void NavigateTo(String url)
        {
            WebDriverFactory.driver.Navigate().GoToUrl(url);
        }

        public static void NavigateToPage(String RelativeURL)
        {
            WebDriverFactory.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrlStr"] + RelativeURL);
        }

        public static IWebDriver Driver()
        {
            return WebDriverFactory.driver;
        }

    }
}

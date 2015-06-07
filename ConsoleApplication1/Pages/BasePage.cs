using ConsoleApplication1;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using XeroExercise.Utils;

namespace XeroExercise.Pages
{
    public class BasePage
    {
        public BasePage()
        {
            PageFactory.InitElements(RepeatingInvoiceTest.driver, this);
        }

        public static void NavigateTo(String url)
        {
            RepeatingInvoiceTest.driver.Navigate().GoToUrl(url);
        }

        public static void NavigateToPage(String RelativeURL)
        {
            RepeatingInvoiceTest.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["BaseUrlStr"] + RelativeURL);
        }

        public IWebDriver Driver = RepeatingInvoiceTest.driver;


    }
}

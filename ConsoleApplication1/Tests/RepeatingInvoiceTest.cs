using NUnit.Framework;
using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;
using OpenQA.Selenium.Firefox;
using System.Configuration;
using ConsoleApplication1.Pages;
using System.Threading;
using XeroExercise.Pages;

namespace XeroExercise
{
    public class RepeatingInvoiceTest
    {
        static void Main()
        {

        }

        [SetUp]
        public void BeforeTest()
        {
            WebDriverFactory.driver = new FirefoxDriver();
            WebDriverFactory.driver.Manage().Window.Maximize();

            WebDriverFactory.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LoginUrlStr"]);
            
            var loginPage = new XeroLoginPage();
            loginPage.Login();

            //if Demo company is not selected go to Demo company
            var dashboard = new XeroDashboardPage();
            if (!dashboard.isDemoCompanySelected()) dashboard.gotoDemoCompany();

        }
        
        [Test]
        public void TestCreateInvoice()
        {
            var salesPage = new SalesReceiveablePage();
            salesPage.gotoPage();
            
            var repeatInvoiceList = salesPage.clickRepeatingLink();
            var newInvoicePage = repeatInvoiceList.clickRepeatingInvoiceBtn();
            newInvoicePage.CreateNewRepeatingInvoice(DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"));

            
       }

        [TearDown]
        public void Cleanup()
        {
           // WebDriverFactory.driver.Close();


        }
    }
}

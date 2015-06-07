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
using XeroExercise.Data;

namespace XeroExercise
{
    [TestFixture]
    public class RepeatingInvoiceTest
    {
        
        public static IWebDriver driver { get; set; }
        
        [SetUp]
        public void BeforeTest()
        {
            RepeatingInvoiceTest.driver = new FirefoxDriver();

            RepeatingInvoiceTest.driver.Manage().Window.Maximize();

            RepeatingInvoiceTest.driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LoginUrlStr"]);
            
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
            var previousInvoiceCount = repeatInvoiceList.pageGrid().getInvoiceCount();
            Console.WriteLine("The current number of invoices are " + previousInvoiceCount);
           
            var newInvoicePage = repeatInvoiceList.clickRepeatingInvoiceBtn();

            newInvoicePage.CreateNewRepeatingInvoice((new DataCreateInvoice()));

            Console.WriteLine("the new number of invoices are " + repeatInvoiceList.pageGrid().getInvoiceCount());

            Assert.AreEqual("Repeating Template Saved. Click to view.", repeatInvoiceList.getMessage());
            Assert.AreEqual(previousInvoiceCount + 1, repeatInvoiceList.pageGrid().getInvoiceCount());           
           
       }

        [Test]
        public void DeleteInvoice()
        {
            var salesPage = new SalesReceiveablePage();
            salesPage.gotoPage();

            var repeatInvoiceList = salesPage.clickRepeatingLink();
            var previousInvoiceCount = repeatInvoiceList.pageGrid().getInvoiceCount();
            Console.WriteLine("The current number of invoices are " + previousInvoiceCount);

            repeatInvoiceList.pageGrid().DeleteAnInvoice(previousInvoiceCount-1);          

            Console.WriteLine("the new number of invoices are " + repeatInvoiceList.pageGrid().getInvoiceCount());

            Assert.AreEqual("1 repeating transaction deleted", repeatInvoiceList.getMessage());
            Assert.AreEqual(previousInvoiceCount - 1, repeatInvoiceList.pageGrid().getInvoiceCount());

        }

        [TearDown]
        public void Cleanup()
        {
            RepeatingInvoiceTest.driver.Quit();

        }
    }
}

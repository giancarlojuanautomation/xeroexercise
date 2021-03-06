﻿using NUnit.Framework;
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
using XeroExercise.Utils;
using OpenQA.Selenium.Chrome;

namespace XeroExercise
{
    public class RepeatingInvoiceTest
    {
        public static IWebDriver driver;

        [SetUp]
        public void BeforeTest()
        {
            driver = (new GetWebDriver()).returnWebDriver();

            driver.Manage().Window.Maximize();

            driver.Navigate().GoToUrl(ConfigurationManager.AppSettings["LoginUrlStr"]);

            var loginPage = new XeroLoginPage(driver);
            loginPage.Login();

            //if Demo company is not selected go to Demo company
            var dashboard = new XeroDashboardPage();
            if (!dashboard.isDemoCompanySelected()) dashboard.gotoDemoCompany();

        }
        
        public void TestCreateInvoice(DataCreateInvoice invoiceData)
        {
            var salesPage = new SalesReceiveablePage();
            salesPage.gotoPage();
            
            var repeatInvoiceList = salesPage.clickRepeatingLink();
            var previousInvoiceCount = repeatInvoiceList.pageGrid().getInvoiceCount();
            Console.WriteLine("The current number of invoices are " + previousInvoiceCount);
           
            var newInvoicePage = repeatInvoiceList.clickRepeatingInvoiceBtn();

            newInvoicePage.CreateNewRepeatingInvoice(invoiceData);

            Assert.AreEqual("Repeating Template Saved. Click to view.", repeatInvoiceList.getMessage());

            Console.WriteLine("the new number of invoices are " + repeatInvoiceList.pageGrid().getInvoiceCount());
            Assert.AreEqual(previousInvoiceCount + 1, repeatInvoiceList.pageGrid().getInvoiceCount());           
           
       }
        [Test]
        public void TestCreateInvoice1()
        {
            TestCreateInvoice(TestData.test1);
        }

        [Test]
        public void TestCreateInvoice2()
        {
            TestCreateInvoice(TestData.test2);
        }
        
        [Test]
        public void TestCreateInvoice3()
        {
            TestCreateInvoice(TestData.test3);
        }



        [Test]
        public void TestUpdateInvoice()
        {
            var salesPage = new SalesReceiveablePage();
            salesPage.gotoPage();

            var repeatInvoiceList = salesPage.clickRepeatingLink();

            //edit the first invoice
            var editInvoicepage = repeatInvoiceList.ClickInvoiceLink(1);
            editInvoicepage.UpdateExistingInvoice("1111101111", "approved");

            Assert.AreEqual("Repeating Template Saved. Click to view.", repeatInvoiceList.getMessage());

        }

        [Test]
        public void TestDeleteInvoice()
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
            driver.Quit();

        }
    }
}

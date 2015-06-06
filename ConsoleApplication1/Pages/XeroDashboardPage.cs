using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using XeroExercise.Pages;

namespace ConsoleApplication1.Pages
{
    public class XeroDashboardPage : BasePage
    {
        public XeroDashboardPage()
        {
            PageFactory.InitElements(Driver, this);
        }

        // used an extension for FindElement with 10 secondtimeout to wait for element
        private IWebElement OrganizationName 
        {
            get { return Driver.FindElement(By.ClassName("org-name"), 10); }       
        }

        private IWebElement OrganizationPopup
        {
            get { return Driver.FindElement(By.ClassName("selected myxero-link"), 10); }           
        }

        public string getOrganizationName()
        {         
            return OrganizationName.Text;
        }

        public bool isDemoCompanySelected()
        {
            var currentOrg = getOrganizationName();
            return Regex.IsMatch(currentOrg, @"Demo Company");
        }

        public void gotoDemoCompany()
        {
            NavigateTo("https://my.xero.com/Go/Home");
            Driver.FindElement(By.PartialLinkText("Try the Demo Company")).Click();
            Console.WriteLine("clicked the demo company");
        }
    }
}

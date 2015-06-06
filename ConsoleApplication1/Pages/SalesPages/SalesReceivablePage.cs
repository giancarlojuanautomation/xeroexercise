using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleApplication1;

namespace XeroExercise.Pages
{
    
    public class SalesReceiveablePage : BasePage
    {
        String relativeURL = "/Accounts/Receivable/Dashboard/";

        public SalesReceiveablePage()
	    {
            PageFactory.InitElements(Driver,this);           
	    }

        private IWebElement RepeatingLink
        {
            get { return Driver.FindElement(By.LinkText("Repeating"), 10); }
        }

        public SalesReceiveablePage gotoPage()
        {
            NavigateToPage(relativeURL);
            return this;
        }

        public SearchRepeatingPage clickRepeatingLink()
        {
            RepeatingLink.Click();
            return new SearchRepeatingPage();
        }

    }





    
}

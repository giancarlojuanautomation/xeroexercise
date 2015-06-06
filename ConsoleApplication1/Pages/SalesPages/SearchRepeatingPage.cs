using ConsoleApplication1;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XeroExercise.Pages
{
    
    public class SearchRepeatingPage : BasePage
    {
        String relativeURL = "/AccountsReceivable/SearchRepeating.aspx";

        public SearchRepeatingPage()
	    {
            PageFactory.InitElements(Driver(),this);           
	    }

        private IWebElement NewRepeatingInvoiceButton 
        {
            get { return Driver().FindElement(By.CssSelector("#ext-gen30 > a"), 10); }
        }

        private IWebElement NewCreditButton
        {
            get { return Driver().FindElement(By.Id("ext-gen32")); }
        }

        private IWebElement SendStatementsButton
        {
            get { return Driver().FindElement(By.Id("ext-gen34")); }
        }

        public SearchRepeatingPage gotoPage()
        {
            NavigateToPage(relativeURL);
            return this;
        }

        public NewRepeatingInvoicePage clickRepeatingInvoiceBtn()
        {
            NewRepeatingInvoiceButton.Click();

            return new NewRepeatingInvoicePage();
        }

        public void CreateNewRepeatingInvoice(String Date)
        {
            var newInvoice = new NewRepeatingInvoicePage();
            newInvoice.CreateNewRepeatingInvoice();

        }

    }

}



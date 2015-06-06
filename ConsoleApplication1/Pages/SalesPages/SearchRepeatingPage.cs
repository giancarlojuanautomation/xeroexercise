using ConsoleApplication1;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using XeroExercise.Data;

namespace XeroExercise.Pages
{
    
    public class SearchRepeatingPage : BasePage
    {
        String relativeURL = "/AccountsReceivable/SearchRepeating.aspx";

        public SearchRepeatingPage()
	    {
            PageFactory.InitElements(Driver,this);           
	    }

        private IWebElement NewRepeatingInvoiceButton 
        {
            get { return Driver.FindElement(By.CssSelector("#ext-gen30 > a"), 10); }
        }

        private IWebElement NewCreditButton
        {
            get { return Driver.FindElement(By.Id("ext-gen32")); }
        }

        private IWebElement SendStatementsButton
        {
            get { return Driver.FindElement(By.Id("ext-gen34")); }
        }

        private IWebElement MessageWebElement
        {
            get { return Driver.FindElement(By.XPath("//form/div/div/div/div/p"), 10); }
        }

        public string getMessage()
        {
            return MessageWebElement.Text;
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

        

    }

}



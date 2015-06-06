using ConsoleApplication1;
using OpenQA.Selenium;
using OpenQA.Selenium.Support.PageObjects;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace XeroExercise.Pages
{
    
    public class NewRepeatingInvoicePage : BasePage
    {
        String relativeURL = "/RepeatTransactions/Edit.aspx?type=AR";

        public NewRepeatingInvoicePage()
	    {
            PageFactory.InitElements(Driver(),this);           
	    }

        #region webelements

        private IWebElement RepeatElement
        {
            get { return Driver().FindElement(By.Id("PeriodUnit"), 10); }
        }      
        
        public IWebElement DefaultSalesTaxSelectElement
        {
            get { return Driver().FindElement(By.Id("TimeUnit_value"), 10); }
        }
        
        private IWebElement InvoiceDateElement
        {
            get { return Driver().FindElement(By.Id("StartDate")); }
        }

        private IWebElement DueDateElement
        {
            get { return Driver().FindElement(By.Id("DueDateDay")); }
        }

        public IWebElement DueDateSelectElement
        {
            get { return Driver().FindElement(By.Id("DueDateType_value")); }
        }

        private IWebElement EndDateElement
        {
            get { return Driver().FindElement(By.Id("EndDate")); }
        }

        private IWebElement SaveAsDraftElement
        {
            get { return Driver().FindElement(By.Id("saveAsDraft")); }
        }
        
        private IWebElement SaveasApproveElement
        {
            get { return Driver().FindElement(By.Id("saveAsAutoApproved")); }
        }

        private IWebElement SaveasApproveforSendingElement
        {
            get { return Driver().FindElement(By.Id("saveAsAutoApprovedAndEmail")); }
        }

        private IWebElement ContactName
        {
            get { return Driver().FindElement(By.XPath("//div[3]/div/div/div/div/div/div/input"), 10); }
        }

        private IWebElement Reference
        {
            get { return Driver().FindElement(By.XPath("//div/div/div/div[2]/div/input"), 10); }
        }

        public SelectElement BrandingSelectElement
        {
            get { return new SelectElement(Driver().FindElement(By.Id("TemplateDropDown_value"))); }
        }

        private IWebElement SaveButton
        {
            get { return Driver().FindElement(By.XPath("(//button[@type='button'])[3]")); }
        }

        public NewRepeatingInvoiceGrid InvoiceLineGrid
        {
            get { return new NewRepeatingInvoiceGrid(); }
        }

       #endregion webelements

        public NewRepeatingInvoicePage gotoPage()
        {
            NavigateToPage(relativeURL);
            return this;
        }

        public SearchRepeatingPage clickSaveButton()
        {
            SaveButton.Click();
            return new SearchRepeatingPage();
        }

        public void SaveStatus(string Status)
        {

            switch (Status.ToLower())
            {
                case "draft":
                    SaveAsDraftElement.Click();
                    break;
                case "approved":
                    SaveasApproveElement.Click();
                    break;
                case "approveandsend":
                    SaveasApproveforSendingElement.Click();
                    break;                
                default:
                    SaveAsDraftElement.Click();
                    break;
            }
                       
        }



        public void CreateNewRepeatingInvoice(string InvoiceDate)
        {
            ContactName.Clear();
            ContactName.SendKeys("ABC");

            InvoiceDateElement.Clear();
            InvoiceDateElement.SendKeys(InvoiceDate);
            DueDateElement.SendKeys("25");
            
            InvoiceLineGrid.selectItem(1, 10);
            InvoiceLineGrid.selectItem(2, 10);
            InvoiceLineGrid.selectItem(3, 10);          

            SaveStatus("Draft");

            clickSaveButton();

            Thread.Sleep(5000);

        }



    }

    
}

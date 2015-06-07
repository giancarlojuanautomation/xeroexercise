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
    
    public class SearchRepeatingGrid : SearchRepeatingPage
    {


        public SearchRepeatingGrid()
	    {
            PageFactory.InitElements(Driver,this);           
	    }

        #region webelements



        public IWebElement DeleteButton
        {
            get { return Driver.FindElement(By.XPath("//div[4]/a/span"), 10); }
        }



        public IWebElement ConfirmDeletebutton
        {
            get { return Driver.FindElement(By.XPath("//div[2]/div[2]/a/span"), 10); }
        }


        #endregion webelements

        public List<IWebElement> getallRows()
        {

            ICollection<IWebElement> table = Driver.FindElements(By.TagName("tr"));
            List<IWebElement> elements = table.ToList();

            return elements;          
        }

        public List<IWebElement> getallColumns(int row)
        {
            row = row + 1;
            var lists = getallRows();
            List<IWebElement> columnvalues = lists[row].FindElements(By.TagName("td")).ToList();

            return columnvalues;
        }

        public int getInvoiceCount()
        {
            return getallRows().Count() - 1; 
        }

        public void getCustomerName(int row)
        {
            row = row + 1 ;
            var lists = getallRows();
            var columnvalues = lists[row].FindElements(By.TagName("td"));

            var invoiceCustomerName = columnvalues[1].Text;

            Console.WriteLine("Customer Name for row " + row + " is " + invoiceCustomerName);

            var invoiceStatus = columnvalues[8].Text;
            Console.WriteLine("Invoice Status for row " + row + " is " + invoiceStatus);

         } 

        public void DeleteAnInvoice(int row)
        {
            row = row + 1;
            var lists = getallRows();
            var columnvalues = lists[row].FindElements(By.TagName("td"));
            var deleterow = columnvalues.ElementAt(0).FindElement(By.Name("selectedInvoices"));
            deleterow.Click();
          
            DeleteButton.Click();

            ConfirmDeletebutton.Click();
        
        }


    }

    
}

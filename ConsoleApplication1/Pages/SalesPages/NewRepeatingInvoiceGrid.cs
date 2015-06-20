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
    
    public class NewRepeatingInvoiceGrid : NewRepeatingInvoicePage
    {


        public NewRepeatingInvoiceGrid()
	    {
            PageFactory.InitElements(Driver,this);           
	    }

        #region webelements

        private IWebElement addNewLineItemButton
        {
            get { return Driver.FindElement(By.Id("addNewLineItemButton"), 10); }
        }

        public IWebElement GridCell(int row, int column)
        {
            return Driver.FindElement(By.XPath(string.Format("//div[{0}]/table/tbody/tr/td[{1}]/div", row, column)));
        }

        public IWebElement ItemDropDown()
        {
            return Driver.FindElement(By.XPath(string.Format("//div[2]/div/img")));
        }

        public List<IWebElement> ItemSelectList()
        {
            //return Driver.FindElement(By.XPath(string.Format("//div/div[{0}]", row)));
            var itemlist = Driver.FindElements(By.ClassName("x-combo-list-item"));
            var list = itemlist.ToList();
            return list;
        }

        public SelectElement ItemSelectDropDown(int row)
        {
            return new SelectElement(Driver.FindElement(By.ClassName("x-combo-list-inner")));
        }

        public List<IWebElement> getAllLineRows()
        {
            ICollection<IWebElement> table = Driver.FindElements(By.ClassName("x-grid3-row-table"));
            List<IWebElement> list = table.ToList();
            return list;
        }

        public IWebElement getLineItem(int row)
        {
            var rowitem = getAllLineRows();
            return rowitem[row];
        }

        public List<IWebElement> getLineColumns(int row = 0)
        {
            var lists = getAllLineRows();
            List<IWebElement> columnvalues = lists[row].FindElements(By.TagName("td")).ToList();
            return columnvalues;
        }

       
        #endregion webelements

        public void selectItem(int row, int itemindex)
        {
            var Item  = getLineColumns(row)[1];
            Item.Click();            
            ItemDropDown().Click();
            ItemSelectList()[itemindex].Click();
            
            //click anywhere to item is saved
            GridCell(row+1, 3).Click();            
        }


    }

    
}

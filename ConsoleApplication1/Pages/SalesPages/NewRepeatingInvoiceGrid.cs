﻿using ConsoleApplication1;
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
            PageFactory.InitElements(Driver(),this);           
	    }

        #region webelements

        private IWebElement addNewLineItemButton
        {
            get { return Driver().FindElement(By.Id("addNewLineItemButton"), 10); }
        }
/*
        public IList<IWebElement> GridLines()
        {
            //return Driver().FindElements(By.XPath(string.Format("//tr[starts-with(@id,'//div[@id='ext-gen20']/div')]")));
            return Driver().FindElements(By.XPath(string.Format("//div[starts-with(@id='ext-gen20']/div')]")));

            //var xpath = string.Format(@"//tr[@id='{0}_DXDataRow{1}']/td[{2}]", GridName, rowIndex, columnIndex);          
        }
*/

        public IWebElement GridCell(int row, int column)
        {
            return Driver().FindElement(By.XPath(string.Format("//div[{0}]/table/tbody/tr/td[{1}]/div", row, column)));
        }

        public IWebElement ItemDropDown()
        {
            return Driver().FindElement(By.XPath(string.Format("//div[2]/div/img")));
        }

        public IWebElement ItemSelectList(int row)
        {
            return Driver().FindElement(By.XPath(string.Format("//div/div[{0}]", row)));
        } 

       
        #endregion webelements

        public void selectItem(int row, int itemindex)
        {
            GridCell(row, 2).Click();            
            ItemDropDown().Click();                   
            ItemSelectList(itemindex).Click();
            GridCell(row, 3).Click();
            
        }






    }

    
}
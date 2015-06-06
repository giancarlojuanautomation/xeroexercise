using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroExercise.Data
{
    public class DataCreateInvoice
    {
        public string InvoiceDate = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"); 
        public string Customer = "ABC";
        public string DueDay = "25";
        public string Status = "Approved";
        public int numberofItems = 5;


    }
}

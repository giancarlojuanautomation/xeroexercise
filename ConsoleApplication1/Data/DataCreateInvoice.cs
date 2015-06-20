using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroExercise.Data
{
    public class DataCreateInvoice
    {
        public string InvoiceDate { get; set; }
        public string Customer { get; set; }
        public string DueDay { get; set; }
        public string Status { get; set; }
        public int numberofItems { get; set; }
        public int itemindex { get; set; }
    }

}

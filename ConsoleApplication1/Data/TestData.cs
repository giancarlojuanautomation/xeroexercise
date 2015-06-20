using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroExercise.Data
{
    public static class TestData
    {
        public static DataCreateInvoice test1
        {
            get
            {
                return new DataCreateInvoice
                {
                    InvoiceDate = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"),
                    Customer = "NBA",
                    DueDay = "25",
                    Status = "Draft",
                    numberofItems = 3,
                    itemindex = 5
                };
            }
        }

        public static DataCreateInvoice test2
        {
            get
            {
                return new DataCreateInvoice
                {
                    InvoiceDate = DateTime.Now.AddDays(5).ToString("dd/MM/yyyy"),
                    Customer = "APP test",
                    DueDay = "27",
                    Status = "Draft",
                    numberofItems = 5,
                    itemindex = 8
                };
            }
        }

        public static DataCreateInvoice test3
        {
            get
            {
                return new DataCreateInvoice
                {
                    InvoiceDate = DateTime.Now.AddDays(10).ToString("dd/MM/yyyy"),
                    Customer = "Customer test",
                    DueDay = "5",
                    Status = "Draft",
                    numberofItems = 1,
                    itemindex = 3
                };
            }
        }
    }

}

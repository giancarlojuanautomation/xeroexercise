using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroExercise.Data
{
    public static class TestData
    {
        public static DataCreateInvoice[] 
                test = {          
                        new DataCreateInvoice{
                        InvoiceDate = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"),
                        Customer = "ABC",
                        DueDay = "25",
                        Status = "Draft",
                        numberofItems = 3,
                        itemindex = 5
                        },
                        new DataCreateInvoice{
                        InvoiceDate = DateTime.Now.AddDays(1).ToString("dd/MM/yyyy"),
                        Customer = "BCA",
                        DueDay = "10",
                        Status = "Draft",
                        numberofItems = 5,
                        itemindex = 10
                        }

                        }; 
                                           
                                           
                                           
                                           
    }
}

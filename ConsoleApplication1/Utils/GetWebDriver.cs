using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Firefox;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace XeroExercise.Utils
{
    public class GetWebDriver
    {
        public GetWebDriver()
        {

        }
        
        public IWebDriver _driver { get; set; }

        public IWebDriver returnWebDriver()
        {          
            switch (ConfigurationManager.AppSettings["Browser"])
                {
                    case "Chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "Firefox":
                        _driver = new FirefoxDriver();
                        break;
                    default:
                        _driver = new FirefoxDriver();
                        break;
                }
       
            return _driver;  
        }

    }
    
}

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
            var browser = ConfigurationManager.AppSettings["Browser"].ToLower();
            switch (browser)
                {
                    case "chrome":
                        _driver = new ChromeDriver();
                        break;
                    case "firefox":
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

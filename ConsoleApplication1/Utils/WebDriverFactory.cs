﻿using OpenQA.Selenium;
using OpenQA.Selenium.Support.UI;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ConsoleApplication1
{
    public static class WebDriverFactory
    {
        public static IWebDriver driver { get; set; }

        public static IWebElement FindElement(this IWebDriver driver, By by, int timeoutInSeconds)
        {
            if (timeoutInSeconds > 0)
            {
                var wait = new WebDriverWait(driver, TimeSpan.FromSeconds(timeoutInSeconds));
                return wait.Until(drv => drv.FindElement(by));
            }
            return driver.FindElement(by);
        }

        public static void WaitforElement(String elementId)
        {                                
            var waitableDriver = new WebDriverWait(driver, TimeSpan.FromSeconds(15));
            var element = waitableDriver.Until(d => d.FindElement(By.Id(elementId)));
        }

    }



    

}
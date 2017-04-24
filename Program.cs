using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using OpenQA.Selenium.Chrome;
using OpenQA.Selenium.Remote;
using NUnit.Framework;

namespace QuickReqsSelenium
{
    class Program
    {

        // Try catch 
        static bool doesElementExist(string path, RemoteWebDriver driver) // Does it apear yes or no. 
        {

            try
            {
                driver.FindElement(By.XPath(path));
            }
            catch (Exception e)
            {
                return false;
            }

            return true;
        }

        static void failOnElementIdNotExists(string pathId, RemoteWebDriver driver) // Fail if it does not apear. 
        {
            try
            {
                Assert.IsTrue(driver.FindElement(By.Id(pathId)).Displayed);
                Console.Write("Item Field Displayed");
            }
            catch (Exception e)
            {
                Console.WriteLine("Unable to find element ID:"+pathId);
                Console.WriteLine(e);
                driver.Close();
            }
        }


      

        static void Main(string[] args)
        {

            

            var driver = new ChromeDriver();
            driver.Navigate().GoToUrl("https://webapps3.tylertech.com/int_dev/qa/munis/adam.fahey/AppHost/Requisitions/QuickEntry");
            
            // While loop to check if the page has loaded counts to a maximum of 30. 
            int counter = 1;
            int maxCounter = 30;
            while(!doesElementExist("//*[@id=\"Requisitions\"]/div[1]/div/div/div[2]/ul/li[2]/button", driver))
            {
                System.Threading.Thread.Sleep(1000);
                counter++;
                if (counter == maxCounter)
                {
                    break ;
                 

                }
            }

            failOnElementIdNotExists("Item_0", driver);


            //Go to Quick Reqs page and wait 30 seconds for page to load. 

            driver.FindElement(By.XPath("//*[@id=\"Requisitions\"]/div[1]/div/div/div[2]/ul/li[2]/button")).Click();
            System.Threading.Thread.Sleep(1000);


            failOnElementIdNotExists("Description_0", driver);
            //Click on the new reqs button. Wait 1 second.
            IWebElement element = driver.FindElement(By.Id("Description_0"));
            element.SendKeys("Test123");
            
            //Select Description fields type in Test 123
            IWebElement element2 = driver.FindElement(By.XPath("//*[@id=\"enterRequisitionTable\"]/tbody/tr[2]/td[3]"));
            element2.Click();
            System.Threading.Thread.Sleep(1000);
            
            //Click in UOM and wait 1 second.
            IWebElement element3 = driver.FindElement(By.XPath("//*[@id=\"Quantity_0\"]"));
            element3.SendKeys(Keys.Clear);
            element3.SendKeys("2.0");
            
            //Click on Quantity clear text field and enter 2.0
            IWebElement element4 = driver.FindElement(By.XPath("//*[@id=\"UnitPrice_0\"]"));
            element4.Click();
            element4.SendKeys(Keys.Clear);
            element4.SendKeys("10.00");
            
            //Click on Unit Price field, clear text, enter 10.00
            IWebElement element5 = driver.FindElement(By.XPath("//*[@id=\"RequisitionItemEllipsis_0\"]/i"));
            element5.Click();
            System.Threading.Thread.Sleep(2000);

            //Click on ellipsis and wait 2 seconds.
            driver.FindElement(By.Id("AllocateRequisitionItem_0")).Click();
            System.Threading.Thread.Sleep(500);
           
            //Click on Allocate
            System.Threading.Thread.Sleep(1000);
            IWebElement element7 = driver.FindElement(By.XPath("//*[@id=\"Requisitions\"]/div[2]/div/div/div/div[1]/enter-requisition-tab/div/div[2]/form/div[2]/requisition-item-details/div/requisition-item-allocations/div/div[1]/button[1]"));
            System.Threading.Thread.Sleep(1000);
            element7.Click();

            //Click on Set change GL account
            IWebElement element8 = driver.FindElement(By.XPath("//*[@id=\"GL_0\"]/div[2]/a"));
            element8.Click();
            System.Threading.Thread.Sleep(2000);

            //GL org code
            IWebElement element9 = driver.FindElement(By.XPath("//div[@id=\"tyl-id-0-mun-gl-account\"]/div/div/div/input"));
            element9.Click();
            System.Threading.Thread.Sleep(1000);
            element9.SendKeys("20001111");
            System.Threading.Thread.Sleep(1000);
            //Its working!

            // GL OBJ code
            IWebElement element10 = driver.FindElement(By.XPath("//div[@id=\"tyl-id-0-mun-gl-account\"]/div/div[2]/div/input"));
            element10.Click();
            System.Threading.Thread.Sleep(1000);
            element10.SendKeys("59400");
            System.Threading.Thread.Sleep(1000);

            //Click proj field
            IWebElement element11 = driver.FindElement(By.XPath("//div[@id=\"tyl-id-0-mun-gl-account\"]/div/div[3]/div/input"));
            System.Threading.Thread.Sleep(1000);
            element11.Click();

            //Click Save
            IWebElement element6 = driver.FindElement(By.Id("saveRequisitionButton"));
            System.Threading.Thread.Sleep(2000);
            element6.Click();



        }


    }
}

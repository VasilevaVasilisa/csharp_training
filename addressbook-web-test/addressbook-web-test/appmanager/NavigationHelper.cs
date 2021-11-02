using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace WebAddressbookTests
{
   public class NavigationHelper : HelperBase
    {
        
        private string baseURL;

        public NavigationHelper(ApplicationManager manager, string baseURL): base(manager)
        {
            this.baseURL = baseURL;
        }
        public void OpenHomePage()
        {
            if(driver.Url == baseURL)
            {
                return;
            }
            driver.Navigate().GoToUrl(baseURL);
        }
        public void GoToGroupsPage()
        {
            if (driver.Url == baseURL + "/group.php" && IsElementPresent(By.Name("new")))
            {
                return;
            }
            driver.FindElement(By.LinkText("groups")).Click();
        }

        public void GoToContactPage()
        {
            if (driver.Url == baseURL)
            {
                return;
            }
            driver.FindElement(By.LinkText("home")).Click();
        }

        public void AddNewContact()
        {
            if(driver.Url == baseURL + "/edit.php")
            {
                return;
            }
            driver.FindElement(By.LinkText("add new")).Click();
        }
    }
}

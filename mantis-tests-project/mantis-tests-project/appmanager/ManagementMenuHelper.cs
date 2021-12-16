using OpenQA.Selenium;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project
{
        public class ManagementMenuHelper : HelperBase
        {
        private string baseURL;

        public ManagementMenuHelper(ApplicationManager manager) : base(manager)
        {
        }

        public void OpenHomePage()
            {
                if (driver.Url == baseURL)
                {
                    return;
                }
                driver.Navigate().GoToUrl(baseURL);
            }
            public void GoToManagementPage()
            {
                if (driver.Url == baseURL + "manage_overview_page.php")
                {
                    return;
                }
                driver.FindElement(By.XPath("//div[@id='sidebar']/ul/li[7]/a/i")).Click();
            }

            public void GoToProjectManagementPage()
            {
                if (driver.Url == baseURL + "anage_proj_page.php")
                {
                    return;
                }
                driver.FindElement(By.LinkText("Управление проектами")).Click();
            }
        }
    }    


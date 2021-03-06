using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;


namespace mantis_tests_project
{
    public class ApplicationManager
    {
        protected IWebDriver driver;
        protected string baseURL;       
        protected LoginHelper loginHelper;
        private ProjectManagementHelper projectHelper;
        private ManagementMenuHelper menuHelper;

        private static ThreadLocal<ApplicationManager> app = new ThreadLocal<ApplicationManager>();
        

        private ApplicationManager()
        {
            driver = new FirefoxDriver();
            baseURL = "http://localhost/mantisbt-2.25.2";
            loginHelper = new LoginHelper(this);
            projectHelper = new ProjectManagementHelper(this);
            menuHelper = new ManagementMenuHelper(this, baseURL);
            
        }

        ~ApplicationManager()
        {
            try
            {
                driver.Quit();
            }
            catch (Exception)
            {
                // Ignore errors if unable to close the browser
            }
        }
        public static ApplicationManager GetInstance()
        {
            if (!app.IsValueCreated)
            {
                ApplicationManager newInstance = new ApplicationManager();
                newInstance.driver.Url = "http://localhost/mantisbt-2.25.2/admin/index.php";
                app.Value = newInstance;
            }
            return app.Value;
        }
        public IWebDriver Driver
        {
            get
            {
                return driver;
            }
        }

        public LoginHelper Auth
        {
            get
            {
                return loginHelper;
            }
        }

        public ManagementMenuHelper Menu 
        {
            get
            {
                return menuHelper;
            }
            
        }
        public ProjectManagementHelper Project 
        { 
            get 
            {
                return projectHelper;
            } 
        }
    }
}



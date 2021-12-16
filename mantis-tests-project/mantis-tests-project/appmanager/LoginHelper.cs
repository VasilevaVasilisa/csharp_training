using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace mantis_tests_project
{ 
    public class LoginHelper : HelperBase
    {
        public LoginHelper(ApplicationManager manager) : base(manager)
        {
        }
        public void Login(AccountDate account)
        {
            OpenLoginForm();
            FillLoginField(account);
            SubmitLogin();
            FillPasswordField(account);
            SubmitLogin();
        }

        private void OpenLoginForm()
        {
            driver.Navigate().GoToUrl("http://localhost/mantisbt-2.25.2/login_page.php");
        }

        private void FillLoginField(AccountDate account)
        {
            driver.FindElement(By.Id("username")).Click();
            driver.FindElement(By.Id("username")).Clear();
            driver.FindElement(By.Id("username")).SendKeys(account.Username);
        }

        private void FillPasswordField(AccountDate account)
        {
            driver.FindElement(By.Id("password")).Click();
            driver.FindElement(By.Id("password")).Clear();
            driver.FindElement(By.Id("password")).SendKeys(account.Password);
        }

        private void SubmitLogin()
        {
            driver.FindElement(By.XPath("//input[@value='Вход']")).Click();
            
        }
    }

}
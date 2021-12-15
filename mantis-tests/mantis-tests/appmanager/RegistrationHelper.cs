using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Text.RegularExpressions;
using OpenQA.Selenium.Firefox;

namespace mantis_tests
{
   public class RegistrationHelper : HelperBase
    {
        public RegistrationHelper (ApplicationManager manager) : base(manager) { }

        public void Register(AccountDate account)
        {
            OpenLoginPage();
            OpenRegistrationForm();
            FillRegistrationFormLogin(account);
            SubmitRegistrationLogin();
            String url = GetConfirmationUrl(account);
            FillPasswordForm(url, account);
            SubmitPasswordForm();
           
        }

        public void OpenLoginPage()
        {
            manager.Driver.Url = "http://localhost/mantisbt-2.25.2/admin/index.php";
        }
        public void FillRegistrationFormLogin(AccountDate account)
        {
            driver.FindElement(By.Name("username")).SendKeys(account.Name);
            driver.FindElement(By.Name("email")).SendKeys(account.Email);
        }
        public void SubmitRegistrationLogin()
        {
            driver.FindElement(By.XPath("//input[@value='Зарегистрироваться']")).Click();
        }
        public void OpenRegistrationForm()
        {
            driver.FindElement(By.LinkText("Зарегистрировать новую учётную запись")).Click();
        }

        public string GetConfirmationUrl(AccountDate account)
        {
            String message = manager.Mail.GetLastMail(account);
           Match match = Regex.Match(message, @"http://\S*");
            return match.Value;
        }

        public void FillPasswordForm(string url, AccountDate account)
        {
            driver.Url = url;
            driver.FindElement(By.Name("password")).SendKeys(account.Password);
            driver.FindElement(By.Name("password_confirm")).SendKeys(account.Password);
        }

        public void SubmitPasswordForm()
        {
            driver.FindElement(By.XPath("//form[@id='account-update-form']/fieldset/span/button/span")).Click();
        }

    }
}

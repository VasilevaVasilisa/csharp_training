using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
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
        //    OpenPasswordPage();
            FillRegistrationFormPassword();
            SubmitRegistrationPassword();


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
            throw new NotImplementedException();
        }
        public void OpenRegistrationForm()
        {
            driver.FindElements(By.CssSelector("span.bracket-link"))[0].Click();
        }

        public void OpenPasswordPage()
        {
            throw new NotImplementedException();
        }

        public void FillRegistrationFormPassword()
        {
            throw new NotImplementedException();
        }

        public void SubmitRegistrationPassword()
        {
            throw new NotImplementedException();
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace WebAddressbookTests
{
   public class ContactHelper : HelperBase
    {
        public ContactHelper(ApplicationManager manager) : base(manager)
        {
        }
        public ContactHelper Create(ContactDate contact)
        {
            manager.Navigator.AddNewContact();
            FillContactForm(contact);
            ReturnToContactPage();
            manager.Auth.Logout();
            return this;
        }
        public ContactHelper FillContactForm(ContactDate contact)
        {
            driver.FindElement(By.Name("firstname")).Click();
            driver.FindElement(By.Name("firstname")).Clear();
            driver.FindElement(By.Name("firstname")).SendKeys(contact.Firstname);
            driver.FindElement(By.Name("middlename")).Click();
            driver.FindElement(By.Name("middlename")).SendKeys(contact.Middlename);
            driver.FindElement(By.Name("lastname")).Click();
            driver.FindElement(By.Name("lastname")).Clear();
            driver.FindElement(By.Name("lastname")).SendKeys(contact.Lastname);
            driver.FindElement(By.Name("nickname")).Click();
            driver.FindElement(By.Name("nickname")).SendKeys(contact.Nickname);
            /* При открытии формы для выбора фото, не закрывает ее (recorder не записывает закрытие формы)
            driver.FindElement(By.Name("photo")).Click();
            */
            driver.FindElement(By.Name("title")).Click();
            driver.FindElement(By.Name("title")).SendKeys(contact.Title);
            driver.FindElement(By.Name("company")).Click();
            driver.FindElement(By.Name("company")).SendKeys(contact.Company);
            driver.FindElement(By.Name("address")).Click();
            driver.FindElement(By.Name("address")).SendKeys(contact.Address);
            //Telephone
            driver.FindElement(By.Name("home")).Click();
            driver.FindElement(By.Name("home")).SendKeys(contact.HomeTel);
            driver.FindElement(By.Name("mobile")).Click();
            driver.FindElement(By.Name("mobile")).SendKeys(contact.Mobile);
            driver.FindElement(By.Name("work")).Click();
            driver.FindElement(By.Name("work")).SendKeys(contact.WorkTel);
            driver.FindElement(By.Name("fax")).Click();
            driver.FindElement(By.Name("fax")).SendKeys(contact.Fax);
            //Email
            driver.FindElement(By.Name("email")).Click();
            driver.FindElement(By.Name("email")).SendKeys(contact.Email);
            driver.FindElement(By.Name("email2")).Click();
            driver.FindElement(By.Name("email2")).SendKeys(contact.Email2);
            driver.FindElement(By.Name("email3")).Click();
            driver.FindElement(By.Name("email3")).SendKeys(contact.Email3);
            driver.FindElement(By.Name("homepage")).Click();
            driver.FindElement(By.Name("homepage")).SendKeys(contact.Homepage);
            //Date Of Birth
            driver.FindElement(By.Name("bday")).Click();
            driver.FindElement(By.Name("bday")).SendKeys(contact.BirthDay);
            driver.FindElement(By.Name("bmonth")).Click();
            driver.FindElement(By.Name("bmonth")).SendKeys(contact.BirthMonth);
            driver.FindElement(By.Name("byear")).Click();
            driver.FindElement(By.Name("byear")).SendKeys(contact.BirthYear);
            // Anniversary
            driver.FindElement(By.Name("aday")).Click();
            driver.FindElement(By.Name("aday")).SendKeys(contact.AnniversaryDay);
            driver.FindElement(By.Name("amonth")).Click();
            driver.FindElement(By.Name("amonth")).SendKeys(contact.AnniversaryMonth);
            driver.FindElement(By.Name("ayear")).Click();
            driver.FindElement(By.Name("ayear")).SendKeys(contact.AnniversaryYear);
            driver.FindElement(By.Name("new_group")).Click();
            driver.FindElement(By.Name("new_group")).SendKeys(contact.Group);
            //Secondary
            driver.FindElement(By.Name("address2")).Click();
            driver.FindElement(By.Name("address2")).SendKeys(contact.Address2);
            driver.FindElement(By.Name("phone2")).Click();
            driver.FindElement(By.Name("phone2")).SendKeys(contact.Phone2);
            driver.FindElement(By.Name("notes")).Click();
            driver.FindElement(By.Name("notes")).SendKeys(contact.Notes);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

    }
}

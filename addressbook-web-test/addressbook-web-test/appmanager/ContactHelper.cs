using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using OpenQA.Selenium;
using NUnit.Framework;

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
            //SelectedGroupToContactForm(contact);
            FillContactForm(contact);
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Modify(int index, ContactDate newData)
        {
            manager.Navigator.GoToContactPage();
            HaveContacts(); //Проверка наличия контакта
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Remove (int index)
        {
            manager.Navigator.GoToContactPage();
            HaveContacts(); //Проверка наличия контакта
            SelectContact(index);
            SubmitContactRemove();
            return this;
        }

        public ContactHelper FillContactForm(ContactDate contact)
        {
            Type(By.Name("firstname"), contact.Firstname);
            Type(By.Name("middlename"), contact.Middlename);
            Type(By.Name("lastname"), contact.Lastname);
            Type(By.Name("nickname"), contact.Nickname);
            /* При открытии формы для выбора фото, не закрывает ее (recorder не записывает закрытие формы)
            driver.FindElement(By.Name("photo")).Click();
            */
            Type(By.Name("title"), contact.Title);
            Type(By.Name("company"), contact.Company);
            Type(By.Name("address"), contact.Address);
            //Telephone
            Type(By.Name("home"), contact.HomeTel);
            Type(By.Name("mobile"), contact.Mobile);
            Type(By.Name("work"), contact.WorkTel);
            Type(By.Name("fax"), contact.Fax);
            //Email
            Type(By.Name("email"), contact.Email);
            Type(By.Name("email2"), contact.Email2);
            Type(By.Name("email3"), contact.Email3);
            Type(By.Name("homepage"), contact.Homepage);
            //Date Of Birth
            Type(By.Name("bday"), contact.BirthDay);
            Type(By.Name("bmonth"), contact.BirthMonth);
            Type(By.Name("byear"), contact.BirthYear);
            // Anniversary
            Type(By.Name("aday"), contact.AnniversaryDay);
            Type(By.Name("amonth"), contact.AnniversaryMonth);
            Type(By.Name("ayear"), contact.AnniversaryYear);

            Type(By.Name("new_group"), contact.Group);
            /*           try
                       {
                           driver.FindElement(By.Name("new_group")).Click();
                           driver.FindElement(By.Name("new_group")).SendKeys(contact.Group);
                       }
                       catch { }
            */
            //Secondary
            Type(By.Name("address2"), contact.Address2);
            Type(By.Name("phone2"), contact.Phone2);
            Type(By.Name("notes"), contact.Notes);
            driver.FindElement(By.XPath("//div[@id='content']/form/input[21]")).Click();
            return this;
        }
        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + " + 1]/td[1]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            // driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + index + " + 1]/td[8]/a/img")).Click();
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            return this;
        }

        public ContactHelper SubmitContactRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            return this;
        }
     /*   public ContactHelper SelectedGroupToContactForm(ContactDate contact)
        {
            Type(By.Name("new_group"), contact.Group);
            return this;
        }*/
     public void HaveContacts()  //Проверка, если на странице не найден "карандашек", то в списке нет контактов. Далее создание контакта.
        {
            if (! IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img")))
            {
                Create(new ContactDate("Petr", "Petrov"));
                
            }
        }
      
    }
}

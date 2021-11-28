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
            InitContactModification(index);
            FillContactForm(newData);
            SubmitContactModification();
            ReturnToContactPage();
            return this;
        }

        public ContactHelper Remove (int index)
        {
            manager.Navigator.GoToContactPage();
            SelectContact(index);
            SubmitContactRemove();
            manager.Navigator.GoToContactPage();
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
            contactCash = null;
            return this;
        }
        public ContactHelper ReturnToContactPage()
        {
            driver.FindElement(By.LinkText("home page")).Click();
            return this;
        }

        public ContactHelper SelectContact(int index)
        {
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+1) + " + 1]/td[1]")).Click();
            return this;
        }

        public ContactHelper InitContactModification(int index)
        {
            // driver.FindElement(By.XPath("//img[@alt='Edit']")).Click();
            driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + (index+1) + " + 1]/td[8]/a/img")).Click();

            //еще один вариант нажать на кнопку редактирования
           /* driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[7]
                .FindElement(By.TagName("a")).Click();*/
            return this;
        }

        public ContactHelper SubmitContactModification()
        {
            driver.FindElement(By.Name("update")).Click();
            contactCash = null;
            return this;
        }

        public ContactHelper SubmitContactRemove()
        {
            driver.FindElement(By.XPath("//input[@value='Delete']")).Click();
            driver.SwitchTo().Alert().Accept();
            contactCash = null;
            return this;
        }
        /*   public ContactHelper SelectedGroupToContactForm(ContactDate contact)
           {
               Type(By.Name("new_group"), contact.Group);
               return this;
           }*/
        /*   public void SeachContacts()  //Проверка, если на странице не найден "карандашек", то в списке нет контактов. Далее создание контакта.
           {
               manager.Navigator.GoToContactPage();
               if (!HaveContacts())
               {
                   manager.Navigator.AddNewContact();
                   Create(new ContactDate("Petr", "Petrov"));
               }
           }
           public bool HaveContacts() //Существование контакта
           {
               return IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr[2]/td[8]/a/img"));
           }

           public int CountingContacts() //подсчет контактов
           {
               int result = 0;
               bool b = true;
               int count = 0;
               manager.Navigator.GoToContactPage();
               while (b)
               {
                   result = count;
                   count++;
                   b = IsElementPresent(By.XPath("//table[@id='maintable']/tbody/tr["+count+" +1]/td[8]/a/img"));

               }
               return result;
           }*/
        List<ContactDate> contactCash = null;
        public List<ContactDate> GetContactList()
        {
            if (contactCash == null)
            {
                manager.Navigator.GoToContactPage();

                contactCash = new List<ContactDate>();

                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("tr[name='entry']"));

                int i = 2;

                foreach (IWebElement element in elements)
                {
                    string LasttName = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]/td[2]")).Text;
                    string FirsttName = driver.FindElement(By.XPath("//table[@id='maintable']/tbody/tr[" + i + "]/td[3]")).Text;

                    ContactDate contact = new ContactDate(FirsttName, LasttName)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    contactCash.Add(contact);
                    i++;

                }

            }
            return new List<ContactDate>(contactCash);
        }
        public int GetContactCount()
        {
            return driver.FindElements(By.CssSelector("tr[name='entry']")).Count;
        }

        public ContactDate GetContactInformationFromTable(int index)
        {
            manager.Navigator.OpenHomePage();

            IList<IWebElement> cells = driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td")); //сохраняем ячейки таблицы
            string lastName = cells[1].Text;
            string firstName = cells[2].Text;
            string address = cells[3].Text;
            string allEmails = cells[4].Text;
            string allPhones = cells[5].Text;

            return new ContactDate(firstName, lastName)
            {
               Address = address,
               AllPhones = allPhones,
               AllEmails = allEmails
            };

        }

        public ContactDate GetContactInformationFromEditForm(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactModification(0);
            string firstName = driver.FindElement(By.Name("firstname")).GetAttribute("value"); //получение значения из формы редактирования по полю
            string lastName = driver.FindElement(By.Name("lastname")).GetAttribute("value");
            string address = driver.FindElement(By.Name("address")).GetAttribute("value");

            string homeTel = driver.FindElement(By.Name("home")).GetAttribute("value");
            string mobileTel = driver.FindElement(By.Name("mobile")).GetAttribute("value");
            string workTel = driver.FindElement(By.Name("work")).GetAttribute("value");

            string email = driver.FindElement(By.Name("email")).GetAttribute("value");
            string email2 = driver.FindElement(By.Name("email2")).GetAttribute("value");
            string email3 = driver.FindElement(By.Name("email3")).GetAttribute("value");

            return new ContactDate(firstName, lastName) 
            { 
                Address = address,
                HomeTel = homeTel,
                Mobile = mobileTel,
                WorkTel = workTel,
                Email = email,
                Email2 = email2,
                Email3 = email3,
            };
        }
        public string GetContactInformationFromDetailsPage(int index)
        {
            manager.Navigator.OpenHomePage();
            InitContactDetails(0);
            string details = driver.FindElement(By.CssSelector("div#content")).Text;

           /*   details  =  details.Replace(" ", "").Replace("H:", "").Replace("M:", "").Replace("W:", "").
                        Replace("-", "").Replace("(", "").Replace(")", "").Trim();*/

            return details;
        }

        public ContactHelper InitContactDetails(int index) //переход на страницу с детальной информацией контакта 
        {
            driver.FindElements(By.Name("entry"))[index].FindElements(By.TagName("td"))[6].FindElement(By.TagName("a")).Click();
            return this;
        }

        public int GetNumberOfSearchResults()
        {
            manager.Navigator.OpenHomePage();

            string numberOfResalts = driver.FindElement(By.CssSelector("span#search_count")).Text;

            return Int32.Parse(numberOfResalts);

            // Нахождение результата поиска контактов с помощью регулярного выражения 
         /*  string text = driver.FindElement(By.TagName("label")).Text;
           Match m = new Regex(@"\d+").Match(text); //создает специальный объект, регуляное выражение извлекает все цифры
           return Int32.Parse(m.Value); //значение m,  которое извлекли из строки сохраняем в int*/
                                                     
        }
    }
}

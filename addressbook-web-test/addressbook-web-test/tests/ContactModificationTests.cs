using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {

        public static IEnumerable<ContactDate> RandomContactDataProvider() //метод для создания контактов с рандомными данными
        {
            List<ContactDate> contacts = new List<ContactDate>();

            for (int i = 0; i < 5; i++) // генерация 5 тестовых наборов
            {
                contacts.Add(new ContactDate(GeneratorRandomString(30), GeneratorRandomString(40))
                {
                    Address = GeneratorRandomString(100)

                });

            }
            return contacts;
        }

        [Test, TestCaseSource("RandomContactDataProvider")]
        public void ContactModificationTest(ContactDate newData)
        {
           
            //ContactDate newData = new ContactDate("Maria", "Petrova"); 

           // List<ContactDate> oldContactsList = app.Contacts.GetContactList();
            List<ContactDate> oldContactsList = ContactDate.GetAll(); // Получение списка из БД

            if (oldContactsList.Count == 0)
            {
                ContactDate contact = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact);
                oldContactsList.Add(contact);
            }

            ContactDate oldData = oldContactsList[0];

            app.Contacts.Modify(0, newData);

            Assert.AreEqual(oldContactsList.Count, app.Contacts.GetContactCount());

            List<ContactDate> newContactsList = ContactDate.GetAll(); // Получение списка из БД

            oldContactsList[0].Firstname = newData.Firstname;
            oldContactsList[0].Lastname = newData.Lastname;    

            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList.Count, newContactsList.Count);
            Assert.AreEqual(oldContactsList, newContactsList);

            foreach (ContactDate contact in newContactsList)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);

                }
            }

        }
        [Test]
        public void ContactModificationTest2() //тест удаление контакта по id + бд
        {

            ContactDate newData = new ContactDate("Maria", "Petrova"); 

            List<ContactDate> oldContactsList = ContactDate.GetAll(); // Получение списка из БД

            if (oldContactsList.Count == 0)
            {
                ContactDate contact = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact);
                oldContactsList.Add(contact);
            }

            ContactDate oldData = oldContactsList[0];

            app.Contacts.Modify(oldData, newData);

            Assert.AreEqual(oldContactsList.Count, app.Contacts.GetContactCount());

            List<ContactDate> newContactsList = ContactDate.GetAll(); // Получение списка из БД

            oldContactsList[0].Firstname = newData.Firstname;
            oldContactsList[0].Lastname = newData.Lastname;

            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList.Count, newContactsList.Count);
            Assert.AreEqual(oldContactsList, newContactsList);

            foreach (ContactDate contact in newContactsList)
            {
                if (contact.Id == oldData.Id)
                {
                    Assert.AreEqual(newData.Firstname, contact.Firstname);
                    Assert.AreEqual(newData.Lastname, contact.Lastname);

                }
            }

        }
    }
}

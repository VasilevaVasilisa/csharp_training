using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class ContactCreationTests : AuthTestBase 
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
        public void ContactCreationTest(ContactDate contact)
        {
    /*        int countP;
            int countL;
    */
           // ContactDate contact = new ContactDate("Petr", "Petrov"); заменили на рандомное создание

            // countP = app.Contacts.CountingContacts(); //подсчет до создания
            List<ContactDate> oldContactsList = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContactsList.Count + 1, app.Contacts.GetContactCount());
            List<ContactDate> newContactsList = app.Contacts.GetContactList();
            // countL = app.Contacts.CountingContacts(); //подсчет после создания

            oldContactsList.Add(contact);
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList.Count , newContactsList.Count);
            Assert.AreEqual(oldContactsList, newContactsList);
            //    Assert.AreEqual(countP, countL - 1); //проверка что контакт создался, если список контактов увеличился
        }

    }
}

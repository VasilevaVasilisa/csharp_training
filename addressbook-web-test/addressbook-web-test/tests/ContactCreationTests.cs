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
        [Test]
        public void ContactCreationTest()
        {
    /*        int countP;
            int countL;
    */
            ContactDate contact = new ContactDate("Petr", "Petrov");

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

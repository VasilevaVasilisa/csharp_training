using System;
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
            int countP;
            int countL;
            ContactDate contact = new ContactDate("Petr", "Petrov");

            countP = app.Contacts.CountingContacts(); //подсчет до создания
            app.Contacts.Create(contact);
            countL = app.Contacts.CountingContacts(); //подсчет после создания

            Assert.AreEqual(countP, countL - 1); //проверка что контакт создался, если список контактов увеличился
        }

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public class ContactRemovalTests : AuthTestBase
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
        public void ContactRemovalTest(ContactDate contact)
        {
/*           int countP;
            int countL;
*/

            // countP = app.Contacts.CountingContacts(); //подсчет до удаления
            List<ContactDate> oldContactsList = app.Contacts.GetContactList();

            if(oldContactsList.Count == 0)
            {
               // ContactDate contact = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact);
                oldContactsList.Add(contact);
            }

            ContactDate toBeRemoved = oldContactsList[0];

            app.Contacts.Remove(0);
            
            Assert.AreEqual(oldContactsList.Count - 1 , app.Contacts.GetContactCount());
            List<ContactDate> newContactsList = app.Contacts.GetContactList();

            //countL = app.Contacts.CountingContacts(); //подсчет после удаления

            oldContactsList.RemoveAt(0);
           

            Assert.AreEqual(oldContactsList.Count, newContactsList.Count);
            Assert.AreEqual(oldContactsList, newContactsList);

            foreach (ContactDate contact_ in newContactsList)
            {
                Assert.AreNotEqual(contact_.Id, toBeRemoved.Id);
            }

            //Assert.AreEqual(countP, countL + 1); //проверка что контакт удалился, если список контактов уменьшился
        }

    }
}

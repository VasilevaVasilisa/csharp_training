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
        [Test]
        public void ContactRemovalTest()
        {
/*           int countP;
            int countL;
*/

            // countP = app.Contacts.CountingContacts(); //подсчет до удаления
            List<ContactDate> oldContactsList = app.Contacts.GetContactList();

            if(oldContactsList.Count == 0)
            {
                ContactDate contact = new ContactDate("Petr", "Petrov");
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

            foreach (ContactDate contact in newContactsList)
            {
                Assert.AreNotEqual(contact.Id, toBeRemoved.Id);
            }

            //Assert.AreEqual(countP, countL + 1); //проверка что контакт удалился, если список контактов уменьшился
        }

    }
}

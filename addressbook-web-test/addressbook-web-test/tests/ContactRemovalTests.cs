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
            int countP;
            int countL;

            app.Contacts.SeachContacts();
           countP = app.Contacts.CountingContacts(); //подсчет до удаления
            app.Contacts.Remove(1);
           countL = app.Contacts.CountingContacts(); //подсчет после удаления

            Assert.AreEqual(countP, countL + 1); //проверка что контакт удалился, если список контактов уменьшился
        }

    }
}

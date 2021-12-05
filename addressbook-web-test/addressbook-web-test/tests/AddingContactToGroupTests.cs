using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    public class AddingContactToGroupTests :AuthTestBase
    {
        [Test]
        public void AddingContactToGroupTest()
        {
           GroupData group = GroupData.GetAll()[0];
           List<ContactDate> oldList = group.GetContacts(); // Список контактов которые входят в группу
           ContactDate contact = ContactDate.GetAll().Except(oldList).First(); //Поиск контакта ,которого нет в заданной группе


            app.Contacts.AddContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}

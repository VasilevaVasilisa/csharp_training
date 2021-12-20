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
           List<GroupData> oldGroupList = GroupData.GetAll();

            if(oldGroupList.Count == 0)
            {
                GroupData group1 = new GroupData("group4");
                app.Groups.Create(group1);
                oldGroupList.Add(group1);
            }

            List<ContactDate> oldContactList = ContactDate.GetAll();
            if(oldContactList.Count == 0)
            {
                ContactDate contact1 = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact1);
                oldContactList.Add(contact1);
            }

           GroupData group = GroupData.GetAll()[0];
           List<ContactDate> oldList = group.GetContacts(); // Список контактов которые входят в группу

           ContactDate contact = ContactDate.GetAll().Except(oldList).FirstOrDefault(); //Поиск контакта ,которого нет в заданной группе
            if (contact == null)
            {
                ContactDate contact2 = new ContactDate("Maria", "Petrova");
                app.Contacts.Create(contact2);
                oldContactList.Add(contact2);
                contact = ContactDate.GetAll().Except(oldList).FirstOrDefault();
            }

            app.Contacts.AddContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();
            oldList.Add(contact);
            oldList.Sort();
            newList.Sort();
            Assert.AreEqual(oldList, newList);
        }

    }
}

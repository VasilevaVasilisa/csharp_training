using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    class DeleteContactFromGroupTests : AuthTestBase
    {
        [Test]
        public void DeleteContactFromGroupTest()
        {
            List<GroupData> oldGroupList = GroupData.GetAll();

            if (oldGroupList.Count == 0)
            {
                GroupData group1 = new GroupData("group4");
                app.Groups.Create(group1);
                oldGroupList.Add(group1);   
            }

            List<ContactDate> oldContactList = ContactDate.GetAll();

            if (oldContactList.Count == 0)
            {
                ContactDate contact1 = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact1);
                oldContactList.Add(contact1);
            }

            GroupData group = GroupData.GetAll()[0];
            
            List<ContactDate> oldList = group.GetContacts(); // Список контактов которые входят в группу

            if (oldList.Count == 0) //если в группе нет контактов
            {
                ContactDate contact_new = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact_new); //создаем контакт
                oldContactList.Add(contact_new);
                app.Contacts.AddContactToGroup(contact_new, group); //добавляем в группу
            }

            ContactDate contact = ContactDate.GetAll().Intersect(oldList).FirstOrDefault(); //Поиск контакта ,который есть в заданной группе
   
            app.Contacts.DeleteContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();

            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
      


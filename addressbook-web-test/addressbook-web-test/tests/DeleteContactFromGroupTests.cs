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
            GroupData group = GroupData.GetAll()[0];
            
            List<ContactDate> oldList = group.GetContacts(); // Список контактов которые входят в группу
            ContactDate contact = ContactDate.GetAll().Intersect(oldList).First(); //Поиск контакта ,которого есть в заданной группе

            if (oldList.Count == 0) //если в группе нет контактов
            {
                ContactDate contact_new = new ContactDate("Petr", "Petrov");
                app.Contacts.Create(contact_new); //создаем контакт
                app.Contacts.AddContactToGroup(contact_new, group); //добавляем в группу
                contact = ContactDate.GetAll().Intersect(oldList).First(); 
            }

            
            app.Contacts.DeleteContactToGroup(contact, group);

            List<ContactDate> newList = group.GetContacts();

            oldList.Remove(contact);
            oldList.Sort();
            newList.Sort();

            Assert.AreEqual(oldList, newList);
        }
    }
}
      


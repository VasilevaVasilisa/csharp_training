using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
   public class ContactTestBase : AuthTestBase
    {
        [TearDown]//тест который будет выполнятся в конце каждого теста с контактами
        public void CompareContactsUI_DB()
        {
            List<ContactDate> fromUI = app.Contacts.GetContactList();
            List<ContactDate> fromDB = ContactDate.GetAll();
            fromUI.Sort();
            fromDB.Sort();
            Assert.AreEqual(fromUI, fromDB); //сравниваем списки с UI и  с БД

        }

    }
}

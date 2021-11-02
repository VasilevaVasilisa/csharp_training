using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    class ContactModificationTests : AuthTestBase
    {
        

        [Test]
        public void ContactModificationTest()
        {
            ContactDate newData = new ContactDate("Maria", "Petrova");
            app.Contacts.Modify(1, newData);
        }
    }
}

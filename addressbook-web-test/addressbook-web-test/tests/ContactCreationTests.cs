using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class ContactCreationTests : TestBase

    {
        [Test]
        public void ContactCreationTest()
        {
            ContactDate contact = new ContactDate("Petr", "Petrov");

            app.Contacts.Create(contact);
        }

    }
}

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public class SearchTests : AuthTestBase
    {
        [Test]
        public void TestSearchContacts()
        {
           List<ContactDate> contactsList = app.Contacts.GetContactList();
           int numberOfResults = app.Contacts.GetNumberOfSearchResults();

            Assert.AreEqual(contactsList.Count, numberOfResults);
        }
    }
}

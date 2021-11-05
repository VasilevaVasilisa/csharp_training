using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupModificationTests : AuthTestBase
    {
        [Test]
        public void GroupModificationTest()
        {

            GroupData newData = new GroupData("group2");
            newData.Header = "ddd";
            newData.Footer = "sss";

            app.Groups.SearchGroups(); //если группа не создастся, то следующий метод модификации не выполнится
            app.Groups.Modify(1, newData);

        }
    }
}

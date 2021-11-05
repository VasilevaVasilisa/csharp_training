using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            int countP;
            int countL;

            GroupData group = new GroupData("group2");
            group.Header = "ddd";
            group.Footer = "sss";

           countP = app.Groups.CountingGroups();
           app.Groups.Create(group);
           countL =  app.Groups.CountingGroups();

            Assert.AreEqual(countP, countL - 1);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
            int countP;
            int countL;

            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            countP = app.Groups.CountingGroups(); // подсчет до создания
            app.Groups.Create(group);
            countL = app.Groups.CountingGroups();// подсчет до создания

            Assert.AreEqual(countP, countL - 1); //группа создана, если список групп увеличился
        }

    }

}

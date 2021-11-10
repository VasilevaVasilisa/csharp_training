using System;
using System.Collections.Generic;
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
           /* int countP;
            int countL;
           */
            GroupData group = new GroupData("group2");
            group.Header = "ddd";
            group.Footer = "sss";

          // countP = app.Groups.CountingGroups();
           List<GroupData> oldGroupList = app.Groups.GetGroupList();
           app.Groups.Create(group);
           Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
            // countL =  app.Groups.CountingGroups();
           List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();

            // Assert.AreEqual(countP, countL - 1);
            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        [Test]
        public void EmptyGroupCreationTest()
        {
    /*      int countP;
            int countL;
    */
            GroupData group = new GroupData("");
            group.Header = "";
            group.Footer = "";

            // countP = app.Groups.CountingGroups(); // подсчет до создания
            List<GroupData> oldGroupList = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();
            // countL = app.Groups.CountingGroups();// подсчет до создания

            // Assert.AreEqual(countP, countL - 1); //группа создана, если список групп увеличился
            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroupList = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);
        }
    }

}

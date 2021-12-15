using System;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
        [Test]
        public void GroupCreationTest()
        {
            List<GroupData> oldListGroups = app.Groups.GetGroupList();

            GroupData newGroup = new GroupData()
            {
                Name = "test"
            };

            app.Groups.Add(newGroup);

            System.Threading.Thread.Sleep(1000);

            List<GroupData> newListGroups = app.Groups.GetGroupList();

            oldListGroups.Add(newGroup);
            oldListGroups.Sort();
            newListGroups.Sort();
           
            Assert.AreEqual(oldListGroups, newListGroups);
        }
    }
}

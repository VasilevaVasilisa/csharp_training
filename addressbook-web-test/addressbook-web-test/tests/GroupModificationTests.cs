using System;
using System.Collections.Generic;
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


            List<GroupData> oldGroupList = app.Groups.GetGroupList();

            if (oldGroupList.Count ==0)
            {
                GroupData group = new GroupData("group4");
                app.Groups.Create(group);
                oldGroupList.Add(group);
            }

            GroupData oldData = oldGroupList[0];

            app.Groups.Modify(0, newData);

            Assert.AreEqual(oldGroupList.Count, app.Groups.GetGroupCount());

            List<GroupData> newGroupList = app.Groups.GetGroupList();
            oldGroupList[0].Name = newData.Name;
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);

            foreach (GroupData group in newGroupList)
            {
                if (group.Id == oldData.Id)
                {
                 Assert.AreEqual(newData.Name, group.Name);
                }
            }
        }
    }
}

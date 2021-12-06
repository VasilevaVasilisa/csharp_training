using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Collections.Generic;
using NUnit.Framework;

namespace addressbook_tests_autoit
{
    [TestFixture]
    public class GroupRemovalTests : TestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            List<GroupData> oldListGroups = app.Groups.GetGroupList();

            if(oldListGroups.Count == 0)
            {
                GroupData newGroup = new GroupData() { Name = "test"};
                app.Groups.Add(newGroup);
                oldListGroups.Add(newGroup);

            }

            GroupData toBeRemoved = oldListGroups[0];

            app.Groups.Remove(0);

            List<GroupData> newListGroups = app.Groups.GetGroupList();
            oldListGroups.RemoveAt(0);

            Assert.AreEqual(oldListGroups, newListGroups);
        }
    }
}

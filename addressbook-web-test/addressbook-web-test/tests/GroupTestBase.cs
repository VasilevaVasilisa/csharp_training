using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace WebAddressbookTests
{
   public class GroupTestBase : AuthTestBase
    {
        [TearDown] //тест который будет выполнятся в конце каждого теста с группами
        public void CompareGroupsUI_DB()
        {
            List<GroupData> fromUI = app.Groups.GetGroupList();
            List<GroupData> fromDB = GroupData.GetAll();
            fromUI.Sort();
            fromDB.Sort();
            Assert.AreEqual(fromUI, fromDB); //сравниваем списки с UI и  с БД

        }
    }
}

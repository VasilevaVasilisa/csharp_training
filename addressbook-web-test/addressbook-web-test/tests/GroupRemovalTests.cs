using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : AuthTestBase
    {
        [Test]
        public void GroupRemovalTest()
        {
            int countP;
            int countL;

            app.Groups.SearchGroups();
            countP = app.Groups.CountingGroups(); //подсчет до удаления
            app.Groups.Remove(1);
            countL = app.Groups.CountingGroups();//подсчет после удаления

            Assert.AreEqual(countP, countL + 1); // группа удалена, если список групп уменьшился
        }

      

    }
    
}
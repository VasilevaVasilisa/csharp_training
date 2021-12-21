using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project
{
    [TestFixture]
   public class ProjectRemovalTests : AuthTestBase
    {
        [Test]
        public void ProjectRemovalTest()

        {
            AccountDate account = new AccountDate()
            {
                Username = "administrator",
                Password = "root"
            };
            List<ProjectDate> oldList = app.Project.GetProjectList(account);

            ProjectDate toBeRemoved = oldList[0]; 

              if (oldList.Count == 0)
              {
                ProjectDate project = new ProjectDate("");
                
                app.Project.Create(project);
                oldList.Add(project);
              }

            app.Project.Remove(0); //Заменили 0 на oldGroupList[0]

            Assert.AreEqual(oldList.Count - 1, app.Project.GetProjectCount());

            oldList.RemoveAt(0);

            List<ProjectDate> newList = app.Project.GetProjectList(account);

            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

          /*  foreach (ProjectDate project_ in newList)
            {
                Assert.AreNotEqual(project_.Id, toBeRemoved.Id);
            }*/
        }
    }
}

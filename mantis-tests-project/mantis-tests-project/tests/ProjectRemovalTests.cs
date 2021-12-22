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
        public static IEnumerable<ProjectDate> RandomProjectDataProvider()
        {
            List<ProjectDate> projects = new List<ProjectDate>();

            for (int i = 0; i < 1; i++)
            {
                projects.Add(new ProjectDate(GeneratorRandomString(30)));

            }
            return projects;
        }
        [Test, TestCaseSource("RandomProjectDataProvider")]
        public void ProjectRemovalTest(ProjectDate project)

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
                
                app.Project.Add(project, account);

                oldList = app.Project.GetProjectList(account);
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

        [Test]
        public void ProjectRemovalTest2()

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

                app.Project.Add(project, account);

                oldList = app.Project.GetProjectList(account);
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

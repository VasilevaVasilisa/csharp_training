using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project
{
    [TestFixture]
   public class ProjectCreationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            AccountDate account = new AccountDate()
            {
                Username = "administrator",
                Password = "root"
            };
            ProjectDate project = new ProjectDate("");
            

            List<ProjectDate> oldList = app.Project.GetProjectList(account);

            app.Project.Create(project);

            List<ProjectDate> newList = app.Project.GetProjectList(account);

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
         
            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

        }
    }
}

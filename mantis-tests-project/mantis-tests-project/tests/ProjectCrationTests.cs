using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project
{
    [TestFixture]
   public class ProjectCrationTests : AuthTestBase
    {
        [Test]
        public void ProjectCreationTest()
        {
            ProjectDate project = new ProjectDate()
            {
                Name = ""
            };

            List<ProjectDate> oldList = app.Project.GetProjectList();

            app.Project.Create(project);
            List<ProjectDate> newList = app.Project.GetProjectList();

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
         
            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

        }
    }
}

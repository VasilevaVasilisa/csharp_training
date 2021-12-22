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
        public void ProjectCreationTest(ProjectDate project)
        {
            AccountDate account = new AccountDate()
            {
                Username = "administrator",
                Password = "root"
            };
            
            List<ProjectDate> oldList = app.Project.GetProjectList(account);

            app.Project.Create(project);

            List<ProjectDate> newList = app.Project.GetProjectList(account);

            oldList.Add(project);
            oldList.Sort();
            newList.Sort();
         
            Assert.AreEqual(oldList.Count, newList.Count);
            Assert.AreEqual(oldList, newList);

        }

        [Test]
        public void ProjectCreationTest2()
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

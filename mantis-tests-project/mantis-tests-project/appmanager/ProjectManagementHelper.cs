using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;

namespace mantis_tests_project
{
   public class ProjectManagementHelper : HelperBase
    {
        public ProjectManagementHelper(ApplicationManager manager) : base(manager)
        {

        }

        public void Create(ProjectDate project)
        {
            manager.Menu.GoToManagementPage();
            manager.Menu.GoToProjectManagementPage();
            SubmitCreatedNewProject();
            FillProjectForm(project);
            SubmitAddProject();  
        }
      
        internal void Remove(int index)
        {
            manager.Menu.GoToManagementPage();
            manager.Menu.GoToProjectManagementPage();
            GoInProject(index);
            SubmitRemoveProject();
        }

        public void GoInProject(int index)
        {
            driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr["+(index+1)+"]/td/a")).Click();
        }

        public void SubmitRemoveProject()
        {
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
            driver.FindElement(By.XPath("//input[@value='Удалить проект']")).Click();
        }

        public void SubmitCreatedNewProject()
        {
            driver.FindElement(By.XPath("//button[@type='submit']")).Click();
        }    
        public void FillProjectForm(ProjectDate project)
        {
            driver.FindElement(By.Id("project-name")).Click();
            driver.FindElement(By.Id("project-name")).Clear();
            driver.FindElement(By.Id("project-name")).SendKeys(project.Name);
        }

        public void SubmitAddProject()
        {
           driver.FindElement(By.XPath("//input[@value='Добавить проект']")).Click();
        }


        List<ProjectDate> projectCash = null;
        public List<ProjectDate> GetProjectList()  // ????
        {
            if (projectCash == null)
            {
                manager.Menu.GoToManagementPage();
                manager.Menu.GoToProjectManagementPage();

                projectCash = new List<ProjectDate>();

                ICollection<IWebElement> elements = driver.FindElements(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a"));

                int i = 1;

                foreach (IWebElement element in elements)
                {
                    string name = driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[" + i + "]/td/a")).Text;
                    

                    ProjectDate project = new ProjectDate()
                    {
                        Name = driver.FindElement(By.XPath("//div[@id='main-container']/div[2]/div[2]/div/div/div[2]/div[2]/div/div[2]/table/tbody/tr[" + i + "]/td/a")).Text
                    };
                    projectCash.Add(project);
                    i++;

                }

            }
            return new List<ProjectDate>(projectCash);
        }

        public double GetGroupCount()
        {
            return driver.FindElements(By.XPath("//div[@class='table-responsive']/table/tbody/tr/td/a")).Count;
        }

    }
}

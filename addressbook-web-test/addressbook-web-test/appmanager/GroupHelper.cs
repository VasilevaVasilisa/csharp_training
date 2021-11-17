using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using OpenQA.Selenium;
using System.Collections;


namespace WebAddressbookTests
{
   public class GroupHelper : HelperBase
    {
        public GroupHelper(ApplicationManager manager) : base(manager)
        {
        }
        public GroupHelper Create(GroupData group) 
        {
            manager.Navigator.GoToGroupsPage();
            InitNewGroupCreation();
            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Modify(int index ,GroupData newData)
        {
            manager.Navigator.GoToGroupsPage(); 
            SelectGroup(index);
            InitGroupModification();
            FillGroupForm(newData);
            SubmitGroupModification();
            ReturnToGroupPage();
            return this;
        }

        public GroupHelper Remove(int index)
        {
            manager.Navigator.GoToGroupsPage();
            SelectGroup(index);
            RemoveGroup();
            ReturnToGroupPage();
            return this;
        }
        public GroupHelper InitNewGroupCreation()
        {
            driver.FindElement(By.Name("new")).Click();
            return this;
        }

        public GroupHelper FillGroupForm(GroupData group)
        {
            Type(By.Name("group_name"), group.Name);
            Type(By.Name("group_header"), group.Header);
            Type(By.Name("group_footer"), group.Footer);
            return this;
        }
        public GroupHelper SubmitGroupCreation()
        {
            driver.FindElement(By.Name("submit")).Click();
            groupCash = null;
            return this;
        }
        public GroupHelper ReturnToGroupPage()
        {
            driver.FindElement(By.LinkText("group page")).Click();
            return this;
        }
        public GroupHelper SelectGroup(int index)
        {
            driver.FindElement(By.XPath("//div[@id='content']/form/span[" + (index +1)+ "]/input")).Click();
            return this;
        }
        public GroupHelper RemoveGroup()
        {
            driver.FindElement(By.Name("delete")).Click();
            groupCash = null;
            return this;
        }
        public GroupHelper InitGroupModification()
        {
            driver.FindElement(By.Name("edit")).Click();
            return this;
        }
        public GroupHelper SubmitGroupModification()
        {
            driver.FindElement(By.Name("update")).Click();
            groupCash = null;
            return this;
        }

        /*      public bool HaveGroups() // существование группы
              {
                  manager.Navigator.GoToGroupsPage();
                  return IsElementPresent(By.Name("selected[]"));
              }*/

        /*     public int CountingGroups() //подсчет групп
             {
                 int result = 0;
                 bool b=true;
                 int count = 0;
                 manager.Navigator.GoToGroupsPage();
                 while (b)
                 {
                     result = count;
                     count++;
                     b = IsElementPresent(By.XPath("//div[@id='content']/form/span[" + count + "]"));

                 }
                 return result; 
             }
        */
        private List<GroupData> groupCash = null;
        public List<GroupData> GetGroupList()
        {
            if (groupCash == null)
            {
                groupCash = new List<GroupData>();
                manager.Navigator.GoToGroupsPage();
                ICollection<IWebElement> elements = driver.FindElements(By.CssSelector("span.group"));

                foreach (IWebElement element in elements)
                {
                    GroupData group = new GroupData(element.Text)
                    {
                        Id = element.FindElement(By.TagName("input")).GetAttribute("value")
                    };
                    
                    groupCash.Add(group);


/*                   Для работы данного кода, нужно изменить  (element.Text) на null. Предназначен для оптимизации 
 *                   
                    string allGroupNames = driver.FindElement(By.CssSelector("div#content form")).Text; //получение текста из формы 
                    string[] parts = allGroupNames.Split('\n'); //получение названий всех групп
                    int shift = groupCash.Count - parts.Length; //находим сдвиг (для групп с пустым именем) насколько в кеше правильных групп больше , чем в тех которые получили в parts
                    for (int i = 0; i < groupCash.Count; i++)
                    {
                        if (i < shift)
                        {
                            groupCash[i].Name = "";  //пустое имя 
                        }
                        else
                        {
                            groupCash[i].Name = parts[i-shift].Trim(); //Trim убирает лишние пробелы и переводы строк
                        }
                       
                    }*/
                }
            }
            return new List<GroupData>(groupCash); 
        }
        public int GetGroupCount()
        {
            return driver.FindElements(By.CssSelector("span.group")).Count;
        }

    }
}

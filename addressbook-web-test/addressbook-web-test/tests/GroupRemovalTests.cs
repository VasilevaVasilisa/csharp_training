using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupRemovalTests : GroupTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider() //метод для создания групп с рандомными данными
        {
            List<GroupData> groups = new List<GroupData>();

            for (int i = 0; i < 5; i++) // генерация 5 тестовых наборов
            {
                groups.Add(new GroupData(GeneratorRandomString(30)) //max длина строки
                {
                    Header = GeneratorRandomString(100),
                    Footer = GeneratorRandomString(100)
                });

            }
            return groups;
        }
        [Test, TestCaseSource("RandomGroupDataProvider")]
        public void GroupRemovalTest(GroupData group)
        {
            /*      int countP;
                    int countL;
            */

            //  List<GroupData> oldGroupList = app.Groups.GetGroupList();  Используется метод получения списка групп с UI
            List<GroupData> oldGroupList = GroupData.GetAll(); // Используется метод получения списка групп с БД

            GroupData toBeRemoved = oldGroupList[0]; //создание объекта удаленной группы

            if (oldGroupList.Count == 0)
            {
                app.Groups.Create(group);
                oldGroupList.Add(group);
            }
            
            // countP = app.Groups.CountingGroups(); //подсчет до удаления
            app.Groups.Remove(toBeRemoved); //Заменили 0 на oldGroupList[0]
            Assert.AreEqual(oldGroupList.Count - 1, app.Groups.GetGroupCount());
 //           List<GroupData> newGroupList = app.Groups.GetGroupList();
            // countL = app.Groups.CountingGroups();//подсчет после удаления
          //GroupData toBeRemoved = oldGroupList[0]; //создание объекта удаленной группы
            oldGroupList.RemoveAt(0);
            // List<GroupData> newGroupList = app.Groups.GetGroupList();
            List<GroupData> newGroupList = GroupData.GetAll();
            //Assert.AreEqual(countP, countL + 1); // группа удалена, если список групп уменьшился
            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);

      //      Console.WriteLine("group = " + newGroupList[0].Id, "toBeRemoved = " + toBeRemoved.Id);

            foreach (GroupData group_ in newGroupList)
            {
              
                Assert.AreNotEqual(group_.Id, toBeRemoved.Id);
                
            }
            
        }

        [Test]
        public void GroupRemovalTest2()
        {
            List<GroupData> oldGroupList = GroupData.GetAll(); // Используется метод получения списка групп с БД

            GroupData toBeRemoved = oldGroupList[0]; //создание объекта удаленной группы

          /*  if (oldGroupList.Count == 0)
            {
                app.Groups.Create();
                oldGroupList.Add(group);
            }*/   
            app.Groups.Remove(toBeRemoved); //Заменили 0 на oldGroupList[0]
            Assert.AreEqual(oldGroupList.Count - 1, app.Groups.GetGroupCount());    
            oldGroupList.RemoveAt(0);
           
            List<GroupData> newGroupList = GroupData.GetAll();
          
            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);

            foreach (GroupData group_ in newGroupList)
            {

                Assert.AreNotEqual(group_.Id, toBeRemoved.Id);

            }

        }

    }
    
}
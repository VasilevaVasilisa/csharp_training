using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.IO;
using System.Xml;
using System.Linq;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;


namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : AuthTestBase
    {
        public static IEnumerable<GroupData> RandomGroupDataProvider() //метод для создания групп с рандомными данными
        {
            List<GroupData> groups = new List<GroupData>();

            for(int i = 0; i<5; i++) // генерация 5 тестовых наборов
            {
                groups.Add(new GroupData(GeneratorRandomString(30)) //max длина строки
                { Header = GeneratorRandomString(100), 
                  Footer = GeneratorRandomString(100)
                });
                
            }    
            return groups;
        }

        public static IEnumerable<GroupData> GroupDataFromCsvFile() //метод для создания групп с рандомными данными из ФАЙЛА CSV (чтнение данных их файла)
        {
            List<GroupData> groups = new List<GroupData>();
            string [] lines =  File.ReadAllLines(@"groups.csv");   // ReadAllLines, чтение все строчек файла
            foreach (string l in lines)
            {
                string [] parts =  l.Split(','); //разбиение на части , до разделителя в ввиде запятой. Сохраняем набор частей 
                groups.Add(new GroupData(parts[0]) //parts[0] название группы
                { 
                    Header = parts[1],
                    Footer = parts[2]
                }); // данные прочитаны из файла и помещены в список
            }
            return groups; 
        }

        public static IEnumerable<GroupData> GroupDataFromXmlFile() //метод для создания групп с рандомными данными из ФАЙЛА XML (чтнение данных их файла)
        {
            List<GroupData> groups = new List<GroupData>();

            return (List<GroupData>) //приведение типа
                new XmlSerializer(typeof(List<GroupData>)) 
                .Deserialize(new StreamReader(@"groups.xml")); //читаем данные типа List<GroupData> из файла
        }

        public static IEnumerable<GroupData> GroupDataFromJsonFile() //метод для создания групп с рандомными данными из ФАЙЛА Json (чтнение данных их файла)
        {
           return JsonConvert.DeserializeObject<List<GroupData>>(
                File.ReadAllText(@"groups.json"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")] //чтобы привязать тест к генератору , TestCaseSource - использование внешнего источника тестовых данных

        public void GroupCreationTest(GroupData group) //добавили параметр
        {
           /* int countP;
            int countL;
           */
       /*     GroupData group = new GroupData("group2");
            group.Header = "ddd";
            group.Footer = "sss";*/

          // countP = app.Groups.CountingGroups();
           List<GroupData> oldGroupList = app.Groups.GetGroupList();
           app.Groups.Create(group);
           Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
            // countL =  app.Groups.CountingGroups();
           List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();

            // Assert.AreEqual(countP, countL - 1);
            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")] //чтобы привязать тест к генератору , TestCaseSource - использование внешнего источника тестовых данных

        public void GroupCreationTest2(GroupData group) //добавили параметр
        {          
            List<GroupData> oldGroupList = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
            
            List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);
        }
        /*       [Test] Теперь пустые тестовые даные будут генерироваться в генераторе 
                 public void EmptyGroupCreationTest()
               {
                  // int countP;
                 //  int countL;

                   GroupData group = new GroupData("");
                   group.Header = "";
                   group.Footer = "";

                   // countP = app.Groups.CountingGroups(); // подсчет до создания
                   List<GroupData> oldGroupList = app.Groups.GetGroupList();
                   app.Groups.Create(group);
                   Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
                   List<GroupData> newGroupList = app.Groups.GetGroupList();

                   oldGroupList.Add(group);
                   oldGroupList.Sort();
                   newGroupList.Sort();
                   // countL = app.Groups.CountingGroups();// подсчет до создания

                   // Assert.AreEqual(countP, countL - 1); //группа создана, если список групп увеличился
                   Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
                   Assert.AreEqual(oldGroupList, newGroupList);
               }*/


        [Test]
        public void BadNameGroupCreationTest()
        {
            GroupData group = new GroupData("a'a");
            group.Header = "";
            group.Footer = "";

            List<GroupData> oldGroupList = app.Groups.GetGroupList();
            app.Groups.Create(group);
            Assert.AreEqual(oldGroupList.Count + 1, app.Groups.GetGroupCount());
            List<GroupData> newGroupList = app.Groups.GetGroupList();

            oldGroupList.Add(group);
            oldGroupList.Sort();
            newGroupList.Sort();

            Assert.AreEqual(oldGroupList.Count, newGroupList.Count);
            Assert.AreEqual(oldGroupList, newGroupList);
        }


        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now ;// запоминаем текущее время
            List<GroupData> fromUi =  app.Groups.GetGroupList(); //список полученный из пользовательского интерфейса
            DateTime end = DateTime.Now; //время когда получили список
            System.Console.Out.WriteLine(end.Subtract(start)); // выводим разницу между началом и концом работы 

            start = DateTime.Now;
            /* using (AddressBookDB db = new AddressBookDB()) // установление подключения к бд
             {
                 List<GroupData> fromDb = (from g in db.Groups select g).ToList(); //список полученный из БД
             }*/ //Перенесли в метод GetAll в GroupData

            // db.Close();  используем using, чтобы бд закрывалась автоматически
            List<GroupData> fromDb = GroupData.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }

}

using System;
using System.Collections.Generic;
using System.IO;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using NUnit.Framework;

namespace WebAddressbookTests
{ 
    [TestFixture]
    public class ContactCreationTests : AuthTestBase 
    {
        public static IEnumerable<ContactDate> RandomContactDataProvider() //метод для создания контактов с рандомными данными
        {
            List<ContactDate> contacts = new List<ContactDate>();

            for (int i = 0; i < 5; i++) // генерация 5 тестовых наборов
            {
                contacts.Add(new ContactDate(GeneratorRandomString(30), GeneratorRandomString(40)) 
                {
                  Address = GeneratorRandomString(100)

                });

            }
            return contacts;
        }

        public static IEnumerable<ContactDate> GroupDataFromXmlFile() //метод для создания групп с рандомными данными из ФАЙЛА XML (чтнение данных их файла)
        {
            List<ContactDate> groups = new List<ContactDate>();

            return (List<ContactDate>) //приведение типа
                new XmlSerializer(typeof(List<ContactDate>))
                .Deserialize(new StreamReader(@"contacts.xml")); //читаем данные типа List<ContactDate> из файла
        }

        public static IEnumerable<ContactDate> GroupDataFromJsonFile() //метод для создания контактов с рандомными данными из ФАЙЛА Json (чтнение данных их файла)
        {
            return JsonConvert.DeserializeObject<List<ContactDate>>(
                 File.ReadAllText(@"contacts.json"));
        }

        [Test, TestCaseSource("GroupDataFromXmlFile")]
        public void ContactCreationTest(ContactDate contact)
        {
    /*        int countP;
            int countL;
    */
           // ContactDate contact = new ContactDate("Petr", "Petrov"); заменили на рандомное создание

            // countP = app.Contacts.CountingContacts(); //подсчет до создания
            List<ContactDate> oldContactsList = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContactsList.Count + 1, app.Contacts.GetContactCount());
            List<ContactDate> newContactsList = app.Contacts.GetContactList();
            // countL = app.Contacts.CountingContacts(); //подсчет после создания

            oldContactsList.Add(contact);
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList.Count , newContactsList.Count);
            Assert.AreEqual(oldContactsList, newContactsList);
            //    Assert.AreEqual(countP, countL - 1); //проверка что контакт создался, если список контактов увеличился
        }

        [Test, TestCaseSource("GroupDataFromJsonFile")]
        public void ContactCreationTest2(ContactDate contact)
        {          
            List<ContactDate> oldContactsList = app.Contacts.GetContactList();
            app.Contacts.Create(contact);
            Assert.AreEqual(oldContactsList.Count + 1, app.Contacts.GetContactCount());
            List<ContactDate> newContactsList = app.Contacts.GetContactList();
           
            oldContactsList.Add(contact);
            oldContactsList.Sort();
            newContactsList.Sort();

            Assert.AreEqual(oldContactsList.Count, newContactsList.Count);
            Assert.AreEqual(oldContactsList, newContactsList);          
        }

        [Test]
        public void TestDBConnectivity()
        {
            DateTime start = DateTime.Now;// запоминаем текущее время
            List<ContactDate> fromUi = app.Contacts.GetContactList(); //список полученный из пользовательского интерфейса
            DateTime end = DateTime.Now; //время когда получили список
            System.Console.Out.WriteLine(end.Subtract(start)); // выводим разницу между началом и концом работы 

            start = DateTime.Now;
            /* using (AddressBookDB db = new AddressBookDB()) // установление подключения к бд
             {
                 List<GroupData> fromDb = (from g in db.Groups select g).ToList(); //список полученный из БД
             }*/ //Перенесли в метод GetAll в GroupData

            // db.Close();  используем using, чтобы бд закрывалась автоматически
            List<ContactDate> fromDb = ContactDate.GetAll();
            end = DateTime.Now;
            System.Console.Out.WriteLine(end.Subtract(start));
        }
    }
}

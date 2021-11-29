using System;
using System.Collections.Generic;
using System.IO;
using System.Xml;
using System.Xml.Serialization;
using Newtonsoft.Json;
using WebAddressbookTests; // пространство имен с другого проекта 

namespace addressbook_test_data_generators
{
    class Program
    {
        static void Main(string[] args)
        {
           int count = Convert.ToInt32(args[0]); // args[0] параметр в который передаем количество тестовых данных, которые будут генериться
           StreamWriter writer = new StreamWriter(args[1]); // объект ? Записывает строки в файл, args[1] - передаем название файла
           string format = args[2]; //передаем формат файла 

           List<GroupData> groups = new List<GroupData>();

            for(int i = 0; i < count; i++)
            {
                groups.Add(new GroupData(TestBase.GeneratorRandomString(10))
                { 
                    Header = TestBase.GeneratorRandomString(10),//генерация случайных строк
                    Footer = TestBase.GeneratorRandomString(10)
                });
            }
            if (format == "csv")
            {
                writeGroupsToCsvFile(groups, writer);
            }
            else if (format  == "xml")
            {
                writeGroupsToXmlFile(groups, writer);
            }
            else if (format == "json")
            {
                writeGroupsToJsonFile(groups, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }
          //  writer.Close();

            // Для контактов
            List<ContactDate> contacts = new List<ContactDate>();

            for (int i = 0; i < count; i++)
            {
                contacts.Add(new ContactDate(TestBase.GeneratorRandomString(10), TestBase.GeneratorRandomString(10))
                {
                    Address = TestBase.GeneratorRandomString(10)
                });
            }

              if (format == "xml")
            {
                writeContactsToXmlFile(contacts, writer);
            }
            else if (format == "json")
            {
                writeContactsToJsonFile(contacts, writer);
            }
            else
            {
                System.Console.Out.Write("Unrecognized format " + format);
            }
            writer.Close();
        }

        static void writeGroupsToCsvFile(List<GroupData> groups, StreamWriter writer)  //функция записи в файл csv, что записываем - список элементов GroupData , куда записываем - writer(открытый файл)
        {
            foreach (GroupData group in groups)
            {
                writer.WriteLine(String.Format("${0},${1},${2}", // Формат для указывания значений через запятую
                    group.Name, group.Header, group.Footer));
            }
        }
        static void writeGroupsToXmlFile(List<GroupData> groups, StreamWriter writer)
        {
            //чтобы работало , нужен пустой конструктор в GroupData
            new XmlSerializer(typeof(List<GroupData>)).Serialize(writer, groups); // создание сериализатора, typeof - тип данных который будет сериализовать(списки групп). writer - куда, groups  - что
        }

        static void writeGroupsToJsonFile(List<GroupData> groups, StreamWriter writer)
        {
           writer.Write(JsonConvert.SerializeObject(groups, Newtonsoft.Json.Formatting.Indented)); //Возвращается строка, которую записываем в файл. Применение формата 
        }

      
        // Для контактов

        static void writeContactsToXmlFile(List<ContactDate> contacts, StreamWriter writer)
        {
            new XmlSerializer(typeof(List<ContactDate>)).Serialize(writer, contacts);
        }

        static void writeContactsToJsonFile(List<ContactDate> contacts, StreamWriter writer)
        {
            writer.Write(JsonConvert.SerializeObject(contacts, Newtonsoft.Json.Formatting.Indented)); //Возвращается строка, которую записываем в файл. Применение формата 
        }
    }
}

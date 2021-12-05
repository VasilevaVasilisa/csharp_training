using LinqToDB;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    //Класс который соеденияет с БД
    public class AddressBookDB : LinqToDB.Data.DataConnection //наследуем от спец. класса, для того чтобы этот класс начал представлять собой бд
    {
        public AddressBookDB() : base("AddressBook") { } // конструктор AddressBookDB обращается к конструктору базового класса, в качестве параметра передаем AddressBook из app.config
        public ITable<GroupData> Groups { get { return GetTable<GroupData>(); } } //спец. метод который возвращает таблицу данных + свойство, геттер извлекает данные 
        public ITable<ContactDate> Contacts { get { return GetTable<ContactDate>(); } }
        public ITable<GroupContactRelation> GCR { get { return GetTable<GroupContactRelation>(); } }
    }
}

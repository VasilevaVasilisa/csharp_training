using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
    [Table(Name = "group_list")]  // привязка к таблице бд , group_list соответсвует таблице с группами
    public class GroupData : IEquatable<GroupData>, IComparable<GroupData>
    {
        public GroupData()
        {
            
        }

        public GroupData(string name)
        {
            Name = name;  //используем свойство
        }

        // Для каждого свойства указываем привязку к столбцу 
        [Column(Name = "group_name")]
        public string Name { get; set; } //поля создаются автоматически

        [Column(Name = "group_header")]
        public string Header { get; set; }

        [Column(Name = "group_footer")]
        public string Footer { get; set; }

        [Column(Name = "group_id"), PrimaryKey , Identity] //идентификатор
        public string Id { get; set; }
 
        public bool Equals(GroupData other)
        {
            if(Object.ReferenceEquals (other, null))
            {
                return false;
            }
            if(Object.ReferenceEquals(this , other))
            {
                return true;
            }
            return Name == other.Name;
        }
        public override int GetHashCode()
        {
            return Name.GetHashCode();
        }
        public override string ToString()
        {
            return "name = " + Name + "header = " + Header + "footer = " + Footer;
        }
        public int CompareTo(GroupData other)
        {
           if(Object.ReferenceEquals(other, null))
            {
                return 1;
            }
            return Name.CompareTo(other.Name);
        }

        public static List<GroupData> GetAll() //вспомогательный метод
        {
            using (AddressBookDB db = new AddressBookDB()) // установление подключения к бд
            {
               return (from g in db.Groups select g).ToList(); //список полученный из БД
            }
        }

    }
}

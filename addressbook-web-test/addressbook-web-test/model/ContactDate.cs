using LinqToDB.Mapping;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests 
{
  //  [Table(Name = "addressbook")]  // привязка к таблице бд , group_list соответсвует таблице с контактами
    public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {

        private string group = null;
        private string allPhones;
        private string allEmails;

        public ContactDate()
        {
            
        }
        public ContactDate(string firstname, string lastname) 
        {
           Firstname = firstname;
           Lastname = lastname;
        }

        // Для каждого свойства указываем привязку к столбцу 
      //  [Column(Name = "firstname")]
        public string Firstname { get; set; }

      //  [Column(Name = "lastname")]
        public string Lastname { get; set; }

    //    [Column(Name = "middlename")]
        public string Middlename { get; set; }

      //  [Column(Name = "nickname")]
        public string Nickname { get; set; }

        /*public string Photo  { get; set; }*/
       
     //   [Column(Name = "title")]
        public string Title { get; set; }

     //   [Column(Name = "company")]
        public string Company { get; set; }

    //    [Column(Name = "address")]
        public string Address { get; set; }

    //    [Column(Name = "home")]
        public string HomeTel { get; set; }

     //   [Column(Name = "mobile")]
        public string Mobile { get; set; }

    //    [Column(Name = "work")]
        public string WorkTel { get; set; }

    //    [Column(Name = "fax")]
        public string Fax { get; set; }

    //    [Column(Name = "email")]
        public string Email { get; set; }

    //    [Column(Name = "email2")]
        public string Email2 { get; set; }

    //    [Column(Name = "email3")]
        public string Email3 { get; set; }

    //    [Column(Name = "homepage")]
        public string Homepage { get; set; }

     //   [Column(Name = "bday")]
        public string BirthDay { get; set; }

    //    [Column(Name = "bmonth")]
        public string BirthMonth { get; set; }

    //    [Column(Name = "byear")]
        public string BirthYear { get; set; }

    //    [Column(Name = "aday")]
        public string AnniversaryDay { get; set; }

    //    [Column(Name = "amonth")]
        public string AnniversaryMonth { get; set; }

    //    [Column(Name = "ayear")]
        public string AnniversaryYear { get; set; }

        public string AllPhones 
        {
            get
            {
                if(allPhones != null)
                {
                    return allPhones;
                }
                else
                {
                    return (CleanUp(HomeTel) + CleanUp(Mobile) + CleanUp(WorkTel)).Trim();
                }
            }
            set
            {
                allPhones = value;
            }
        }

        public string AllEmails
        {
            get
            {
                if (allEmails != null)
                {
                    return allEmails;
                }
                else
                {
                    return (CleanUp(Email) + CleanUp(Email2) + CleanUp(Email3)).Trim();
                } 
            }
            set
            {
                allEmails = value;
            }
        }

     //   [Column(Name = "id") , PrimaryKey, Identity]
        public string Id { get; set; }

       
        public string Group
        {
            get
            {
                return group;
            }
            set
            {
                group = value;
            }
        }

     //   [Column(Name = "address2")]
        public string Address2 { get; set; }

    //    [Column(Name = "phone2")]
        public string Phone2 { get; set; }

    //    [Column(Name = "notes")]
        public string Notes { get; set; }

        public bool Equals(ContactDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return false;
            }
            if (Object.ReferenceEquals(this, other))
            {
                return true;
            }
            return Firstname == other.Firstname && Lastname == other.Lastname;

        }
        public override int GetHashCode()
        {
           
            return  Lastname.GetHashCode() + Firstname.GetHashCode(); 
        }
        public override string ToString()
        {
            string[] arrayContactInfo = new string[] { Firstname , Lastname };

            return string.Join(" ", arrayContactInfo);
        }
        public int CompareTo(ContactDate other)
        {
            if (Object.ReferenceEquals(other, null))
            {
                return 1;
            }

            int compareContact = Lastname.CompareTo(other.Lastname);

            if(compareContact != 0)
            {
                return compareContact;
            }

            return Firstname.CompareTo(other.Firstname); 
        }

        private string CleanUp(string parameters)
        {
            if (parameters == null || parameters == "")
            {
                return "";
            }
           return parameters.Replace(" ", "").Replace("-", "").Replace("(", "").Replace(")", "") + "\r\n"; //замена символов 
         //  return Regex.Replace(phone, "[ -()]","") + "\r\n";
        }

     /*   public static List<ContactDate> GetAll() //вспомогательный метод
        {
            using (AddressBookDB db = new AddressBookDB()) // установление подключения к бд
            {
                return (from c in db.Contacts select c).ToList(); //список полученный из БД
            }
        }*/
    }
}

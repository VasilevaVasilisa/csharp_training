using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace WebAddressbookTests
{
   public class ContactDate : IEquatable<ContactDate>, IComparable<ContactDate>
    {

        private string group = null;
        private string allPhones;
        private string allEmails;

        public ContactDate(string firstname, string lastname) 
        {
           Firstname = firstname;
           Lastname = lastname;
        }

        public string Firstname { get; set; }
       

        public string Lastname { get; set; }
       
        public string Middlename { get; set; }
        
        public string Nickname { get; set; }

        /*public string Photo  { get; set; }*/
              
        public string Title { get; set; }
   
        public string Company { get; set; }
       
        public string Address { get; set; }
       
        public string HomeTel { get; set; }
        
        public string Mobile { get; set; }
       
        public string WorkTel { get; set; }
      
        public string Fax { get; set; }
       
        public string Email { get; set; }
       
        public string Email2 { get; set; }
     
        public string Email3 { get; set; }
        
        public string Homepage { get; set; }

        public string BirthDay { get; set; }
        public string BirthMonth { get; set; }
      
        public string BirthYear { get; set; }
        
        public string AnniversaryDay { get; set; }
        
        public string AnniversaryMonth { get; set; }
       
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
        public string Address2 { get; set; }
       
        public string Phone2 { get; set; }
        
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
        
    }
}

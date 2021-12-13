using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public class ContactInformationTests : AuthTestBase
    {
        [Test]

        public void ContactInformationTestFromTableAndEditForm()
        {
           ContactDate fromTable = app.Contacts.GetContactInformationFromTable(0); //возвращает объект из таблицы
           ContactDate fromForm = app.Contacts.GetContactInformationFromEditForm(0); //возвращает объкт из формы редактирования

           // System.Console.Out.Write(fromTable.AllEmails);

            //Проверка соответствия таблици с формой редактирования
            Assert.AreEqual(fromTable, fromForm); // проверяет  имя и фамилию
            Assert.AreEqual(fromTable.Address, fromForm.Address);
            Assert.AreEqual(fromTable.AllPhones, fromForm.AllPhones);
            Assert.AreEqual(fromTable.AllEmails, fromForm.AllEmails);

        }
        [Test]

        public void ContactInformationTestFromTableAndDetailsPage()
        {
            ContactDate fromTable = app.Contacts.GetContactInformationFromTable(0);
            string infoDetails = app.Contacts.GetContactInformationFromDetailsPage(0);

            infoDetails =  infoDetails.Replace(" ", "").Replace("H:", "").Replace("M:", "").Replace("W:", "").
                        Replace("-", "").Replace("(", "").Replace(")", "").Trim(); 

             string infoTable = (fromTable.Firstname + fromTable.Lastname).Replace(" ", "") + "\r\n"
                 + fromTable.Address + "\r\n" + "\r\n" + fromTable.AllPhones + "\r\n" + "\r\n" + fromTable.AllEmails;
            infoTable.Trim();

            Assert.AreEqual(infoTable, infoDetails); //Проверка соответствия  таблицы со страницей детальной информации

        }

        [Test]

        public void ContactInformationTestFromDetailsPageAndEditForm()
        {
            string infoDetails = app.Contacts.GetContactInformationFromDetailsPage(0);
            ContactDate fromForm = app.Contacts.GetContactInformationFromEditForm(0);      
            string firstname;
            string lastname;
            string address;
            string homeTel;
            string mobile;
            string workTel;
            string email;
            string email2;
            string email3;

            if (fromForm.Firstname == null || fromForm.Firstname == "") 
            {
                firstname = "";
            }
            else
            {
                firstname = fromForm.Firstname;
            }

            if (fromForm.Lastname == null || fromForm.Lastname == "")
            {
                lastname = "";
            }
            else
            {
                lastname = " "+ fromForm.Lastname;
            }

            if (fromForm.Address == null || fromForm.Address == "")
            {
                address = "" ;
            }
            else
            {
                address = "\r\n" + fromForm.Address;
            }

             if (fromForm.HomeTel == null || fromForm.HomeTel == "")
             {
                 homeTel = "";
             }
             else
             {
              
                homeTel = "H: " + fromForm.HomeTel + "\r\n";
             }

             if (fromForm.Mobile == null || fromForm.Mobile == "")
             {
                 mobile = "";
             }
             else
             {
                   mobile =  "M: " + fromForm.Mobile + "\r\n";
             }
             if (fromForm.WorkTel == null || fromForm.WorkTel == "")
             {
                 workTel = "";
             }
             else
             {
                 workTel = "W: " + fromForm.WorkTel + "\r\n";
             }

             if (fromForm.Email == null || fromForm.Email == "" )
                {

                    email = "";

                }
             else
                {
                    email = fromForm.Email + "\r\n";

                }
             if (fromForm.Email2 == null || fromForm.Email2 == "")
                {
                    email2 = "";        
                }
             else
                {
                     email2 = fromForm.Email2 + "\r\n";

                }
             if (fromForm.Email3 == null || fromForm.Email3 == "")
                {
                    email3 = "";
                }
             else
                {
                     email3 = fromForm.Email3; 
                }

            string infoForm = (firstname + lastname + "\r\n" + address + "\r\n" + homeTel + mobile + workTel + "\r\n" + email + email2 + email3).Trim();
          
            /* string infoForm =fromForm.Firstname +" "+ fromForm.Lastname + "\r\n"
             + fromForm.Address + "\r\n" + "\r\n" + "H: "+ fromForm.HomeTel + "\r\n" + "M: " + fromForm.Mobile + "\r\n"
            + "W: " + fromForm.WorkTel + "\r\n" + "\r\n" + fromForm.Email + "\r\n" + fromForm.Email2 + "\r\n" + fromForm.Email3; */

            Assert.AreEqual(infoDetails, infoForm); // проверка соответсвия страницы с детальной информацией с формой редактирования 
        }
    }
}

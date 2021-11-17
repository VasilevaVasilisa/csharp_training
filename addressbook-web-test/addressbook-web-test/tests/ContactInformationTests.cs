﻿using System;
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

            string infoForm = ((fromForm.Firstname + fromForm.Lastname).Replace(" ", "") + "\r\n"
                + fromForm.Address + "\r\n" + "\r\n" + fromForm.AllPhones + "\r\n" + "\r\n" + fromForm.AllEmails).Trim();

            Assert.AreEqual(infoDetails, infoForm); // проверка соответсвия страницы с детальной информацией с формой редактирования 
        }
    }
}

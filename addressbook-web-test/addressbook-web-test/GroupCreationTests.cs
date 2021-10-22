using System;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading;
using NUnit.Framework;
using OpenQA.Selenium;
using OpenQA.Selenium.Firefox;
using OpenQA.Selenium.Support.UI;

namespace WebAddressbookTests
{
    [TestFixture]
    public class GroupCreationTests : TestBase
    {
       

        [Test]
        public void GroupCreationTest()
        {
            OpenHomePage();
            Login(new AccountDate("admin", "secret"));
            GoToGroupsPage();
            InitNewGroupCreation();

            GroupData group = new GroupData("group2");
            group.Header = "ddd";
            group.Footer = "sss";

            FillGroupForm(group);
            SubmitGroupCreation();
            ReturnToGroupPage();
            Logout();
        }

                
    }

}

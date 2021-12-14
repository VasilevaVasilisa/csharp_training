using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
   
   [TestFixture]
   public class AccountCreationTests : TestBase
    {
        [SetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("");
            app.Ftp.Upload("", null);
         
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountDate account = new AccountDate()
            {
                Name = "testUser",
                Password = "password",
                Email = "testUser@localhost.localdomain"
            };

            app.Registration.Register(account);
        }
        [TearDown]
        public void restoreConfig()
        {
          app.Ftp.RestoreBackupFile("");
        }
    }
}

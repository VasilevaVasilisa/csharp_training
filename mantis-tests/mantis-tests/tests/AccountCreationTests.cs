using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;


namespace mantis_tests
{
   
   [TestFixture]
   public class AccountCreationTests : TestBase
    {
        [OneTimeSetUp]
        public void setUpConfig()
        {
            app.Ftp.BackupFile("/config_inc.php");
            using (Stream localFile = File.Open("config_inc.php", FileMode.Open))
            {
                app.Ftp.Upload("/config_inc.php", localFile);
            }
        }
        [Test]
        public void TestAccountRegistration()
        {
            AccountDate account = new AccountDate()
            {
                Name = "testUser1",
                Password = "password",
                Email = "testUser1@localhost.localdomain"
            };

            app.James.Delete(account);
            app.James.Add(account);

            app.Registration.Register(account);
        }
        [OneTimeTearDown]
        public void restoreConfig()
        {
          app.Ftp.RestoreBackupFile("/config_inc.php");
        }
    }
}

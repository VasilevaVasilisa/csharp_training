using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mantis_tests_project
{
    [TestFixture]
   public class LoginTests : AuthTestBase
    {
        [Test]

        public void LoginWithValidCredentials()
        {
            //prepare
            AccountDate account = new AccountDate()
            {
                Username = "testUser1",
                Password = "password"
            };

            //action
            // app.Auth.Logout();
            // app.Auth.Login(account);
            app.Auth.Login(account);

            //verification
            //Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

    }
}

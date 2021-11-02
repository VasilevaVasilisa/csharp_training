using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using NUnit.Framework;

namespace WebAddressbookTests
{
    [TestFixture]
   public class LoginTests : TestBase
    {
        [Test]

    public void LoginWithValidCredentials()
        {
            //prepare
            AccountDate account = new AccountDate("admin", "secret");

            //action
            app.Auth.Logout();
            app.Auth.Login(account);

            //verification
            Assert.IsTrue(app.Auth.IsLoggedIn(account));
        }

        [Test]

        public void LoginWithInvalidCredentials()
        {
            //prepare
            AccountDate account = new AccountDate("admin", "56546546");

            //action
            app.Auth.Logout();
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));

        }

        [Test]

        public void LoginWithEmptyCredentials()
        {
            //prepare
            AccountDate account = new AccountDate("", "");

            //action
            app.Auth.Logout();
            app.Auth.Login(account);

            //verification
            Assert.IsFalse(app.Auth.IsLoggedIn(account));
        }
    }
}

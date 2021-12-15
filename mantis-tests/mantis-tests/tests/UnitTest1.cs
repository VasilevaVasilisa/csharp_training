using NUnit.Framework;
using System;


namespace mantis_tests
{
    [TestFixture]
    public class UnitTest1 : TestBase
    {
        [Test]
        public void TestMethod1()
        {
            AccountDate account = new AccountDate()
            {
                Name = "xxx", Password = "yyy"
            };

            Assert.IsFalse(app.James.Verify(account));
            app.James.Add(account);
            Assert.IsTrue(app.James.Verify(account));
            app.James.Delete(account);
            Assert.IsFalse(app.James.Verify(account));

        }
    }
}

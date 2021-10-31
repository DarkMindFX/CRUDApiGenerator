using PPT.PhotoPrint.API.Helpers;
using System;
using System.Collections.Generic;
using System.Text;
using Xunit;

namespace Test.E2E.Helpers
{
    public class TestPasswordHelper
    {
        [Fact]
        public void GenerateSalt_Success()
        {
            string salt = PasswordHelper.GenerateSalt(10);

            Assert.NotNull(salt);
            Assert.True(!string.IsNullOrEmpty(salt));
            Assert.Equal(10, salt.Length);
        }

        [Fact]
        public void GenerateSalt_InvalidLength()
        {
            try
            {
                string salt = PasswordHelper.GenerateSalt(0);
                Assert.False(true, $"ArgumentException was expected but salt is generated instead - {salt}");
            }
            catch (ArgumentException)
            {
                Assert.True(true, "ArgumentException thrown as expected");
            }
        }

        [Fact]
        public void GeneratePasswordHash_Success()
        {
            string password = "TestPassword-202107061104";
            string salt = "SALT12345";

            string pwdHash = PasswordHelper.GenerateHash(password, salt);

            Assert.NotNull(pwdHash);
            Assert.True(!string.IsNullOrEmpty(pwdHash));
        }

        [Fact]
        public void GeneratePasswordHashes_Multiple_Success()
        {
            IList<Tuple<string, string>> pwds = new List<Tuple<string, string>>();
            pwds.Add(new Tuple<string, string>("System2021!", "123SALT123BCD"));
            pwds.Add(new Tuple<string, string>("Admin2021!", "567SALT567WQA"));
            pwds.Add(new Tuple<string, string>("LindonJ2021!", "567SALT567WQA"));
            pwds.Add(new Tuple<string, string>("JohnK2021!", "ETERTERTR"));
            pwds.Add(new Tuple<string, string>("FranklinR2021!", "5656GHRED"));
            pwds.Add(new Tuple<string, string>("ManagerBill2021!", "567SALT567WQA"));
            pwds.Add(new Tuple<string, string>("ManagerTed2021!", "ETERTERTR"));
            pwds.Add(new Tuple<string, string>("ManagerSam2021!", "5656GHRED"));
            pwds.Add(new Tuple<string, string>("PrinterBill2021!", "567SALT567WQA"));
            pwds.Add(new Tuple<string, string>("PrinterTed2021!", "ETERTERTR"));
            pwds.Add(new Tuple<string, string>("PrinterSam2021!", "5656GHRED123"));

            foreach (var v in pwds)
            {
                string password = v.Item1;
                string salt = v.Item2;

                string pwdHash = PasswordHelper.GenerateHash(password, salt);

                Assert.NotNull(pwdHash);
                Assert.True(!string.IsNullOrEmpty(pwdHash));
            }
        }

        [Fact]
        public void GeneratePasswordHash_EmptySalt()
        {
            try
            {
                string password = "TestPassword-202107061104";
                string salt = string.Empty;

                string pwdHash = PasswordHelper.GenerateHash(password, salt);

                Assert.False(true, $"ArgumentException was expected but pwdHash is generated instead - {pwdHash}");
            }
            catch (ArgumentException)
            {
                Assert.True(true, "ArgumentException thrown as expected");
            }
        }

        [Fact]
        public void GeneratePasswordHash_EmptyPassword()
        {
            try
            {
                string password = string.Empty;
                string salt = "SALT12345";

                string pwdHash = PasswordHelper.GenerateHash(password, salt);

                Assert.False(true, $"ArgumentException was expected but pwdHash is generated instead - {pwdHash}");
            }
            catch (ArgumentException)
            {
                Assert.True(true, "ArgumentException thrown as expected");
            }
        }
    }
}

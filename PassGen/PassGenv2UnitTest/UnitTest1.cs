using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using PassGen;
using System.Security.Cryptography;

namespace PassGenv2UnitTest
{
    [TestClass]
    public class UnitTest1
    {
        private bool ContainsAtLeastOne(string text, string characters)
        {
            foreach (char c in characters)
            {
                if (text.Contains(c))
                {
                    return true;
                }
            }
            return false;
        }

        [TestMethod]
        public void TestGeneratePassword()
        {
            // Arrange
            PassGen_Main passGenMain = new PassGen_Main();
            int length = 12;
            bool includeUppercase = true;
            bool includeLowercase = true;
            bool includeNumbers = true;
            bool includeSpecialChars = true;

            // Act
            string password = passGenMain.GeneratePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

            // Assert
            Assert.IsNotNull(password);
            Assert.AreEqual(length, password.Length);

        }

        [TestMethod]
        public void TestUppercaseAndLowercaseCharacters()
        {
            // Arrange
            int expectedLength = 10;
            bool includeUppercase = true;
            bool includeLowercase = true;
            bool includeNumbers = false;
            bool includeSpecialChars = false;

            // Act
            PassGen_Main passGenMain = new PassGen_Main();
            string generatedPassword = passGenMain.GeneratePassword(expectedLength, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

            // Assert
            Assert.AreEqual(expectedLength, generatedPassword.Length, "Generated password length does not match expected length");
            Assert.IsTrue(ContainsAtLeastOne(generatedPassword, "ABCDEFGHIJKLMNOPQRSTUVWXYZ"), "Generated password does not contain at least one uppercase character");
            Assert.IsTrue(ContainsAtLeastOne(generatedPassword, "abcdefghijklmnopqrstuvwxyz"), "Generated password does not contain at least one lowercase character");
        }

        [TestMethod]
        public void TestNumericCharacters()
        {
            // Arrange
            int expectedLength = 10;
            bool includeUppercase = false;
            bool includeLowercase = false;
            bool includeNumbers = true;
            bool includeSpecialChars = false;

            // Act
            PassGen_Main passGenMain = new PassGen_Main();
            string generatedPassword = passGenMain.GeneratePassword(expectedLength, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

            // Assert
            Assert.AreEqual(expectedLength, generatedPassword.Length, "Generated password length does not match expected length");
            Assert.IsTrue(ContainsAtLeastOne(generatedPassword, "1234567890"), "Generated password does not contain at least one numeric character");
        }

        [TestMethod]
        public void TestSpecialCharacters()
        {
            // Arrange
            int expectedLength = 10;
            bool includeUppercase = false;
            bool includeLowercase = false;
            bool includeNumbers = false;
            bool includeSpecialChars = true;

            // Act
            PassGen_Main passGenMain = new PassGen_Main();
            string generatedPassword = passGenMain.GeneratePassword(expectedLength, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

            // Assert
            Assert.AreEqual(expectedLength, generatedPassword.Length, "Generated password length does not match expected length");
            Assert.IsTrue(ContainsAtLeastOne(generatedPassword, "!@#$%^&*()_+-=[]{}|;:,.<>?"), "Generated password does not contain at least one special character");
        }

        [TestMethod]
        public void TestPasswordGenerationTime()
        {
            // Define the parameters for testing
            int[] lengths = { 8, 12, 20 }; // Varying lengths of passwords to test
            bool includeLowercase = true;
            bool includeUppercase = true;
            bool includeNumbers = true;
            bool includeSpecialChars = true;

            // Test password generation time for each length
            foreach (int length in lengths)
            {
                // Start the stopwatch to measure time
                Stopwatch stopwatch = Stopwatch.StartNew();

                // Generate the password
                PassGen_Main passGenMain = new PassGen_Main();
                string password = passGenMain.GeneratePassword(length, includeLowercase, includeUppercase, includeNumbers, includeSpecialChars);

                // Stop the stopwatch
                stopwatch.Stop();

                // Calculate and output the elapsed time
                Console.WriteLine($"Password length: {length}, Time taken: {stopwatch.ElapsedMilliseconds} milliseconds");
            }
        }
    }
    [TestClass]
    public class UnitTest2
    {
        [TestMethod]
        public void Recrypt_Test()
            {
            //Arrange
            int length = 8;
            bool includeLowercase = true;
            bool includeUppercase = true;
            bool includeNumbers = true;
            bool includeSpecialChars = true;
            byte[] key = new byte[16];
            byte[] iv = new byte[16];
           

            //Act
            PassGen_Main passGenMain = new PassGen_Main();
            string password = passGenMain.GeneratePassword(length, includeLowercase, includeUppercase, includeNumbers, includeSpecialChars);
           
            //encrypt the password using Recrypt Class

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);

            }

            byte[] encryptedPassword = Recrypt.Encrypt(password, key, iv);
            string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);

            Console.WriteLine("The original password is " + password);
            Console.WriteLine(encryptedPasswordString);

            //Assert
            //Password is decipherable

            string simpleText = Recrypt.Decrypt(encryptedPassword, key, iv);
            Console.WriteLine(simpleText);

            if (simpleText == password)
            {
                Console.WriteLine("The passwords match");
            }
            else
            {
                Console.WriteLine("Test Failed");
            }

        }
    }
}
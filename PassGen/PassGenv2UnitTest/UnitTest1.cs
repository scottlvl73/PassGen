using System.Windows.Forms;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics;
using PassGen;
using System.Security.Cryptography;
using System.Drawing;
using System.Data.SQLite;
using Microsoft.VisualStudio.TestPlatform.CommunicationUtilities.DataCollection;
using System.Text;
using System.CodeDom.Compiler;
using System.Data.Entity.Core.Common.CommandTrees.ExpressionBuilder;
using System.Dynamic;
using System.Data.Entity.Core.Metadata.Edm;
using System.Runtime.CompilerServices;

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
            PassGen_Main passGenMain = new();
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
        [TestMethod]
        public void StrengthMeter_Test()
        {
            //Arrange
            int length = 3;
            bool includeLowercase = false;
            bool includeUppercase = false;
            bool includeNumbers = false;
            bool includeSpecialChars = false;
            int strength;
            PassGen_Main passMain = new();
            int averageStrength = 0;

            //Act
            for (int j = length; length < 15; length++)
            {
                for (int i = 0; i < 15; i++)
                {
                    //Only lowercase strength

                    string password = passMain.GeneratePassword(length, true, includeUppercase, includeNumbers, includeSpecialChars);
                    strength = passMain.CalculatePasswordStrength(password, true, includeUppercase, includeNumbers, includeSpecialChars);
                    Console.WriteLine(strength);
                    averageStrength += strength;

                }

                for (int i = 0; i < 15; i++)
                {
                    //only uppercase strength

                    string password = passMain.GeneratePassword(length, includeLowercase, true, includeNumbers, includeSpecialChars);
                    strength = passMain.CalculatePasswordStrength(password, includeLowercase, true, includeNumbers, includeSpecialChars);
                    Console.WriteLine(strength);
                    averageStrength += strength;
                }

                for (int i = 0; i < 15; i++)
                {
                    //only special characters strength

                    string password = passMain.GeneratePassword(length, includeLowercase, includeUppercase, includeNumbers, true);
                    strength = passMain.CalculatePasswordStrength(password, includeLowercase, includeUppercase, includeNumbers, true);
                    Console.WriteLine(strength);
                    averageStrength += strength;
                }

            }
            Console.WriteLine("The average strength of the test is " + (averageStrength / 540));
        }


    }
    [TestClass]
    public class Sprint3Tests
    {
        [TestMethod]
        public void TestDBCreate()
        {
            //Arrange
            string connectionstring = "Data Source=myDatabaseTest.db;Version=3;";

            //Act

            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
            {
                connection.Open();



                string checkIfExists = "CREATE TABLE IF NOT EXISTS Passwords (ID INTEGER PRIMARY KEY, EncryptedPassword TEXT, AESKey TEXT, IV TEXT)";
                using (SQLiteCommand command = new SQLiteCommand(checkIfExists, connection))
                {

                    var temp = command.ExecuteScalar();

                    //Assert
                    Assert.IsNull(temp);
                    Debug.WriteLine(temp);
                }


            }


        }

        [TestMethod]
        public void btnSave_TestYes()
        {
            //Arrange
           
            string sender = "";
            System.EventArgs e = new();
            PassGen_Main passMain = new();
            byte[] key = new byte[16];
            byte[] iv = new byte[16];
            string passWord = passMain.GeneratePassword(15, true, true, true, true);

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);

            }

            //Act
            passMain.txtPassword.Text = passWord;
            passMain.comboBoxAccountType.SelectedItem = passMain.comboBoxAccountType.Items[0];
          
            passMain.btnSave_Click(sender, e);


            //Assert
            Assert.IsNotNull(passWord);
        }

        [TestMethod]
        public void btnSave_TestNo()
        {
            //Arrange

            string sender = "";
            System.EventArgs e = new();
            PassGen_Main passMain = new();
            byte[] key = new byte[16];
            byte[] iv = new byte[16];
            string passWord = passMain.GeneratePassword(15, true, true, true, true);

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);

            }

            //Act
            passMain.btnSave_Click(sender, e);


            //Assert
            Assert.IsNotNull(passWord);
        }


        [TestMethod]
        public void UpdateStrength_Test()
        {
            //Arrange
            PassGen_Main passMain = new();
            int strengthTest = 0;

            //Act
            while (strengthTest < 100)
            {
                strengthTest++;
                passMain.UpdatePasswordStrengthLabel(strengthTest);
                //Assert
                Debug.WriteLine("Strength is " + strengthTest);
            }

        }


        //                  Deprecated Test Method
        //[TestMethod]
        //public void UserSettings_Test()
        //{

        //    //Arrange
        //    PassGen_Main passMain = new();
        //    User_Settings userSettings = new();
        //    string sender = "";
        //    System.EventArgs e = new();
        //    userSettings.ExcludeAmbiguousChars = true;
        //    userSettings.IncludeSpecialChars = true;
        //    userSettings.IncludeNumbers = true;
        //    userSettings.IncludeLowercase = true;
        //    userSettings.IncludeUppercase = true;
        //    userSettings.AvoidRepeatingChars = true;
        //    userSettings.PasswordLength = 15;

        //    //Act
        //    userSettings.btnApply_Click(sender, e);

        //    string password = passMain.GeneratePassword(userSettings.PasswordLength, userSettings.IncludeUppercase, userSettings.IncludeLowercase, userSettings.IncludeNumbers, userSettings.IncludeSpecialChars);


        //    //Assert
        //    Assert.IsNotNull(password);
        //    Debug.WriteLine(password);

        //}
        //[TestMethod]
        //public void btnGenerate_Test()
        //{
        //    //Arrange
        //    string sender = "";
        //    System.EventArgs e = new();
        //    PassGen_Main passMain = new();
        //    User_Settings user_Settings = new User_Settings();
        //    user_Settings.ExcludeAmbiguousChars = true;
        //    user_Settings.IncludeSpecialChars = true;
        //    user_Settings.IncludeNumbers = true;
        //    user_Settings.IncludeLowercase = true;
        //    user_Settings.IncludeUppercase = true;
        //    user_Settings.AvoidRepeatingChars = true;
        //    user_Settings.PasswordLength = 15;
        //    //Act
        //   passMain.btnGenerate_Click(sender, e);
            
           
            
        //}

        [TestMethod]
        public void btnGenerate_TestNoCharactersSelected()
        {
            // Arrange
            PassGen_Main passGenMain = new PassGen_Main();
            int length = 12;
            bool includeUppercase = false;
            bool includeLowercase = false;
            bool includeNumbers = false;
            bool includeSpecialChars = false;

            // Act
            string password = passGenMain.GeneratePassword(length, includeUppercase, includeLowercase, includeNumbers, includeSpecialChars);

            // Assert
            Assert.IsNotNull(password);
           
        }
        
        [TestMethod]
        public void btnGenerate_TestCharPoolTooSmall()
        {
            // Arrange
            PassGen_Main passGenMain = new PassGen_Main();
            int length = 15;
            

            // Act
            string password = passGenMain.GeneratePassword(length, false, false, true, false);

            // Assert
            Assert.IsNotNull(password);
            Assert.AreEqual(length, password.Length);
            Debug.WriteLine(password);


        }
            



        

        [TestMethod]
        public void ACreateTestDB()
        {
            //Create Test Database
            string connectionString = "Data Source=myDatabase.db;Version=3;";
            using (SQLiteConnection connection = new(connectionString))
            {
                connection.Open();
                string createTableQuery = "CREATE TABLE IF NOT EXISTS Passwords (ID INTEGER PRIMARY KEY, EncryptedPassword TEXT, AESKey TEXT, IV TEXT, Strength INTEGER, AccountType TEXT)";
                using (SQLiteCommand command = new(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();

                    Debug.WriteLine("Table Added");
                }

            }
                        
        }
        [TestMethod]
        public void DropTestDB()
        {
            //Drop Test DB
            string connectionString = "Data Source=myDatabaseTest.db;Version=3;";
            using (SQLiteConnection connection = new(connectionString))
            {
                connection.Open();
                string dropTable = "DROP TABLE Passwords";
                using (SQLiteCommand drop = new(dropTable, connection))
                {
                    drop.ExecuteNonQuery();
                    Debug.WriteLine("Table Dropped");
                }
            }
        }
        [TestMethod]
        public void AddDummyDataToDB()
        {
            //Add data to test database
            PassGen_Main passmain = new();
            string passWord = passmain.GeneratePassword(15, true, true, true, true);
            byte[] key = new byte[16];
            byte[] iv = new byte[16];
            int strength = 75;
            string selectedAccountType ="Email";

            using (RandomNumberGenerator rng = RandomNumberGenerator.Create())
            {
                rng.GetBytes(key);
                rng.GetBytes(iv);

            }

           byte[] encryptedPassword = Recrypt.Encrypt(passWord, key, iv);
            string encryptedPasswordString = Convert.ToBase64String(encryptedPassword);
            
            string connectionString = "Data Source=myDatabase.db;Version=3;";
            using (SQLiteConnection connection = new(connectionString))
            {
                connection.Open();

                string createTableQuery = "CREATE TABLE IF NOT EXISTS Passwords (ID INTEGER PRIMARY KEY, EncryptedPassword TEXT, AESKey TEXT, IV TEXT, Strength INTEGER, AccountType TEXT)";
                using (SQLiteCommand command = new(createTableQuery, connection))
                {
                    command.ExecuteNonQuery();
                }

                string insertInto = "INSERT INTO Passwords (EncryptedPassword, AESKey, IV, Strength, AccountType) VALUES (@encryptedPassword, @aesKey, @iv, @strength, @accountType)";
                using (SQLiteCommand command = new(insertInto, connection))
                {
                    command.Parameters.AddWithValue("@encryptedPassword ", encryptedPasswordString);
                    command.Parameters.AddWithValue("@aesKey", Convert.ToBase64String(key));
                    command.Parameters.AddWithValue("@iv", Convert.ToBase64String(iv));
                    command.Parameters.AddWithValue("@strength", strength);
                    command.Parameters.AddWithValue("@accountType", selectedAccountType);



                    Debug.WriteLine("Data Inserted " + encryptedPasswordString + " " + Convert.ToBase64String(key) + " " +Convert.ToBase64String(iv) + " " + strength + " " + selectedAccountType);
                }

            }




        }
        
        [TestMethod]
        public void btnViewPasswordsTest()
        {
            //arrange
            PassGen_Main passGen_Main = new PassGen_Main();
            string sender = "";
            System.EventArgs e = new();




            //Act
            passGen_Main.btnViewPasswords_Click(sender, e);
            //Assert that it worked

        }

        [TestMethod]
        public void PasswordHistoryCopyBtn_onClickTest()
        {

            //Arrange
            PassGen_Main passGen_main = new();
            PasswordHistory passwordHistory = new();
            string sender = "";
            System.EventArgs e = new();
            string passWord = "P@ssW0rd";

            //Act
            passGen_main.btnViewPasswords_Click(sender, e);
            passwordHistory.PopulatePasswordHistory();
            passwordHistory.savedPasswordsListBox.SelectedItem = passWord;
            passwordHistory.passwordHistoryCopyBtn_Click(sender, e);




            //Assert
            Debug.WriteLine(passWord);
            
            Assert.IsNotNull(passwordHistory.savedPasswordsListBox);


        }
        //[DataRow]
        //[DynamicData]
        [TestMethod]
        public void PasswordHistoryDeleteBtn_ClickYes()
        {
            string sender = "";
            System.EventArgs e = new();
            PassGen_Main passGen_main = new();
            PasswordHistory passwordHistory = new();
          
            
            
            passwordHistory.PopulatePasswordHistory();
            passGen_main.btnViewPasswords_Click(sender, e);
            passwordHistory.savedPasswordsListBox.SelectedItem = passwordHistory.savedPasswordsListBox.Items[0];

            passwordHistory.passwordHistoryDeleteBtn_Click(sender, e);


        }
        [TestMethod]
        public void PasswordHistoryDeleteBtn_ClickNo()
        {
            string sender = "";
            System.EventArgs e = new();
            PassGen_Main passGen_main = new();
            PasswordHistory passwordHistory = new();



            passwordHistory.PopulatePasswordHistory();
            passGen_main.btnViewPasswords_Click(sender, e);
            passwordHistory.savedPasswordsListBox.SelectedItem = passwordHistory.savedPasswordsListBox.Items[0];

            passwordHistory.passwordHistoryDeleteBtn_Click(sender, e);


        }
        [TestMethod]
        public void PasswordHistoryDeleteBtn_ClickNull()
        {
            string sender = "";
            System.EventArgs e = new();
            PassGen_Main passGen_main = new();
            PasswordHistory passwordHistory = new();



            passwordHistory.PopulatePasswordHistory();
            passGen_main.btnViewPasswords_Click(sender, e);
            passwordHistory.savedPasswordsListBox.SelectedItem = null;

            passwordHistory.passwordHistoryDeleteBtn_Click(sender, e);


        }

        [TestMethod]
        public void btnDetails_ClickTest()
        {
            PassGen_Main passMain = new();
            PasswordHistory passHis = new();
            string sender = "";
            EventArgs e = new();
            
          
            passHis.PopulatePasswordHistory();
            
            passHis.savedPasswordsListBox.SelectedItem = passHis.savedPasswordsListBox.Items[0];
            passHis.btnDetails_Click(sender, e);

        }
        [TestMethod]
        public void btnDetails_ClickTest2()
        {
            PassGen_Main passMain = new();
            PasswordHistory passHis = new();
            string sender = "";
            EventArgs e = new();


            passHis.PopulatePasswordHistory();
            
            passHis.savedPasswordsListBox.SelectedItem = null;
            passHis.btnDetails_Click(sender, e);

        }

    }
}

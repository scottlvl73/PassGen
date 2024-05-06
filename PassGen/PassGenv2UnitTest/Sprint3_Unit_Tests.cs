using System;
using System.Collections.Generic;
using System.Data.SQLite;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

//namespace PassGenv2UnitTest
//{
//    [TestClass]
//    internal class Sprint3_Unit_Tests
//    {
//        [TestMethod]
//        public void TestDB()
//        {
//            //Arrange
//            string connectionstring = "Data Source=myDatabase.db;Version=3;";

//            //Act
          
//            using (SQLiteConnection connection = new SQLiteConnection(connectionstring))
//            {
//                connection.Open();

//                string checkIfExists = "SELECT EXISTS(SELECT 1 FROM sqlite_master WHERE name=Passwords)";
//                using (SQLiteCommand command = new SQLiteCommand(checkIfExists, connection)) 
//                {
                    
//                    var temp = command.ExecuteScalar();

//                    //Assert
//                    Assert.IsNotNull(temp);
//                    Debug.WriteLine(temp);
//                }

               
//            }
           

//        }
//    }
//}

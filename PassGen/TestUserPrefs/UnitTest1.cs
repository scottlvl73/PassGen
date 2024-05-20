using PassGen;
using System.Windows.Forms;



namespace TestUserPrefs
{
    [TestClass]
    public class UserSettingsTests
    {
        private User_Settings userSettings;
        private MockSettings mockSettings;

        [TestInitialize]
        public void Setup()
        {
            mockSettings = new MockSettings();
            userSettings = new User_Settings(mockSettings);
        }

        [TestMethod]
        public void LoadSettings_ShouldLoadCorrectValues()
        {
            // Arrange
            mockSettings.PasswordLength = 12;
            mockSettings.IncludeUppercase = true;
            mockSettings.IncludeLowercase = true;
            mockSettings.IncludeNumbers = true;
            mockSettings.IncludeSpecialChars = true;
            mockSettings.ExcludeAmbiguousChars = false;
            mockSettings.AvoidRepeatingChars = false;

            // Act
            userSettings.LoadSettings();

            // Assert
            Assert.AreEqual(12, userSettings.PasswordLength);
            Assert.IsTrue(userSettings.IncludeUppercase);
            Assert.IsTrue(userSettings.IncludeLowercase);
            Assert.IsTrue(userSettings.IncludeNumbers);
            Assert.IsTrue(userSettings.IncludeSpecialChars);
            Assert.IsFalse(userSettings.ExcludeAmbiguousChars);
            Assert.IsFalse(userSettings.AvoidRepeatingChars);
        }

        [TestMethod]
        public void SaveSettings_ShouldSaveCorrectValues()
        {
            // Arrange
            userSettings.PasswordLength = 15;
            userSettings.IncludeUppercase = false;
            userSettings.IncludeLowercase = false;
            userSettings.IncludeNumbers = false;
            userSettings.IncludeSpecialChars = false;
            userSettings.ExcludeAmbiguousChars = true;
            userSettings.AvoidRepeatingChars = true;

            // Act
            userSettings.SaveSettings();

            // Assert
            Assert.AreEqual(15, mockSettings.PasswordLength);
            Assert.IsFalse(mockSettings.IncludeUppercase);
            Assert.IsFalse(mockSettings.IncludeLowercase);
            Assert.IsFalse(mockSettings.IncludeNumbers);
            Assert.IsFalse(mockSettings.IncludeSpecialChars);
            Assert.IsTrue(mockSettings.ExcludeAmbiguousChars);
            Assert.IsTrue(mockSettings.AvoidRepeatingChars);
        }

        [TestMethod]
        public void ApplyButton_ShouldSaveSettingsAndCloseForm()
        {
            // Arrange
            userSettings.PasswordLength = 10;
            var applyButton = new Button();
            applyButton.Click += new EventHandler(userSettings.btnApply_Click);

            // Act
            applyButton.PerformClick();

            // Assert
            Assert.AreEqual(DialogResult.OK, userSettings.DialogResult);
            Assert.AreEqual(10, mockSettings.PasswordLength);
        }
    }
}

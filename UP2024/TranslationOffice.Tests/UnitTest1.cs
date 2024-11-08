using Microsoft.VisualStudio.TestTools.UnitTesting;
using TranslationOffice;
using UP2024;

namespace TranslationOffice.Tests
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckUserRole_ValidAdminCredentials_ReturnsAdmin()
        {
            // Arrange
            var form = new Form1();
            string login = "admin";
            string password = "admin_password"; // �������� �� �������� ������

            // Act
            string result = form.CheckUserRole(login, password);

            // Assert
            Assert.AreEqual("Admin", result);
        }

        [TestMethod]
        public void CheckUserRole_ValidClientCredentials_ReturnsClient()
        {
            // Arrange
            var form = new Form1();
            string login = "client";
            string password = "client_password"; // �������� �� �������� ������

            // Act
            string result = form.CheckUserRole(login, password);

            // Assert
            Assert.AreEqual("Client", result);
        }

        [TestMethod]
        public void CheckUserRole_ValidTranslatorCredentials_ReturnsTranslator()
        {
            // Arrange
            var form = new Form1();
            string login = "translator";
            string password = "translator_password"; // �������� �� �������� ������

            // Act
            string result = form.CheckUserRole(login, password);

            // Assert
            Assert.AreEqual("Translator", result);
        }

        [TestMethod]
        public void CheckUserRole_InvalidCredentials_ReturnsNull()
        {
            // Arrange
            var form = new Form1();
            string login = "invalid_user";
            string password = "invalid_password";

            // Act
            string result = form.CheckUserRole(login, password);

            // Assert
            Assert.IsNull(result);
        }

        [TestMethod]
        public void GetUserId_ValidAdminCredentials_ReturnsAdminId()
        {
            // Arrange
            var form = new Form1();
            string login = "admin1";
            string password = "admin_password1"; // �������� �� �������� ������

            // Act
            int result = form.GetUserId(login, password);

            // Assert
            Assert.AreEqual(1, result); // �������� �� �������� ID ��������������
        }

        [TestMethod]
        public void GetUserId_InvalidCredentials_ReturnsZero()
        {
            // Arrange
            var form = new Form1();
            string login = "invalid_user";
            string password = "invalid_password";

            // Act
            int result = form.GetUserId(login, password);

            // Assert
            Assert.AreEqual(0, result);
        }

        [TestMethod]
        public void LoadData_ValidTable_LoadsData()
        {
            // Arrange
            var form2 = new Form2();

            // Act
            form2.LoadData();

            // Assert
            // ���������, ��� ������ ��������� � dataGridView1
        }
    }
}



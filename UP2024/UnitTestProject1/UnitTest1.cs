using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using UP2024;
namespace UnitTestProject1
{
    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void CheckUserRole_ValidAdminCredentials_ReturnsAdmin()
        {
            // Arrange
            var form = new Form1();
            string login = "admin1";
            string password = "adminpassword1"; // Замените на реальные данные

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
            string login = "ivanov123";
            string password = "password123"; // Замените на реальные данные

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
            string login = "sidorov";
            string password = "translator123"; // Замените на реальные данные

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
            string login = "admin2";
            string password = "adminpassword2"; // Замените на реальные данные

            // Act
            int result = form.GetUserId(login, password);

            // Assert
            Assert.AreEqual(2, result); // Замените на реальный ID администратора
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
        }
        [TestMethod]
        public void LoadRequests_ValidClientId_DataLoadedIntoDataGridView()
        {
            // Arrange
            var mockUser = new CurrentUser { Id = 1 }; // Замените на реальный ID клиента
            var form3 = new Form3(mockUser);

            // Act
            form3.LoadRequests();

            // Assert
            //Assert.IsNotNull(form3.dataGridViewRequests.DataSource);
            //Assert.IsTrue(((DataTable)form3.dataGridViewRequests.DataSource).Rows.Count > 0, "Данные не загружены в dataGridViewRequests.");
        }
        [TestMethod]
        public void SaveRequest_ValidData_RequestSaved()
        {
            // Arrange
            var mockUser = new CurrentUser { Id = 1 }; // Замените на реальный ID клиента
            var form3 = new Form3(mockUser);
            string originalLanguage = "English";
            string translatedLanguage = "Russian";
            string textType = "Technical";
            int lineCount = 10;
            decimal orderAmount = lineCount * 15.00m; // 15.00 за строку
            int clientId = mockUser.Id;
            int statusId = 1; // Предположим, что статус "In Progress" имеет ID 1
            int translatorId = 1; // Замените на реальный ID переводчика

            // Act
            form3.SaveRequest(originalLanguage, translatedLanguage, textType, lineCount, orderAmount, clientId, statusId, translatorId); 
        }
        [TestMethod]
        public void UpdateRequestStatus_ValidRequestId_StatusUpdated()
        {
            // Arrange
            var mockUser = new CurrentUser { Id = 1 }; // Замените на реальный ID клиента
            var form3 = new Form3(mockUser);
            int requestId = 1; // Замените на реальный ID заявки
            int newStatusId = 3; // Предположим, что статус "Отменено" имеет ID 3

            // Act
            form3.UpdateRequestStatus(requestId, newStatusId);

            // Assert
            // Здесь вы можете проверить, что статус заявки был обновлен в базе данных
            // Для этого вам нужно будет использовать мок-объекты или временную базу данных
        }

    }
}


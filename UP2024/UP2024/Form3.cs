using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace UP2024
{
    public partial class Form3 : Form
    {
        private Database database = new Database();
        private CurrentUser currentUser;
        public Form3(CurrentUser user)
        {
            currentUser = user; // Сохраняем переданного пользователя
            InitializeComponent();
            comboTextType.DropDownStyle = ComboBoxStyle.DropDownList; // Установка стиля выпадающего списка
        }

        private void Form3_Load(object sender, EventArgs e)
        {
            comboTextType.Items.Add("Technical");
            comboTextType.Items.Add("Literary");
            comboTextType.Items.Add("Legal");
            LoadRequests(); // Загрузка заявок текущего клиента
        }
        private int GetCurrentUserId()
        {
            return currentUser.Id; // Получаем ID текущего пользователя
        }
        public void LoadRequests()
        {
            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("SELECT * FROM Requests WHERE Client_ID = @clientId", database.getconnection());
                command.Parameters.AddWithValue("@clientId", GetCurrentUserId());

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewRequests.DataSource = dataTable; // Предполагается, что у вас есть DataGridView с именем dataGridViewRequests
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                database.closeconnection();
            }
        }
        private void btnSubmit_Click(object sender, EventArgs e)
        {
            string originalLanguage = txtOriginalLanguage.Text.Trim();
            string translatedLanguage = txtTranslatedLanguage.Text.Trim();
            string textType = comboTextType.SelectedItem?.ToString();
            int lineCount;

            if (comboTextType.SelectedItem == null)
            {
                MessageBox.Show("Пожалуйста, выберите тип текста.");
                return;
            }
            if (!int.TryParse(txtLineCount.Text.Trim(), out lineCount))
            {
                MessageBox.Show("Пожалуйста, введите корректное количество строк.");
                return;
            }

            // Рассчитываем сумму (например, 15.00 за строку)
            decimal orderAmount = lineCount * 15.00m; // Измените ставку по необходимости

            // Обновляем текст лейбла с суммой
            lblOrderAmount.Text = "Сумма: " + orderAmount.ToString("C"); // Форматируем как валюту

            // Получаем ID клиента (например, из текущего пользователя)
            int clientId = GetCurrentUserId();

            // Устанавливаем статус "In Progress"
            int statusId = GetStatusId("In Progress"); // Реализуйте метод для получения ID статуса

            // Получаем случайного переводчика
            int translatorId = GetRandomTranslatorId(); // Реализуйте метод для получения случайного ID переводчика

            // Сохраняем запрос в базу данных
            SaveRequest(originalLanguage, translatedLanguage, textType, lineCount, orderAmount, clientId, statusId, translatorId);
        }

        public void SaveRequest(string originalLanguage, string translatedLanguage, string textType, int lineCount, decimal orderAmount, int clientId, int statusId, int translatorId)
        {
            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("INSERT INTO Requests (OriginalLanguage, TranslatedLanguage, TextType, LineCount, OrderAmount, Client_ID, Status_ID, Translator_ID) VALUES (@originalLanguage, @translatedLanguage, @textType, @lineCount, @orderAmount, @clientId, @statusId, @translatorId)", database.getconnection());

                command.Parameters.AddWithValue("@originalLanguage", originalLanguage);
                command.Parameters.AddWithValue("@translatedLanguage", translatedLanguage);
                command.Parameters.AddWithValue("@textType", textType);
                command.Parameters.AddWithValue("@lineCount", lineCount);
                command.Parameters.AddWithValue("@orderAmount", orderAmount);
                command.Parameters.AddWithValue("@clientId", clientId);
                command.Parameters.AddWithValue("@statusId", statusId);
                command.Parameters.AddWithValue("@translatorId", translatorId);

                command.ExecuteNonQuery();
                MessageBox.Show("Запрос успешно отправлен!");
                // Обновляем DataGridView после добавления заявки
                LoadRequests(); // Обновляем список заявок
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                database.closeconnection();
            }
        }
        private int GetStatusId(string statusName)
        {
            int statusId = 0;

            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("SELECT ID FROM Statuses WHERE Name = @statusName", database.getconnection());
                command.Parameters.AddWithValue("@statusName", statusName);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    statusId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                database.closeconnection();
            }

            return statusId;
        }
        private int GetRandomTranslatorId()
        {
            int translatorId = 0;

            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("SELECT TOP 1 ID FROM Translators ORDER BY NEWID()", database.getconnection());
                object result = command.ExecuteScalar();
                if (result != null)
                {
                    translatorId = Convert.ToInt32(result);
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally 
            {
                database.closeconnection();
            }

            return translatorId;
        }

        private void btnLogout_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // Создаем новый экземпляр формы авторизации
            loginForm.Show(); // Показываем форму авторизации
            this.Close(); // Закрыть текущую форму
        }

        private void txtLineCount_KeyPress(object sender, KeyPressEventArgs e)
        {
            // Проверяем, является ли нажатая клавиша цифрой или клавишей Backspace
            if (!char.IsControl(e.KeyChar) && !char.IsDigit(e.KeyChar))
            {
                e.Handled = true; // Отменяем ввод, если это не цифра
            }
        }

        private void btnCancelRequest_Click(object sender, EventArgs e)
        {
            // Предположим, что у вас есть DataGridView для отображения заявок
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                int requestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["ID"].Value); // Получаем ID выбранной заявки

                // Изменяем статус заявки на "Отменено" (предположим, что ID статуса "Отменено" равен 3)
                UpdateRequestStatus(requestId, 3);
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку для отмены.");
            }
        }

        public void UpdateRequestStatus(int requestId, int statusId)
        {
            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("UPDATE Requests SET Status_ID = @statusId WHERE ID = @requestId", database.getconnection());
                command.Parameters.AddWithValue("@statusId", statusId);
                command.Parameters.AddWithValue("@requestId", requestId);

                int rowsAffected = command.ExecuteNonQuery();
                if (rowsAffected > 0)
                {
                    MessageBox.Show("Заявка успешно отменена!");
                    // Обновите DataGridView, чтобы отобразить изменения
                    LoadRequests(); // Реализуйте метод для загрузки заявок
                }
                else
                {
                    MessageBox.Show("Ошибка при отмене заявки.");
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
            }
            finally
            {
                database.closeconnection();
            }
        }

        private void dataGridViewRequests_CellClick(object sender, DataGridViewCellEventArgs e)
        {

            if (e.RowIndex >= 0) // Убедитесь, что строка выбрана
            {
                // Здесь вы можете обработать выбор строки, если это необходимо
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите заявку которую нужно отменить");
            }
            }
    }
}

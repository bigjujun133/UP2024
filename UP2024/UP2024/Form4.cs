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

    public partial class Form4 : Form
    {
        private Database database = new Database();
        private CurrentUser currentUser; // Экземпляр текущего пользователя
        private int selectedRequestId; // ID выбранной заявки
        private string selectedFilePath; // Путь к выбранному файлу
        public Form4(CurrentUser user)
        {
            InitializeComponent();
            currentUser = user; // Сохраняем текущего пользователя
            LoadRequests(); // Загружаем заявки
        }
        private void LoadRequests()
        {
            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("SELECT ID, OriginalLanguage, TranslatedLanguage, TextType, LineCount, OrderAmount FROM Requests WHERE Translator_ID = @translatorId", database.getconnection());
                command.Parameters.AddWithValue("@translatorId", currentUser.Id);

                SqlDataAdapter adapter = new SqlDataAdapter(command);
                DataTable dataTable = new DataTable();
                adapter.Fill(dataTable);

                dataGridViewRequests.DataSource = dataTable; // Привязываем данные к DataGridView
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

        private void dataGridViewRequests_SelectionChanged(object sender, EventArgs e)
        {
            if (dataGridViewRequests.SelectedRows.Count > 0)
            {
                selectedRequestId = Convert.ToInt32(dataGridViewRequests.SelectedRows[0].Cells["ID"].Value);
            }
        }

        private void btnAttachFile_Click(object sender, EventArgs e)
        {
            using (OpenFileDialog openFileDialog = new OpenFileDialog())
            {
                if (openFileDialog.ShowDialog() == DialogResult.OK)
                {
                    selectedFilePath = openFileDialog.FileName; // Сохраняем путь к файлу
                }
            }
        }

        private void btnSafeFile_Click(object sender, EventArgs e)
        {
            if (selectedRequestId == 0 || string.IsNullOrEmpty(selectedFilePath))
            {
                MessageBox.Show("Пожалуйста, выберите заявку и файл для прикрепления.");
                return;
            }

            string comment = txtComment.Text.Trim();

            try
            {
                database.openconnection();

                // Сохраняем файл в таблицу Files
                SqlCommand command = new SqlCommand("INSERT INTO Files (FilePath, Comment, Request_ID) VALUES (@filePath, @comment, @requestId)", database.getconnection());
                command.Parameters.AddWithValue("@filePath", selectedFilePath);
                command.Parameters.AddWithValue("@comment", comment);
                command.Parameters.AddWithValue("@requestId", selectedRequestId);

                command.ExecuteNonQuery();

                // Обновляем статус заявки на "Completed"
                UpdateRequestStatus(selectedRequestId, 2); // 2 - ID статуса "Completed"

                MessageBox.Show("Файл успешно прикреплен и статус заявки обновлен.");
                LoadRequests(); // Перезагружаем заявки
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
        private void UpdateRequestStatus(int requestId, int statusId)
        {
            try
            {
                SqlCommand command = new SqlCommand("UPDATE Requests SET Status_ID = @statusId WHERE ID = @requestId", database.getconnection());
                command.Parameters.AddWithValue("@statusId", statusId);
                command.Parameters.AddWithValue("@requestId", requestId);

                command.ExecuteNonQuery(); // Выполняем обновление статуса
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при обновлении статуса: " + ex.Message);
            }
        }

        private void Form4_Load(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // Создаем новый экземпляр формы авторизации
            loginForm.Show(); // Показываем форму авторизации
            this.Close(); // Закрыть текущую форму
        }
    }
}

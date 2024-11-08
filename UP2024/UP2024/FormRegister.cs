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
    public partial class FormRegister : Form
    {
        Database database = new Database();
        public FormRegister()
        {
            InitializeComponent();
        }
        public void btnRegister_Click(object sender, EventArgs e)
        {
            string login = txtRegisterLogin.Text.Trim();
            string password = txtRegisterPassword.Text.Trim();
            string fullName = txtFullName.Text.Trim();
            string email = txtEmail.Text.Trim();

            // Проверка на пустые поля
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password) || string.IsNullOrEmpty(fullName) || string.IsNullOrEmpty(email))
            {
                MessageBox.Show("Пожалуйста, заполните все поля.");
                return;
            }

            // Проверка уникальности логина
            try
            {
                database.openconnection();
                SqlCommand checkCommand = new SqlCommand("SELECT COUNT(*) FROM Clients WHERE Login = @login", database.getconnection());
                checkCommand.Parameters.AddWithValue("@login", login);

                int count = (int)checkCommand.ExecuteScalar();
                if (count > 0)
                {
                    MessageBox.Show("Этот логин уже занят. Пожалуйста, выберите другой логин.");
                    return; // Прекратить выполнение, если логин уже существует
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка: " + ex.Message);
                return; // Прекратить выполнение в случае ошибки
            }
            finally
            {
                database.closeconnection();
            }

            // Добавление нового клиента в базу данных
            try
            {
                database.openconnection();
                SqlCommand command = new SqlCommand("INSERT INTO Clients (FullName, ContactInfo, Login, Password) VALUES (@fullName, @contactInfo, @login, @password); SELECT SCOPE_IDENTITY();", database.getconnection());
                command.Parameters.AddWithValue("@fullName", fullName);
                command.Parameters.AddWithValue("@contactInfo", email);
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                // Получаем ID нового клиента
                int newClientId = Convert.ToInt32(command.ExecuteScalar());
                MessageBox.Show("Регистрация прошла успешно! Ваш ID: " + newClientId);

                // Создаем экземпляр CurrentUser и сохраняем ID клиента
                CurrentUser currentUser = new CurrentUser
                {
                    Id = newClientId,
                    Login = login // Если нужно, сохраняем логин
                };

                // Переход к форме авторизации
                Form1 loginForm = new Form1(); // Создаем новый экземпляр формы авторизации
                loginForm.Show(); // Показываем форму авторизации
                this.Close(); // Закрыть форму регистрации
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
       private void btnBack_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // Создаем новый экземпляр формы авторизации
            loginForm.Show(); // Показываем форму авторизации
            this.Close(); // Закрываем текущую форму регистрации
        }
    }
}

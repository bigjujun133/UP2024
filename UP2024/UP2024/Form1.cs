using System;
using System.Data;
using System.Data.SqlClient;
using System.Windows.Forms;

namespace UP2024
{
    public partial class Form1 : Form
    {
        private CurrentUser currentUser; // Экземпляр текущего пользователя
        Database database = new Database();

        public Form1()
        {
            InitializeComponent();
        }

        private void Form1_Load(object sender, EventArgs e)
        {
            // Инициализация формы, если необходимо
        }

        public string CheckUserRole(string login, string password)
        {
            string role = null;

            try
            {
                // Проверка в таблице Admins
                database.openconnection();
                SqlCommand command = new SqlCommand("SELECT COUNT(*) FROM Admins WHERE Login = @login AND Password = @password", database.getconnection());
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                int count = (int)command.ExecuteScalar();
                if (count > 0)
                {
                    role = "Admin";
                }
                else
                {
                    // Проверка в таблице Clients
                    command = new SqlCommand("SELECT COUNT(*) FROM Clients WHERE Login = @login AND Password = @password", database.getconnection());
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);

                    count = (int)command.ExecuteScalar();
                    if (count > 0)
                    {
                        role = "Client";
                    }
                    else
                    {
                        // Проверка в таблице Translators
                        command = new SqlCommand("SELECT COUNT(*) FROM Translators WHERE Login = @login AND Password = @password", database.getconnection());
                        command.Parameters.AddWithValue("@login", login);
                        command.Parameters.AddWithValue("@password", password);

                        count = (int)command.ExecuteScalar();
                        if (count > 0)
                        {
                            role = "Translator";
                        }
                    }
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

            return role;
        }

        private void btnLogin_Click_1(object sender, EventArgs e)
        {
            string login = txtLogin.Text.Trim();
            string password = txtPassword.Text.Trim();

            // Проверка логина и пароля
            string role = CheckUserRole(login, password);
            if (role != null)
            {
                // Успешный вход, создаем экземпляр CurrentUser
                currentUser = new CurrentUser
                {
                    Id = GetUserId(login, password), // Метод для получения ID пользователя
                    Login = login
                };
                if (role == "Admin")
                {
                    Form2 adminForm = new Form2(); // Форма для администратора
                    adminForm.Show();
                    this.Hide(); // Скрыть текущую форму
                }
                else if (role == "Client")
                {
                    Form3 clientForm = new Form3(currentUser); // Форма для клиента, Передаем текущего пользователя
                    clientForm.Show();
                    this.Hide(); // Скрыть текущую форму
                }
                else if (role == "Translator")
                {
                    Form4 translatorForm = new Form4(currentUser); // Форма для переводчика
                    translatorForm.Show();
                    this.Hide(); // Скрыть текущую форму
                }
            }
            else
            {
                // Сообщение о неверном логине или пароле
                MessageBox.Show("Неверный логин или пароль. Пожалуйста, проверьте введенные данные.");
            }
        }

        private void linkLabel1_LinkClicked(object sender, LinkLabelLinkClickedEventArgs e)
        {
            FormRegister registerForm = new FormRegister();
            registerForm.Show();
            this.Hide(); // Скрыть текущую форму
        }
        public int GetUserId(string login, string password)
        {
            int userId = 0;

            try
            {
                database.openconnection();

                // Проверка в таблице Admins
                SqlCommand command = new SqlCommand("SELECT ID FROM Admins WHERE Login = @login AND Password = @password", database.getconnection());
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                object result = command.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                    return userId; // Возвращаем ID администратора
                }

                // Проверка в таблице Clients
                command = new SqlCommand("SELECT ID FROM Clients WHERE Login = @login AND Password = @password", database.getconnection());
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                result = command.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                    return userId; // Возвращаем ID клиента
                }

                // Проверка в таблице Translators
                command = new SqlCommand("SELECT ID FROM Translators WHERE Login = @login AND Password = @password", database.getconnection());
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);

                result = command.ExecuteScalar();
                if (result != null)
                {
                    userId = Convert.ToInt32(result);
                    return userId; // Возвращаем ID переводчика
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

            return userId; // Если пользователь не найден, возвращаем 0
        }
    }
}

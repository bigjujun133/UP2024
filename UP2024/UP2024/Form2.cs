using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Data.SqlClient;

namespace UP2024
{
    public partial class Form2 : Form
    {
        Database database = new Database();
        string currentTable = "Clients"; // Начальная таблица
        public Form2()
        {
            InitializeComponent();
            comboBoxTables.Items.AddRange(new string[] { "Admins", "Clients", "Translators", "Requests", "Files" });
            comboBoxTables.SelectedItem = "Clients";
            LoadData();
        }
        public void LoadData()
        {
            try
            {
                database.openconnection();
                SqlDataAdapter adapter = new SqlDataAdapter($"SELECT * FROM {currentTable}", database.getconnection());
                DataTable table = new DataTable();
                adapter.Fill(table);
                dataGridView1.DataSource = table;
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

        private void btnAdd_Click(object sender, EventArgs e)
        {
            FormAddEdit addForm = new FormAddEdit(currentTable);
            addForm.ShowDialog(); // Открываем форму как модальное окно
            LoadData(); // Обновляем данные после добавления
        }

        private void btnEdit_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Предполагается, что ID в первой колонке
                FormAddEdit editForm = new FormAddEdit(currentTable, id);
                editForm.ShowDialog(); // Открываем форму как модальное окно
                LoadData(); // Обновляем данные после редактирования
            }
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для редактирования.");
            }
        }

        public void btnDelete_Click(object sender, EventArgs e)
        {
            if (dataGridView1.SelectedRows.Count > 0)
            {
                int id = Convert.ToInt32(dataGridView1.SelectedRows[0].Cells[0].Value); // Предполагается, что ID в первой колонке
                try
                {
                    database.openconnection();
                    SqlCommand command = new SqlCommand($"DELETE FROM {currentTable} WHERE ID = @id", database.getconnection());
                    command.Parameters.AddWithValue("@id", id);
                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись удалена.");
                    LoadData(); // Обновить данные
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
            else
            {
                MessageBox.Show("Пожалуйста, выберите запись для удаления.");
            }
        }

        private void comboBoxTables_SelectedIndexChanged(object sender, EventArgs e)
        {
            currentTable = comboBoxTables.SelectedItem.ToString();
            LoadData(); // Загружаем данные выбранной таблицы
        }

        private void button1_Click(object sender, EventArgs e)
        {
            Form1 loginForm = new Form1(); // Создаем новый экземпляр формы авторизации
            loginForm.Show(); // Показываем форму авторизации
            this.Close(); // Закрыть текущую форму
        }
    }
}

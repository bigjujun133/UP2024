using System;
using System.Data;
using System.Data.SqlClient;
using System.Drawing;
using System.Windows.Forms;

namespace UP2024
{
    public partial class FormAddEdit : Form
    {
        private Database database = new Database();
        private string currentTable;
        private int? recordId; // ID записи, если редактируем

        public FormAddEdit(string table, int? id = null)
        {
            InitializeComponent();
            currentTable = table;
            recordId = id;

            CreateDynamicFields();

            if (recordId.HasValue)
            {
                LoadData();
            }
        }

        private void CreateDynamicFields()
        {
            DataTable schema = GetTableSchema(currentTable);
            int yPos = 10; // Начальная позиция по вертикали

            foreach (DataColumn column in schema.Columns)
            {
                // Пропускаем столбец ID
                if (column.ColumnName == "ID") continue;
                Label label = new Label
                {
                    Text = column.ColumnName,
                    Location = new Point(10, yPos),
                    AutoSize = true
                };
                this.Controls.Add(label);

                TextBox textBox = new TextBox
                {
                    Name = column.ColumnName,
                    Location = new Point(150, yPos),
                    Width = 200
                };
                this.Controls.Add(textBox);

                yPos += 30; // Увеличиваем позицию для следующего поля
            }

            Button btnSave = new Button
            {
                Text = "Сохранить",
                Location = new Point(10, yPos),
                BackColor=Color.Olive,
                Width=100,
                Height=75
            };
            btnSave.Click += new EventHandler(btnSave_Click);
            this.Controls.Add(btnSave);
        }

        private DataTable GetTableSchema(string tableName)
        {
            DataTable schemaTable = new DataTable();
            string connectionString = @"Data Source=ADCLG1;Initial Catalog=ROMAN;Integrated Security=True";//HOME-PC\SQLEXPRESS

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Открываем соединение
                    SqlCommand command = new SqlCommand($"SELECT * FROM {tableName} WHERE 1 = 0", connection); // Получаем только схему
                    SqlDataAdapter adapter = new SqlDataAdapter(command);
                    adapter.Fill(schemaTable);
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка: " + ex.Message);
                MessageBox.Show($"Ошибка: {ex.Message}\n\nStackTrace: {ex.StackTrace}");
            }
            return schemaTable;
        }

        private void LoadData()
        {
            string connectionString = @"Data Source=ADCLG1;Initial Catalog=ROMAN;Integrated Security=True"; /*HOME - PC\SQLEXPRESS*/

            try
            {
                using (SqlConnection connection = new SqlConnection(connectionString))
                {
                    connection.Open(); // Открываем соединение
                    SqlCommand command = new SqlCommand($"SELECT * FROM {currentTable} WHERE ID = @id", connection);
                    command.Parameters.AddWithValue("@id", recordId.Value);
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        if (reader.Read())
                        {
                            foreach (DataColumn column in GetTableSchema(currentTable).Columns)
                            {
                                TextBox textBox = this.Controls[column.ColumnName] as TextBox;
                                if (textBox != null)
                                {
                                    textBox.Text = reader[column.ColumnName].ToString();
                                }
                            }
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                //MessageBox.Show("Ошибка загрузки данных: " + ex.Message);
                MessageBox.Show($"Ошибка: {ex.Message}\n\nStackTrace: {ex.StackTrace}");
            }
        }



        private void btnSave_Click(object sender, EventArgs e)
        {
            try
            {
                using (SqlConnection connection = database.getconnection())
                {
                    connection.Open();
                    SqlCommand command;

                    if (recordId.HasValue) // Если редактируем
                    {
                        command = new SqlCommand($"UPDATE {currentTable} SET ", connection);
                        foreach (DataColumn column in GetTableSchema(currentTable).Columns)
                        {
                            if (column.ColumnName != "ID") // Пропускаем столбец ID
                            {
                                command.CommandText += $"{column.ColumnName} = @{column.ColumnName}, ";
                                command.Parameters.AddWithValue($"@{column.ColumnName}", this.Controls[column.ColumnName].Text);
                            }
                        }
                        command.CommandText = command.CommandText.TrimEnd(',', ' '); // Удаляем последнюю запятую
                        command.CommandText += " WHERE ID = @id";
                        command.Parameters.AddWithValue("@id", recordId.Value);
                    }
                    else // Если добавляем
                    {
                        command = new SqlCommand($"INSERT INTO {currentTable} (", connection);
                        foreach (DataColumn column in GetTableSchema(currentTable).Columns)
                        {
                            if (column.ColumnName != "ID") // Пропускаем столбец ID
                            {
                                command.CommandText += $"{column.ColumnName}, ";
                            }
                        }
                        command.CommandText = command.CommandText.TrimEnd(',', ' ') + ") VALUES (";
                        foreach (DataColumn column in GetTableSchema(currentTable).Columns)
                        {
                            if (column.ColumnName != "ID") // Пропускаем столбец ID
                            {
                                command.CommandText += $"@{column.ColumnName}, ";
                                command.Parameters.AddWithValue($"@{column.ColumnName}", this.Controls[column.ColumnName].Text);
                            }
                        }
                        command.CommandText = command.CommandText.TrimEnd(',', ' ') + ")";
                    }

                    command.ExecuteNonQuery();
                    MessageBox.Show("Запись сохранена.");
                    this.Close(); // Закрыть форму после сохранения
                }
            }
            catch (Exception ex)
            {
                MessageBox.Show("Ошибка при сохранении: " + ex.Message);
            }
        }
    }
}


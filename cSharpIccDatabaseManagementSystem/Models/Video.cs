using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace cSharpIccDatabaseManagementSystem.Models
{
    class Video
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int TotalQty { get; set; }
        public int InQty { get; set; }
        public int OutQty { get; set; }

        public void RetrieveAll(DataGridView dataGridViewVideoLibrary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Video", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewVideoLibrary.DataSource = dataTable;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void RetrieveSpecific(DataGridView dataGridViewVideoLibrary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Video WHERE Id LIKE @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", "%" + Id + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0) dataGridViewVideoLibrary.DataSource = dataTable;
                        else
                        {
                            MessageBox.Show("Does Not Exist");
                            dataGridViewVideoLibrary.DataSource = null;
                        }
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void Create()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("INSERT INTO Video VALUES (@Id, @Name, @Type, @Price, @TotalQty, @InQty, @OutQty)", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Type", Type);
                        command.Parameters.AddWithValue("@Price", Price);
                        command.Parameters.AddWithValue("@TotalQty", TotalQty);
                        command.Parameters.AddWithValue("@InQty", InQty);
                        command.Parameters.AddWithValue("@OutQty", OutQty);
                        command.ExecuteNonQuery();
                    }

                    MessageBox.Show("Successfully Created!");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void AddQty()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    int rowsAffected;

                    connection.Open();
                    using (SqlCommand command = new SqlCommand("UPDATE Video SET totalQty = totalQty + @InQty WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@InQty", InQty);
                        rowsAffected = command.ExecuteNonQuery();
                    }

                    using (SqlCommand command = new SqlCommand("UPDATE Video SET inQty = inQty + @InQty WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@InQty", InQty);
                        rowsAffected = command.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0) MessageBox.Show("Successfully Added!");
                    else MessageBox.Show("Does Not Exist");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void Update()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    int rowsAffected;

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE VIDEO SET Name = @name, Type = @Type, Price = @Price WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Type", Type);
                        command.Parameters.AddWithValue("@Price", Price);
                        rowsAffected = command.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0) MessageBox.Show("Successfully Updated!");
                    else MessageBox.Show("Does Not Exist");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void Delete()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    int rowsAffected;

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("DELETE FROM Video WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        rowsAffected = command.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0) MessageBox.Show("Successfully Deleted!");
                    else MessageBox.Show("Does Not Exist");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

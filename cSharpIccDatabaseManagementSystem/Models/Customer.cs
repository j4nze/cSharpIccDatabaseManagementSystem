using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Diagnostics;

namespace cSharpIccDatabaseManagementSystem.Models
{
    class Customer
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public int Mobile { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }


        public void RetrieveAll(DataGridView dataGridViewCustomerLibrary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Customer", connection))
                    {
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);
                        dataGridViewCustomerLibrary.DataSource = dataTable;
                    }
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
        public void RetrieveSpecific(DataGridView dataGridViewCustomerLibrary)
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    connection.Open();
                    using (SqlCommand command = new SqlCommand("SELECT * FROM Customer WHERE Id LIKE @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", "%" + Id + "%");
                        SqlDataAdapter adapter = new SqlDataAdapter(command);
                        DataTable dataTable = new DataTable();
                        adapter.Fill(dataTable);

                        if (dataTable.Rows.Count > 0) dataGridViewCustomerLibrary.DataSource = dataTable;
                        else
                        {
                            MessageBox.Show("Does Not Exist");
                            dataGridViewCustomerLibrary.DataSource = null;
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
                    using (SqlCommand command = new SqlCommand("INSERT INTO Customer VALUES (@Id, @Name, @Mobile, @Email, @Address)", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Mobile", Mobile);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Address", Address);
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
        public void Update()
        {
            try
            {
                using (SqlConnection connection = new SqlConnection(DbConfig.ConnectionString))
                {
                    int rowsAffected;

                    connection.Open();

                    using (SqlCommand command = new SqlCommand("UPDATE Customer SET Name = @name, Mobile = @Mobile, Email = @Email, Address = @Address WHERE Id = @Id", connection))
                    {
                        command.Parameters.AddWithValue("@Id", Id);
                        command.Parameters.AddWithValue("@Name", Name);
                        command.Parameters.AddWithValue("@Mobile", Mobile);
                        command.Parameters.AddWithValue("@Email", Email);
                        command.Parameters.AddWithValue("@Address", Address);
                        rowsAffected = command.ExecuteNonQuery();
                    }

                    if (rowsAffected > 0) MessageBox.Show("Successfully Updated!");
                    else MessageBox.Show("Does Not Exist.");
                }
            }
            catch (Exception exc)
            {
                MessageBox.Show(exc.Message);
            }
        }
    }
}

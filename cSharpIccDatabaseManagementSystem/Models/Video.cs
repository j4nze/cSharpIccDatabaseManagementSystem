using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpIccDatabaseManagementSystem.Models
{
    public class Video
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Type { get; set; }
        public int Price { get; set; }
        public int TotalQty { get; set; }
        public int InQty { get; set; }
        public int OutQty { get; set; }

        public void RetrieveAll()
        {
            
        }
        public void RetrieveSpecific()
        {

        }
        public void Create()
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
            }
        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
}

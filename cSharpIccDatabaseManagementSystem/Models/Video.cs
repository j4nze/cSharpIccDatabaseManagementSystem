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
            
        }
        public void Update()
        {

        }
        public void Delete()
        {

        }
    }
}

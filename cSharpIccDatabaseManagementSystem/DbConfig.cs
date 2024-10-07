using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace cSharpIccDatabaseManagementSystem
{
    public class DbConfig
    {
        public static string ConnectionString
        {
            get
            {
                return "Data Source=(localdb)\\MSSQLLocalDB;Initial Catalog=bvsDbmsLesson;Integrated Security=True;Connect Timeout=30";
            }
        }
    }
}

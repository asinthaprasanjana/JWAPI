using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OnimtaPrint._0001_DataBase
{
    public class DBContext
    {
        public static string connectionString ="";

       public  DBContext()
        {
            connectionString = "Data Source=SERVER\\ONIMTA;Initial Catalog=OnimtaWebInventory;Persist Security Info=True;User ID=sa;Password=it@onimta1+;MultipleActiveResultSets=True";
        }

       public string GetConnectionString()
        {
            return connectionString;
        }
    }
}

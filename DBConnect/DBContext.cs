//using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;
using System.Threading.Tasks;

namespace DBConnect
{
    public class DBContext : IDBContext
    {
        public IDbConnection dbConnection;

        public IDbTransaction _transaction;
    }
}

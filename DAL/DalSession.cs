using OnimtaWebInventory.UnitOfWork;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace DAL
{
    public sealed class DalSession : IDisposable
    {
        // private readonly string connectionString = "Data Source=mssql.onimtaitsl.com;Initial Catalog=onimtait_inventory;Persist Security Info=True;User ID=onimtainventory;Password=it@onimta1+;MultipleActiveResultSets=True";
        private readonly string connectionString = "Data Source=SERVER\\ONIMTA;Initial Catalog=OnimtaWebInventory;Persist Security Info=True;User ID=sa;Password=it@onimta1+;MultipleActiveResultSets=True";
        //private readonly string connectionString = "Data Source = onimtait.dyndns.info,1443; Initial Catalog = OnimtaWebInventory; Persist Security Info=True;User ID = sa;Password=it@onimta1+;MultipleActiveResultSets=True";

        public DalSession()
        {
            _connection = new SqlConnection(connectionString);
            _connection.Open();
            //_unitOfWork = new UnitOfWork(_connection);
        }

        public IDbConnection _connection = null;
        UnitOfWork _unitOfWork = null;

        public UnitOfWork UnitOfWork
        {
            get { return _unitOfWork; }
        }

        public void Dispose()
        {
            //_unitOfWork.Dispose();
            _connection.Dispose();
        }
    }
}

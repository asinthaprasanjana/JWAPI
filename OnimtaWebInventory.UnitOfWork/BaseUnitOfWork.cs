using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Text;

namespace OnimtaWebInventory.UnitOfWork
{
   public abstract class BaseUnitOfWork : IBaseUnitOfWork
    {
        public IDbConnection _connection = null;
        public IDbTransaction _transaction = null;



        public BaseUnitOfWork()
        {
          //  _connection.Open();
        }


        public void BeginTransaction()
        {
           
          _transaction =   _connection.BeginTransaction();
        }

        public void CommitTransaction()
        {
            try
            {
          
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _transaction.Commit();
                _connection.Close();
            }
        }

        public void RollbackTransaction()
        {
            try
            {
                _transaction.Rollback();
            }
            catch (Exception)
            {
                throw;
            }
            finally
            {
                _connection.Close();
            }
        }

        public void Dispose()
        {
            _connection.Dispose();

        }
    }

  
}

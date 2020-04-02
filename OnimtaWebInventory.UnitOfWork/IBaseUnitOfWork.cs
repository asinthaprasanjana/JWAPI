using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.UnitOfWork
{
   public interface IBaseUnitOfWork :IDisposable
    {
        void BeginTransaction();
        void CommitTransaction();
        void RollbackTransaction();
    }
}

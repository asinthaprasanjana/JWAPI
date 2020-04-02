using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace OnimtaWebInventory.Core.IRepository
{
    interface IRepostory
    {
        void setTransaction(IDbConnection con, IDbTransaction trn);

    }
}

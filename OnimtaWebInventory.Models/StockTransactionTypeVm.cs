using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class StockTransactionTypeVm
    {
        public int  Id { get; set; }
        public int  TransactionTypeId{ get; set; }
        public string TransactionName { get; set; }
        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
    }
}

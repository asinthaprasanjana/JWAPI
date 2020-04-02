using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnimtaWebInventory.Models
{
   public  class PurchaseOrderRequestItemsViewVm
    {
        
        public int ItemId { get; set; }
        public string ItemName { get; set; }
    }
}

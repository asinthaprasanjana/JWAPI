using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class SalesOrderReturnItemVM
    {
       
        public int ItemId { get; set; }
        public int CompanyId { get; set; }
        public string SaleNo { get; set; }
        public int ReturningQuantity { get; set; }
        public int ReturningPrice { get; set; }     


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public  class SalesOrderItemVM
    {
       
        public int ItemId { get; set; }
        public int ProductId { get; set; }
        public int salesOrderId { get; set;}
        public int salesOrderItemId { get; set; }
        public string ItemName { get; set; }
        public string SaleNo { get; set; }
        public int Quantity { get; set; }
        public int PackSizeId { get; set; }
        public int ReturningQuantity { get; set; }
        public double ReturningPrice { get; set; }
        public double ItemCost { get; set; }
        public double Discount { get; set; }
        public double Tax { get; set; }
        public double TotalPrice { get; set; }
        public int UserId { get; set; }
        public int CompanyId { get; set; }
        public float TotalCost { get; set; }
        public DateTime CreatedDateTime { get; set; } 


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public class StockAdjustmentDetailVM
    {
        public int Id { get; set; }
        public   string StockAdjustmentId { get; set; }
        public int ProductId { get; set; }
        public string ProductName { get; set; }
        public string SupplierCode { get; set; }
        public int NewQuantity { get; set; }
        public int StockOnHand { get; set; }
        public int AvailableStock { get; set; }
        public int variance { get; set; }
        public string Comment { get; set; }
        public int BranchId { get; set; }

        public int CompanyId { get; set; }

        public int CreatedUserId { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public string BranchName { get; set; }

        public string PackSizeName { get; set; }
        public int PackSizeId { get; set; }


    }
}

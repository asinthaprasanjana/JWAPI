using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
  public class StockAdjustmentSummeryVM
    {
        public int id { get; set; }
        public int BranchId { get; set; }
        public string BranchName { get; set; }
        public string StockAdjustmentId { get; set; }
        public int CreatedUserId { get; set; }
        public string CreatedUserName { get; set; }
        public int CompanyID { get; set; }
        public DateTime CreatedDate { get; set; }
        public int ApprovalStatus { get; set; }

        public IEnumerable< StockAdjustmentDetailVM> stockAdjustmentDetailVM { get; set; }
    }
}

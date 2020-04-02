using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class PurchaseOrderRequestVM
    {
        public int Id { get; set; }
        public string  PurchaseNo { get; set; }
        public int CompanyId { get; set; }
        public int BranchId { get; set; }
        public DateTime StartDate{ get; set; }
        public DateTime EndDate { get; set; }
        public string  Remarks { get; set; }
        public int  CreatedUserId{ get; set; }
        public DateTime CreatedDateTime { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

    }
}

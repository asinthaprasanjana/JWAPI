using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class PurchaseOrderReportVM
    {
        public int Id { get; set; }
        public string Month { get; set; }
        public int Count { get; set; }
        public int CompanyId { get; set; }
        public string Status { get; set; }
        public int BillLocationId { get; set; }
        public int  NetTotal { get; set; }
    }
 
}

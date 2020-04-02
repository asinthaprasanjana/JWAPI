using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class SalesDraftSummaryVM
    {
        public int SaleNo { get; set; }
        public int NetTotal { get; set; }
        public string DisplayName { get; set; }
        public string SalesDocumentNo { get; set; }
        public string CreatedDateTime { get; set; }
        public int CreatedUserId { get; set; }
    }
}

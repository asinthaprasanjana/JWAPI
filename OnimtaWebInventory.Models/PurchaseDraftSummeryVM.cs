using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class PurchaseDraftSummeryVM
    {
        public int PurchaseNo { get; set; }
        public int NetTotal { get; set; }
        public string DisplayName { get; set; }

        public string UserName { get; set; }

        public string CreatedDateTime { get; set; }
    }
}

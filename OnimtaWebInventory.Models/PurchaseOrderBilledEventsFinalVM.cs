using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PurchaseOrderBilledEventsFinalVM
    {
        public int isBalanceToAdvance { get; set; }
        public decimal balanceAmount { get; set; }
        public int isAdvancePayments { get; set; }
        public decimal advancePaymentAmount { get; set; }
        public IEnumerable<PurchaseOrderBilledEventsVM> purchaseOrderBilledEventsVM { get; set; }

    }
    
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PurchaseOrderInteligenceVM
    {

    }
    public class PurchaseAndSalesSummaryVM {

        public IEnumerable<string> ProductName { get; set; }
        public IEnumerable<int> PurchaseCount { get; set; }
        public IEnumerable<int> SalesCount { get; set; }

    }

}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class SalesOrderFinalVM
    {
        public float GrossTotal { get; set; }
        public float Tax { get; set; }
        public float Discount { get; set; }
        public string SaleNo { get; set; }

        public string DocumentNo { get; set; }

        public string SaleNos { get; set; }
        public float NetTotal { get; set; }
        public int UserId { get; set; }
    }
}


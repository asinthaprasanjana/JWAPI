using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class SalesInvoiceMasterVM
    {
        public string CustomerId { get; set; }
        public string DisplayName { get; set; }
        public string InvoiceNo { get; set; }

        public string DocumentNo { get; set; }

        public string OrderNo { get; set; }
        public int CompanyId { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Remarks { get; set; }
        public double GrossTotal { get; set; }
        public double NetTotal { get; set; }
        public double TotalTax { get; set; }
        public double TotalDiscounts { get; set; }
        public int CreatedUserId { get; set; }
        public bool isProforma { get; set; }
        public IEnumerable<SalesOrderItemVM> salesOrderItemVM { get; set; }

    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class SalesInvoiceSummaryVM
    {
        public int id { get; set; }
        public string CustomerId { get; set; }
        public string InvoiceNo { get; set; }
        public string OrderNo { get; set; }
        public string DisplayName { get; set; }
        public DateTime InvoiceDate { get; set; }
        public string Remarks { get; set; }
        public decimal GrossTotal { get; set; }
        public decimal NetTotal { get; set; }
        public decimal TotalTax { get; set; }
        public decimal TotalDiscounts { get; set; }
        public int CreatedUserId { get; set; }

    }
}

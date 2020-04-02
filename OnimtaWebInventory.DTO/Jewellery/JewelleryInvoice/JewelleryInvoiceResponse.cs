using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.JewelleryInvoice
{
    public class JewelleryInvoiceResponse : BaseResponse
    {
        public IEnumerable<InvoiceVM> Invoices { get; set; }
        public InvoiceVM Invoice { get; set; }
        public IEnumerable<RewardsVM> rewardsVM { get; set; }
        public IEnumerable<PettyCashVM> PettyCashs { get; set; }
        public PettyCashVM PettyCash { get; set; }
        public RefundVM Refund { get; set; }
        public IEnumerable<RefundVM> Refunds { get; set; }
    }
}

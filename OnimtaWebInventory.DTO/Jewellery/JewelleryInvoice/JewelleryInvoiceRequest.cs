using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.JewelleryInvoice
{
    public class JewelleryInvoiceRequest : BaseRequest
    {
        public InvoiceVM Invoice { get; set; }
        public RewardsVM rewards { get; set; }
        public PettyCashVM PettyCash { get; set; }
        public RefundVM Refund { get; set; }


    }
}

using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderReport
{
    public class PurchaseOrderReportResponse : BaseResponse
    {
        public IEnumerable<PurchaseOrderReportVM> purchaseOrderReportVm { get; set; }
    }
}

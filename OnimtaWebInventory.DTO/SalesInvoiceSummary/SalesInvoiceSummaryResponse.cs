using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.SalesInvoiceSummary
{
    public class SalesInvoiceSummaryResponse:BaseResponse
    {
        public IEnumerable<SalesInvoiceSummaryVM> salesInvoiceSummaryVM;
    }
}

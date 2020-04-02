using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PurchaseOrderInteligence
{
   public class PurchaseOrderInteligenceResponse :BaseResponse
    {

    }
    public class PurchaseAndSalesSummaryResponse : BaseResponse
    {
        public IEnumerable<PurchaseAndSalesSummaryVM> purchaseAndSalesSummaryVM { get; set; }

    }


}

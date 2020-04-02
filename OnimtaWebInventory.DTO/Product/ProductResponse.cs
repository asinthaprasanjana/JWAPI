using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Product
{
  public  class ProductResponse:BaseResponse
    {
        public IEnumerable<ProductVM> productVM { get; set; }
        public IEnumerable<PriceCategoryVM> priceCategoryVm { get; set; }
        public IEnumerable<PriceLevelVM> priceLevelVM { get; set; }
        public IEnumerable<PurchaseOrderRequestItemsViewVm> purchaseOrderRequestItemsViewVm { get; set; }

        
    }
}

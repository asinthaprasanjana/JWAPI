using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ProductLevelSummeryResponse
{
    public class ProductLevelSummeryResponse : BaseResponse
    {
        public IEnumerable<ProductLevelSummeryVM> productLevelSummeryVMs  { get; set;  }
    }
}

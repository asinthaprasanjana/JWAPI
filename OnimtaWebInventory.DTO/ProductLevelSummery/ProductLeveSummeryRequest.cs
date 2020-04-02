using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ProductLevelSummeryRequest
{
    public class ProductLevelSummeryRequest :BaseRequest
    {
        public IEnumerable<ProductLevelSummeryVM> ProductLevelSummeryVM { get; set; }
    }
}

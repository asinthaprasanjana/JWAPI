using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ProductLevel
{
    public class ProductLevelRequest :BaseRequest
    {
        public IEnumerable<ProductLevelVM> ProductLevelVM { get; set; }
        public IndustryLevelVM IndustryLevel { get; set; }
        // public ProductLevelVM ProductLevelvm { get; set; }
    }
}

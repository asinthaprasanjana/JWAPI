using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ProductLevel
{
    public class ProductLevelResponse : BaseResponse
    {
        public IEnumerable<ProductLevelVM> ProductLevelVM { get; set;  }
        public ProductLevelVM ProductLevelvm { get; set; }
        public IEnumerable<IndustryVM> Industries { get; set; }
        public IEnumerable<IndustryLevelVM> IndustryLevels { get; set; }
        public IndustryLevelVM IndustryLevel { get; set; }

    }
}

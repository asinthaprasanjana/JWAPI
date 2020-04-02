using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.ProductPriceLevel
{
    public class ProductPriceLevelRequest : BaseRequest
    {
        public IEnumerable<PriceLevelVM> priceLevelVM  { get; set; }
    }
}

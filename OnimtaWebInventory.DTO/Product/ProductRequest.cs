using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Product
{
  public  class ProductRequest : BaseRequest
    {
        public ProductVM productVM { get; set; }
        public PriceCategoryVM priceCategoryVM { get; set; }
        public PriceLevelVM priceLevelVM { get; set; }
    }
}

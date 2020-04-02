using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PriceCategory
{
    public class PriceCategoryRequest : BaseRequest
    {
        public PriceCategoryVM priceCategoryVM  { get; set; }
    }
}

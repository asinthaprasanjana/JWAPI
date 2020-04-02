using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.PriceCategory
{
    public class PriceCategoryResponse : BaseResponse
    {
        public IEnumerable<PriceCategoryVM> priceCategoryVM { get; set;  }
    }
}

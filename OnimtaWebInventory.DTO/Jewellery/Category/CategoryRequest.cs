using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.Category
{
   public class CategoryRequest : BaseRequest
    {
        public CategoryVM category { get; set; }
    }
}

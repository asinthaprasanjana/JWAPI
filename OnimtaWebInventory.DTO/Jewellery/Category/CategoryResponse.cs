using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.Category
{
  public class CategoryResponse : BaseResponse
    {
        public IEnumerable<CategoryVM> categories { get; set; }
        public CategoryVM category { get; set; }

    }
}

using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Product
{
  public  class PackSizeResponse:BaseResponse
    {
        public IEnumerable<PackSizeVM> packSizeVM { get; set; }
    }
}

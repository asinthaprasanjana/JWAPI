using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Product
{
  public  class PackSizeRequest : BaseRequest
    {
        public PackSizeVM packSizeVM { get; set; }
    }
}

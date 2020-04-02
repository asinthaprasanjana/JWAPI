using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.GemProductSetting
{
   public  class CommonAttributeRequest : BaseRequest
    {
        public CommonAttributesVM CommonAttributes { get; set; }
        public CommonGroupsVM CommonGroup { get; set; }
    }
}

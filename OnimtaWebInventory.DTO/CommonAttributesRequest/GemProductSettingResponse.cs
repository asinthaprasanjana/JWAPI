using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.GemProductSetting
{
   public  class CommonAttributeResponse : BaseResponse
    {
        public IEnumerable<CommonAttributesVM> CommonAttributes { get; set; }
        public IEnumerable<CommonGroupsVM> commonGroups { get; set; }
        public CommonAttributesVM CommonAttribute { get; set; }
        public CommonGroupsVM commonGroup { get; set; }

    }
}

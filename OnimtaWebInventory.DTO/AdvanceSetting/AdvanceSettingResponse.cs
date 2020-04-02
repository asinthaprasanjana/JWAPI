using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.AdvanceSetting
{
   public  class AdvanceSettingResponse : BaseResponse
    {
        public IEnumerable<AdvanceSettingVM> advanceSettingVM { get; set; }
    }
}

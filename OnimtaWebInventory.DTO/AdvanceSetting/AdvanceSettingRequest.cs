using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.AdvanceSetting
{
   public class AdvanceSettingRequest : BaseRequest
    {
       public AdvanceSettingVM advanceSettingVM { get; set; }
    }
}

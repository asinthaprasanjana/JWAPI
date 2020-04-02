using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.DropDown
{
   public class DropDownResponse : BaseResponse
    {
        public IEnumerable<DropDownVM> DropDowns { get; set; }
        public DropDownVM DropDown { get; set; }
        public IEnumerable<TraySlotVM> TraySlots { get; set; }
    }
}

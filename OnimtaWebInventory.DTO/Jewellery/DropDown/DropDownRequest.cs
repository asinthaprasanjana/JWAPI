using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.DropDown
{
   public class DropDownRequest :BaseRequest
    {
        public DropDownVM DropDown { get; set; }
    }
}

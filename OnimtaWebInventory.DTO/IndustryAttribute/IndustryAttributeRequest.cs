using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.IndustryAttribute
{
   public class IndustryAttributeRequest : BaseRequest
    {
        public IndustryVM industryVM { get; set; }
    }
}

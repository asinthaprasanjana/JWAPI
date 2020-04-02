using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.IndustryAttribute
{
   public  class IndustryAttributeResponse :BaseResponse
    {
        public IEnumerable<IndustryVM> industryVM { get; set; }
        public IEnumerable<IndustryNameVM> industryNameVM { get; set; }
    }
}

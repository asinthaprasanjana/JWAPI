using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.AdavanceSearch
{
   public  class AdvanceSearchResponse : BaseResponse
    {
        public IEnumerable<AdvanceSearchVM> advanceSearchVM { get; set; }
    }

    
}

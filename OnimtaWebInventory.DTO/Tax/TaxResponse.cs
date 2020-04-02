using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Tax
{
    public  class TaxResponse : BaseResponse
    {
        public IEnumerable<TaxVM> taxVM { get; set; }
    }
}

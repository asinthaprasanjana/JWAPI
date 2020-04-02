using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Curreny
{
   public class CurrencyResponse : BaseResponse
    {
        public IEnumerable<CurrencyVM> currenyVM { get; set; }
    }
}

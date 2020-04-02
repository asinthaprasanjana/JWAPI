using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Currency
{
   public class CurrencyRequest : BaseRequest
    {
        public CurrencyVM currencyVM { get; set; }
    }
}

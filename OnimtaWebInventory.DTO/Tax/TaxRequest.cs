using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Tax
{
   public class TaxRequest : BaseRequest
    {
        public TaxVM taxVM { get; set; }

    }
}

using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.BusinessPartner
{
  public  class BankResponse :BaseResponse
    {
        public IEnumerable<BankVM> bankVM { get; set; }
    }
}

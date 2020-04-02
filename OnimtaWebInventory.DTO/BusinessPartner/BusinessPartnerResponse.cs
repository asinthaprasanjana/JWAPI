using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.BusinessPartner
{
  public  class BusinessPartnerResponse :BaseResponse
    {
       
        public IEnumerable<BusinessPartnerVM> businessPartnerVM { get; set; }
        public IEnumerable<BankVM> bankVM { get; set; }

    }
}

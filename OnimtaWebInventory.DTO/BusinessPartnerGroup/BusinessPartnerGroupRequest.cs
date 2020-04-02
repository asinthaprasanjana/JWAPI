using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.BusinessPartnerGroup
{
   public  class BusinessPartnerGroupRequest :BaseRequest
    {
        public BusinessPartnerGroupVM businessPartnerGroupVM { get; set; }
    }
}

using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.BusinessPartnerGroup
{
   public class BusinessPartnerGroupResponse : BaseResponse
    {
        public IEnumerable<BusinessPartnerGroupVM> businessPartnerGroupVM { get; set; }
    }
}

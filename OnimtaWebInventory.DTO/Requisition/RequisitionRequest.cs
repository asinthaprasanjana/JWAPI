using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Requisition
{
   public  class RequisitionRequest : BaseRequest
    {
        public RequisitionVM requisitionVM { get; set; }

    }
}

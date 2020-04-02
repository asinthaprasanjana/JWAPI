using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Requisition
{
   public  class RequisitionResponse : BaseResponse
    {
        public IEnumerable<RequisitionVM> requisitionVM { get; set; }
    }
}

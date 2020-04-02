using System.Collections.Generic;
using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
namespace OnimtaWebInventory.DTO.OwnApprovalDetail
{
    public class OwnApprovalDetailResponse:BaseResponse
    {
        public IEnumerable<OwnApprovalDetailsVM> ownApprovalDetailsVM { get; set; }

    }
}
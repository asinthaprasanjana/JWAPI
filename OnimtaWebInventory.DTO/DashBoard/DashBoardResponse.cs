using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace OnimtaWebInventory.DTO.DashBoard
{
   public class DashBoardResponse : BaseResponse
    {
        public IEnumerable<DashBoardVM> dashBoardVM { get; set; }

    }
}

using OnimtaInventoryCommon;
using OnimtaWebInventory.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Report
{
    public class ReportResponse : BaseResponse
    {

        public IEnumerable<ReportVM> reportVM { get; set; }

    }
}
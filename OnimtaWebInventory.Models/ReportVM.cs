using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class ReportVM
    {
        public int UserId { get; set; }
        public int ReportId { get; set;  }
        public  string ReportType { get; set; }
        public int CompanyId { get; set; }
        public float  NetTotal { get; set; }
        public string BranchName { get; set; }
        public string ProductName { get; set; }

    }
}

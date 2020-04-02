using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public  class PrintHistoryDetailsVM 
    {
        public int Id { get; set; }
        public int PrintTypeId { get; set; }
        public string Description { get; set; }
        public string ReferenceNo { get; set; }
        public int CreatedUserId { get; set; }
        public string Date { get; set; }
    }
}

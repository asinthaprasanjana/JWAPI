using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class CancellationVM
    {
        public int Id {get;set;}
        public int CancellationTypeId { get; set; }
        public string ReferenceNumber { get; set; }
        public string   Reason { get; set; }
        public int CreatedUserId { get; set;}
     
    }
}

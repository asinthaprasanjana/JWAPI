using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class RequisitionVM
    {
        public int ProductId { get; set; }
        public float Quantity { get; set; }
        public float ApprovedQuantity { get; set;}
        public int UserId { get; set; }
        public int CreatedDateTime { get; set; }
        
    }
}

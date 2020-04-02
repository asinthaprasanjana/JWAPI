using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class PackSizeVM
    {
        public int PackSizeId { get; set; }
        public int ProductId { get; set; }
        public string PackSizeName { get; set; }
        public int PackQty { get; set; }
        public int CreatedUserId { get; set; }
        public int CompanyId { get; set; }
        public Boolean IsDeleted { get; set; }
    }
}

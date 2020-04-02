using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models.Jewellery
{
   public  class TraySlotVM
    {
        public int    Id { get; set; }
        public int    TrayId { get; set; }
        public string SlotCode { get; set; }
        public int  ProductId { get; set; }
        public JewelleryProductVM Product { get; set; }
    }
}

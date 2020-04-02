using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.JewelleryProduct
{
   public class JewelleryProductRequest :BaseRequest
    {
        public JewelleryProductVM JewelleryProduct { get; set; }
        public TraySlotVM traySlotVM { get; set; }
        public GoldRateVM goldRate { get; set; }
        public JewelleryTransferVM JewelleryTransfer { get; set; }
        public CustomerJw customer { get; set; }
        public IEnumerable<CustomerJw> customers { get; set; }
    }
}

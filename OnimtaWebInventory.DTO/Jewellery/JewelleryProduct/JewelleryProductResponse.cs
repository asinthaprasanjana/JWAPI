using OnimtaInventoryCommon;
using OnimtaWebInventory.Models.Jewellery;
using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.DTO.Jewellery.JewelleryProduct
{
   public  class JewelleryProductResponse :BaseResponse
    {
        public JewelleryProductVM JewelleryProduct { get; set; }
        public IEnumerable<JewelleryProductVM> JewelleryProducts { get; set; }
        public IEnumerable<TraySlotVM> TraySlotVM { get; set; }
        public IEnumerable<GoldRateVM> goldRates { get; set; }
        public IEnumerable <JewelleryTransferVM> JewelleryTransfers { get; set; }
        public JewelleryTransferVM JewelleryTransfer { get; set; }
        public IEnumerable<CustomerJw> customers { get; set; }
        public CustomerJw customer { get; set; }

    }
}

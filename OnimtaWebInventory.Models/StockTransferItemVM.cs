using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class StockTransferItemVM
    {
        public int Id { get; set; }
        public string TransferId { get; set; }
        public int SourceLocationId { get; set; }
        public int DestinationLocationId { get; set; }
        public string Date { get; set; }
        public int CreatedUserId { get; set; }
        public int CompanyId { get; set; }
        public int Product { get; set; }
        public StockVM ProductObj { get; set; }
        public string ProductName { get; set; }
        public int Quantity { get; set; }
        public int PackSize { get; set; }
        public PackSizeVM PackSizeObj { get; set; }
        public int PriceLevel { get; set; }
        public PriceLevelVM PriceLevelObj { get; set; }
        public float Price { get; set; }
        public float Total { get; set; }
        public string PackSizeName { get; set; }

    }
}

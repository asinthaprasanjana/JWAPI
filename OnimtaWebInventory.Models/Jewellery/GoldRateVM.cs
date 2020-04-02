using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models.Jewellery
{
    public class GoldRateVM
    {
        public int Id { get; set; }
        public double Rate { get; set; }
        public DateTime Date { get; set; }
        public int ReceiptNumber {get;set;}
    }
}

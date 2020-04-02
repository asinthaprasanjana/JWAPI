using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class ProductLevelSummeryVM
    {
        public int Id { get; set; }
        public int Data { get; set; }
        public string Label { get; set; }

        public IList<ProductLevelSummeryVM> Children { get; set; }
    }

    public class SubProductLevelSummeryVM
    {
        public int Id { get; set; }
        public int Data { get; set; }
        public string Label { get; set; }

    }
}

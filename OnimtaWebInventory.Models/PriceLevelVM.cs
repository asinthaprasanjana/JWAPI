using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
   public class PriceLevelVM
    {
        public int Id { get; set; }

        public int UserId { get; set; }


        public int ProductId { get; set; }

        public decimal Price { get; set; }


        public string PriceLevelName { get; set; }

        public string Status { get; set; }


        public string UserName { get; set; }

        public string Date { get; set; }

        public Data  Data { get; set; }
        public IEnumerable< Children> Children { get; set; }
        public IEnumerable<Data> data1 { get; set; }

        public IEnumerable<Data> NewPriceLevel { get; set; }

    }


    public class Data
    {
       public int Id { get; set; }
       public int  ProductPriceLevelId { get; set; }
       public int  BranchId { get; set; }
       public int  ProductId { get; set; }
       public int  PackSizeId { get; set; }
       public int  PriceType { get; set; }
       public int Price { get; set; }
       public int CreatedUserId { get; set; }

        public string Name { get; set; }

        public int PriceTypeId { get; set; }





        public decimal? price1 { get; set; }
        public decimal? price2 { get; set; }
        public decimal? price3 { get; set; }
        public decimal? price4 { get; set; }

        public decimal? price5 { get; set; }
        public decimal? price6 { get; set; }

        public decimal? price7 { get; set; }
        public decimal? price8 { get; set; }

        public decimal? price9 { get; set; }
        public decimal? price10 { get; set; }

    }

    public class Children
    {
       // public IEnumerable< Data> Data { get; set; }
        public Data Data { get; set; }

    }

    public class PriceLevelBasicDetailsVM
    {
        public int Id { get; set; }
        public int PriceLevelId { get; set; }
        public int PriceTypeId { get; set; }
        public string PriceLevelName { get; set; }
        public int BranchId { get; set; }

        public string BranchName { get; set; }

        public string ProductName { get; set; }

        public int PackSizeId { get; set; }
        public string PackSizeName { get; set; }

        public string PriceType { get; set; }

        public DateTime CreatedDateTime { get; set; }

        public decimal Price { get; set; }

    }
}

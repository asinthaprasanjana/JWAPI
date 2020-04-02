using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.Text;


namespace OnimtaWebInventory.Models.Jewellery
{
    public class JewelleryProductVM
    {
        public int Id { get; set; }
        public string Standard { get; set; }
        public int Category { get; set; }
        public CategoryVM CategoryObj { get; set; }
        public int SubCategory { get; set; }
        public CategoryVM SubCategoryObj { get; set; }
        public string Supplier { get; set; }
        public string Brand { get; set; }
        public string ItemCode { get; set; }
        public string MadeIn { get; set; }
        public string Description { get; set; }
        public int Section { get; set; }
        public DropDownVM SectionObj { get; set; }
        public int  Tray { get; set; }
        public DropDownVM TrayObj { get; set; }
        public int TraySlot { get; set; }
        public TraySlotVM TraySlotObj { get; set; }
        public string BillDescription { get; set; }
        public string DesignCode { get; set; }
        public string uom { get; set; }
        public decimal GoldWeight { get; set; }
        public int Material { get; set; }
        public CategoryVM MaterialObj { get; set; }
        public Boolean ConsiderStoneWeight { get; set; }
        public decimal CostPrice { get; set; }
        public decimal SellingPrice { get; set; }
        public decimal MinimumPrice { get; set; }
        public string CostCode { get; set; }
        public decimal StoneWeight { get; set; }
        public int Gem { get; set; }
        public CategoryVM GemObj { get; set; }
        public decimal DiamondWeight { get; set; }
        public decimal CentreStoneWeight { get; set; }
        public string DiamondClarity { get; set; }
        public int CreatedUserId { get; set; }
        public string Username { get; set; }
        public DateTime CreatedDateTime { get; set; }
        public Boolean IsActive { get; set; }
        public Boolean IsDeleted { get; set; }
        public int TotalCount { get; set; }
        public int LastModifiedUserId { get; set; }
        public DateTime LastModifiedDateTime { get; set; }

        public string logType { get; set; }
        public Boolean sold { get; set; }
        public Boolean IsTransfered { get; set; }
        public Boolean AutoGenItemCode { get; set; }
        public decimal Margin { get; set; }
        public string ImageUrl { get; set; }

        public Boolean Duplicates { get; set; }
        public Boolean NoCategory { get; set; }
        public Boolean ExistInExcel { get; set; }
    }

}

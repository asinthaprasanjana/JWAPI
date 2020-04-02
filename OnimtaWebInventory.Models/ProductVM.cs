using System;
using System.Collections.Generic;
using System.Text;
using Dapper.Contrib.Extensions;
using System.ComponentModel.DataAnnotations.Schema;

namespace OnimtaWebInventory.Models
{
   public  class ProductVM
    {
        //[Key]
        public BasicProductDetailsVM BasicProductDetails { get; set; }
        public int ProductId { get; set; }
        public string ProductGroupId { get; set; }
        public int Industry { get; set; }
        public int LevelId01  { get; set; }
        public int LevelId02 { get; set; }
        public int LevelId03 { get; set; }
        public int LevelId04 { get; set; }
        public int LevelId05 { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public string ShortDescription { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public bool IsTradingProduct { get; set; }
        public string CostingMethod { get; set; }
        public int IncomeAccountId { get; set; }
        public int CogsAccountId { get; set; }
        public int AssestsAccountId { get; set; }
        public double ReorderLevel { get; set; }
        public double ReorderQty { get; set; }
        public string UnitOfMeasure { get; set; }
        public int CompanyId { get; set; }
        public int CreatedUserId { get; set; }
        public int productCount { get; set; }

        //[Write(false)]
        //[Computed]
        //[DatabaseGenerated(DatabaseGeneratedOption.Computed)]
        public IEnumerable<PackSizeVM> PackSize { get; set; }
        public IEnumerable<CommonAttributesValuesVM> CommonAttributesValues { get; set; }
        public IEnumerable<CheckingDetailsVM> ProductCheckingDetails { get; set; }
    }

    public class BasicProductDetailsVM
    {
        public int ProductId { get; set; }
        public string ProductGroupId { get; set; }
        public int Industry  {get;set;}
        public int LevelId01 { get; set; }
        public int LevelId02 { get; set; }
        public int LevelId03 { get; set; }
        public int LevelId04 { get; set; }
        public int LevelId05 { get; set; }
        public string ProductName { get; set; }
        public string Sku { get; set; }
        public string ShortDescription { get; set; }
        public string ProductDescription { get; set; }
        public string ProductType { get; set; }
        public bool IsTradingProduct { get; set; }
        public string CostingMethod { get; set; }
        public int IncomeAccountId { get; set; }
        public int CogsAccountId { get; set; }
        public int AssestsAccountId { get; set; }
        public double ReorderLevel { get; set; }
        public double ReorderQty { get; set; }
        public string UnitOfMeasure { get; set; }
        public int CompanyId { get; set; }
        public int CreatedUserId { get; set; }
        public Boolean isExpireDateHandle { get; set; }
        public Boolean isSerialNoHandle { get; set; }
        public string Val1 { get; set; }

    }

    public class CommonAttributesValuesVM
    {
        public int DataId { get; set; }
        public string Data { get; set; }
        public int AttributeId { get; set; }
        public int ProductId { get; set; }
    }

    public class CheckingDetailsVM
    {
        public Nullable<int>Id { get; set; }
        public int ProductId { get; set; }
        public int ProductCheckingId { get; set; }
        public IEnumerable<int> BranchIds { get; set; }
        public Nullable<int> BranchId { get; set; }
        public int CreatedUserId { get; set; }
    }
}

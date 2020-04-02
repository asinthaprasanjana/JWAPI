using System;
using System.Collections.Generic;
using System.Text;

namespace OnimtaWebInventory.Models
{
    public class TaxVM
    {
        public int Id { get; set; }
        public string TaxName { get; set; }
        public bool IsTaxGroup { get; set; }
        public int  TaxId { get; set; }
        public bool IsCompoundTax {get; set;}
        public int  Percentage { get; set; }
        public IEnumerable< SubTaxVM> SubTaxVM { get; set; }
       
    }

    public class SubTaxVM
    {
        public int UserId { get; set; }
        public int TaxNo { get; set; }
        public string TaxType { get; set; }
        public int CompanyId { get; set; }

    }
}
